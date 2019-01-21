using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.Contracts
{
    public interface ILogIn
    {
        void LogIn(string userName,string password);
        void VerifyLogIn(string expectedUser);
        void ForgotPassword();
        void VerifyForgotPassword();
    }
}
