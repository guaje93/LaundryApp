using System;
using System.Collections.Generic;
using System.Text;

namespace App5.Model
{
    public static class RegisterValidator
    {
        private static StringBuilder message = new StringBuilder();

        public static StringBuilder Message { get => message; set => message = value; }

        public static bool Validate(User user)
        {
            if (ValidateIfAllFieldsAreFilled(user) && ValidateEmail(user) && ValidatePassword(user))
            {
                Message.Clear();
                return true;
            }
            else
                return false;
        }
        private static bool ValidatePassword(User user)
        {
            if (user.Password == user.ConfirmPassword)
                return true;
            else
            {
                Message.Append("Passwords are different\n");
                return false;
            }
        }

        private static bool ValidateIfAllFieldsAreFilled(User user)
        {
            if (String.IsNullOrEmpty(user.ConfirmPassword) ||
                String.IsNullOrEmpty(user.Email) ||
                String.IsNullOrEmpty(user.FirstName) ||
                String.IsNullOrEmpty(user.LastName) ||
                String.IsNullOrEmpty(user.Password) ||
                String.IsNullOrEmpty(user.Room.ToString()))
            return true;
            else
            {
                Message.Append("Not all mandatory fields are filled\n");
                return false;
            }
        }

        private static bool ValidateEmail(User user)
        {
            if (user.Email.Contains("@"))
                return true;
            else 
            {
                Message.Append("Not correct Email\n");
                    return false;
            }
        }
    }
}
