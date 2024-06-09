public class User
{
    public int Id { get; set; }  // Ensure this property exists
    public string FirstName { get; set; } = string.Empty;  // Initialized to non-null value
    public string LastName { get; set; } = string.Empty;  // Initialized to non-null value
    public string Email { get; set; } = string.Empty;  // Initialized to non-null value
    public string PasswordHash { get; set; } = string.Empty;  // Initialized to non-null value
    public ICollection<Account> Accounts { get; set; } = new List<Account>();  // Initialized to non-null value
}
