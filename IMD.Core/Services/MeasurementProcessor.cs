using IMD.Core.Models;
using IMD.Core.Parsing;
using IMD.Core.Services;


public class MeasurementProcessor
{
    private readonly ToleranceService _toleranceService;
    private readonly CalibrationSettings _calibrationSettings;

    public MeasurementProcessor(ToleranceService toleranceService, CalibrationSettings calibrationSettings)
    {
        _toleranceService = toleranceService;
        _calibrationSettings = calibrationSettings;
    }

    public bool TryProcess(string line,
                           out MeasurementResult result,
                           out MeasurementDbRecord record,
                           out string? error)
    {
        result = default!;
        record = default!;
        error = null;

        if (!MeasurementParser.TryParse(line, out var raw, out error))
            return false;

        var widthMm = ScalingService.ScaleWidthMm(raw.RawWidth);
        var weightG = ScalingService.ScaleWeightG(raw.RawWeight);

        widthMm = NativeCalibration.Calibrate(widthMm,
                                              _calibrationSettings.WidthOffset,
                                              _calibrationSettings.WidthGain);

        weightG = NativeCalibration.Calibrate(weightG,
                                              _calibrationSettings.WeightOffset,
                                              _calibrationSettings.WeightGain);

        var quality = _toleranceService.Evaluate(widthMm, weightG);
        var accepted = _toleranceService.IsAccepted(quality);

        result = new MeasurementResult(raw.Timestamp,
                                       widthMm,
                                       weightG,
                                       quality,
                                       accepted);

        record = new MeasurementDbRecord(raw.Timestamp,
                                         raw.RawWidth,
                                         raw.RawWeight,
                                         widthMm,
                                         weightG,
                                         quality.ToString(),
                                         accepted,
                                         null);

        return true;
    }
}