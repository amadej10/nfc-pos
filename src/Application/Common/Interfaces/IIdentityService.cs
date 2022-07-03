using nfc_pos.Application.Common.Models;

namespace nfc_pos.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string> GetUserNameAsync(string userId);

    Task<(string Name, decimal Balance)> GetUserNameAndBalanceAsync(string nfcId);
    
    Task<decimal> TopUpBalanceAsync(string nfcId, decimal Balance);

    Task<decimal> DeductBalanceAsync(string nfcId, decimal Balance);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string Name, string Surname, string Description, string NfcId, string password);

    Task<Result> DeleteUserAsync(string userId);
}
