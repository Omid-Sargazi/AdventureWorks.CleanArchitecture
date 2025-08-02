using AdventureWorks.Application.Models;

namespace AdventureWorks.Application.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(UserDto user);
    }
}