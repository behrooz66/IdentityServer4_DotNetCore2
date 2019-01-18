using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    public class UserClaim
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
