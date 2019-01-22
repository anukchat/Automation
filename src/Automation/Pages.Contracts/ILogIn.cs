namespace Pages.Contracts
{
    public interface ILogIn
    {
        void LogIn(string userName, string password);

        void VerifyLogIn(string expectedUser);

        void ForgotPassword();

        void VerifyForgotPassword();
    }
}