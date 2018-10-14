namespace NewsHubApi.Services
{
    public interface IPasswordService
    {
        string HashUserPassword(string password);
        bool ValidatePassword(string enteredPassword, string savedHashedPassword);
    }
}