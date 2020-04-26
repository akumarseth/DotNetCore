using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace BusinessAccess.IServices
{
    public interface IUserService
    {
        bool IsValidUser(LoginViewModel user);
    }
}
