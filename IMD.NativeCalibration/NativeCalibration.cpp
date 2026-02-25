#include "pch.h"   // keep this for the VS template (precompiled headers)
#include <cmath>

extern "C" __declspec(dllexport)
double Calibrate(double value, double offset, double gain)
{
    return (value + offset) * gain;
}

extern "C" __declspec(dllexport)
double MovingAverage(double previous, double current, double alpha)
{
    // Exponential moving average:
    // alpha in [0..1], closer to 1 => follow current more
    return alpha * current + (1.0 - alpha) * previous;
}
