using HelpLibrary.DTOs.Users;

namespace HelpLibrary.Responces
{
    public record UpdateUserResponce(bool Flag, UpdateUser UpdateUser = null!);
}
