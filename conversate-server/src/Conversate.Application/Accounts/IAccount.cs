using Conversate.Shared.Account.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversate.Application.Accounts
{
    public interface IAccount
    {
        Task<string> Login(LoginDto input);
        Task<bool> SignIn(SignUpDto input);
    }
}
