public class AuthService
{
    private readonly BankingContext _context;

    public AuthService(BankingContext context)
    {
        _context = context;
    }

    public async Task<(bool Success, string Message, object Data)> RegisterAsync(RegisterRequest request)
    {
        // Implement registration logic here
        return await Task.FromResult((true, "Registration successful", (object)null));  // Corrected async method
    }

    public async Task<(bool Success, string Message, object Data)> LoginAsync(LoginRequest request)
    {
        // Implement login logic here
        return await Task.FromResult((true, "Login successful", (object)null));  // Corrected async method
    }
}