using DebateSystem.Models;
using System.ComponentModel.DataAnnotations;
using System;

namespace DebateSystem.Services
{
    public class ApplicationUserValidation : IApplicationUserValidation
    {
        public ApplicationUser userValidation(ApplicationUser user)
        {
            if(user == null)
            {
                throw new InvalidOperationException("user not find");
            }

            if(user.UserName == null|| user.UserName.Equals(""))
            {
                throw new InvalidOperationException("username cannot be empty");
            }

            if(user.Email == null || user.Email.Equals(""))
            {
                throw new InvalidOperationException("user email cannot be empty");
            }

            if(!new EmailAddressAttribute().IsValid(user.Email))
            {
                throw new InvalidOperationException("user email is not valid");
            }

            if(user.Password == null|| user.Password.Equals(""))
            {
                throw new InvalidOperationException("user password cannot be empty");
            }

            return user;
        }
    }
}
