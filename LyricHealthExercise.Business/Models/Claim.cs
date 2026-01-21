namespace LyricHealthExercise.Business.Models;

public class Claim
{
    public int Id { get; set; }
    public string Provider { get; set; }
    public decimal Amount { get; set; }
    public string DiagnosisCode { get; set; }
    public Status Status { get; set; }

    public bool IsValid()
    {
        return IsValidCode() && IsValidAmount();
    }
    
    public bool IsValidCode()
    {
        if (string.IsNullOrWhiteSpace(DiagnosisCode))
            return false;

        if (!char.IsLetter(DiagnosisCode[0]))
            return false;
        
        if (DiagnosisCode.Length < 2 || DiagnosisCode.Length > 5)
            return false;

        if (DiagnosisCode.Skip(1).Any(c => !char.IsDigit(c)))
            return false;
        
        return true;
    }
    
    public bool IsValidAmount()
    {
        if (Amount <= 0)
            return false;
        
        return true;
    }
}

public enum Status
{
    Pending, Approved, Rejected
}
