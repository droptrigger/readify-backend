using HelpLibrary.DTOs.Users;
using HelpLibrary.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Services.Interfaces
{
    public interface IUserService
    {
        Task<UpdateUserResponce> UpdateUserAsync(UpdateUser user);
    }
}
