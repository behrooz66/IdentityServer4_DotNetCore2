using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string Username { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [DefaultValue(false)]
        public bool Active { get; set; }

        [DefaultValue(false)]
        public bool EmailVerified { get; set; }

        [DefaultValue(false)]
        public bool PhoneNumberVerified { get; set; }

        // user's claims...
        public virtual ICollection<UserClaim> Claims { get; set; }

        // user's password reset token
        public virtual ICollection<PasswordResetToken> PasswordResetTokens { get; set; }

        // user's email verification token
        public virtual ICollection<EmailVerificationToken> EmailVerificationTokens { get; set; }

        public User()
        {
            Claims = new Collection<UserClaim>();
            PasswordResetTokens = new Collection<PasswordResetToken>();
            EmailVerificationTokens = new Collection<EmailVerificationToken>();
        }

    }
}
