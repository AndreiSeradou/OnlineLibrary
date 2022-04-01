using System;
namespace Configuration.GeneralConfiguration
{
    public static class GeneralConfiguration
    {
        public const string UserRole = "AppUser";
        public const string LibrarianRole = "AppLibrarian";
        public const string ErrorName = "Name already in use";
        public const string ErrorEmail = "Email already in use";
        public const string ErrorLogin = "Invalid login request";
        public const string ErrorPayload = "Invalid payload";
        public const string CustomClaim = "Id";
        public const string InvalidModel = "Something went wrong";
        public const string BaseUrl = "http://localhost:8090";
        public const string JwtConfig = "JwtConfig";
        public const string DbConnection = "DefaultConnection";
        public const string JwtSecret = "JwtConfig:Secret";
        public const string Cors = "Open";
        public const string Policy = "DepartmentPolicy";
        public const string PolicyClaim = "department";
        public const string QuartzEmail = "andrey03072000@gmail.com";
        public const string QuartzPassword = "7798929aQ";
        public const string MailSmtp = "smtp.gmail.com";
        public const string MailSubject = "Library alert";
        public const string Expression = "0/10 0/1 * 1/1 * ? *";
    }
}
