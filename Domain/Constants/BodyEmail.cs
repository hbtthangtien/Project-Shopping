using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constants
{
    public static class BodyEmail
    {

        public static string Body(string email, string link)
        {
            var body = $@"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Email Confirmation</title>
</head>
<body style=""margin: 0; font-family: Arial, sans-serif; background-color: #333; color: #333; display: flex; justify-content: center; align-items: center; height: 400px;"">
    <div style=""background-color: white; width: 100vw; padding: 20px; border-radius: 10px; text-align: center; box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.2);"">
        <img src=""https://res.cloudinary.com/dkyqm6vou/image/upload/v1737280894/OIP_3_ovpptg.jpg"" alt=""Envelope Icon"" style=""width: 80px; margin-bottom: 20px;"">
        <h1 style=""font-size: 20px; margin: 10px 0;"">Email Confirmation</h1>
        <p style=""font-size: 14px; margin: 10px 0;"">
            We have sent an email to <strong>{email}</strong> to confirm the validity of your email address.
            After receiving the email, follow the link provided to complete your registration.
        </p>
        <p style=""font-size: 14px; margin: 10px 0;"">
            Please click the link below to confirm your email: <br>
            <a href=""{link}"" style=""color: #007BFF; text-decoration: none;"">Confirm Email</a>.
        </p>
    </div>
</body>
</html>";
            return body;
        }

        public static string BodyResetPassword(string email, string link)
        {
            var body = $@"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Email Confirmation</title>
</head>
<body style=""margin: 0; font-family: Arial, sans-serif; background-color: #333; color: #333; display: flex; justify-content: center; align-items: center; height: 400px;"">
    <div style=""background-color: white; width: 100vw; padding: 20px; border-radius: 10px; text-align: center; box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.2);"">
        <img src=""https://res.cloudinary.com/dkyqm6vou/image/upload/v1737280894/OIP_3_ovpptg.jpg"" alt=""Envelope Icon"" style=""width: 80px; margin-bottom: 20px;"">
        <h1 style=""font-size: 20px; margin: 10px 0;"">Request to reset password</h1>
        <p style=""font-size: 14px; margin: 10px 0;"">
            We have sent an email to <strong>{email}</strong> to confirm the validity of request to reset password
            After receiving the email, follow the link provided to complete your request.
        </p>
        <p style=""font-size: 14px; margin: 10px 0;"">
            Please click the link below to reset password: <br>
            <a href=""{link}"" style=""color: #007BFF; text-decoration: none;"">Reset password here</a>.
        </p>
    </div>
</body>
</html>";
            return body;
        }

        public static string BodyRegisterStore(string email, string link)
        {
            var body = $@"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Email Confirmation</title>
</head>
<body style=""margin: 0; font-family: Arial, sans-serif; background-color: #333; color: #333; display: flex; justify-content: center; align-items: center; height: 400px;"">
    <div style=""background-color: white; width: 100vw; padding: 20px; border-radius: 10px; text-align: center; box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.2);"">
        <img src=""https://res.cloudinary.com/dkyqm6vou/image/upload/v1737280894/OIP_3_ovpptg.jpg"" alt=""Envelope Icon"" style=""width: 80px; margin-bottom: 20px;"">
        <h1 style=""font-size: 20px; margin: 10px 0;"">Request to reset password</h1>
        <p style=""font-size: 14px; margin: 10px 0;"">
            Welcome <strong>{email}</strong> become a seller in our website            
        </p>        
    </div>
</body>
</html>";
            return body;
        }
    }
}
