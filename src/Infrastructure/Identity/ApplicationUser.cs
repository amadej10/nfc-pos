using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace nfc_pos.Infrastructure.Identity;

[Index(nameof(NfcId))]
public class ApplicationUser : IdentityUser
{
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    public string? NfcId { get; set; }
    public string? Description { get; set; }
    public decimal Balance { get; set; } = 0;
}
