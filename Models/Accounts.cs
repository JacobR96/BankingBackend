public class Account
{
    public int AccountId { get; set; }
    public int UserId { get; set; }
    public string AccountType { get; set; }
    public string AccountIdentifier { get; set; }
    public User User { get; set; }
}