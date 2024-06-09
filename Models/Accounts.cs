public class Account
{
    public int Id { get; set; }
    public string AccountType { get; set; } = string.Empty;  // Initialized to non-null value
    public string AccountIdentifier { get; set; } = string.Empty;  // Initialized to non-null value
    public int UserId { get; set; }
    public User User { get; set; } = new User();  // Initialized to non-null value
}
