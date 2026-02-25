using IMD.Core.Models;

public class QualityStats
{
    public int Total { get; private set; }
    public int Perfect { get; private set; }
    public int Acceptable { get; private set; }
    public int Rejected { get; private set; }

    public void Add(QualityStatus status)
    {
        Total++;

        switch (status)
        {
            case QualityStatus.Perfect: Perfect++; break;
            case QualityStatus.Acceptable: Acceptable++; break;
            case QualityStatus.Rejected: Rejected++; break;
        }
    }

    public void Reset()
    {
        Total = Perfect = Acceptable = Rejected = 0;
    }
}