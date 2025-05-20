namespace InterBanking.Core.Domain.Entities;

public class Beneficiary
{
    public int Id { get; set; }
    public string Alias { get; set; }

    // Owner / User that created the beneficiary
    public string UserId { get; set; }
}