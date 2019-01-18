using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class ClientSecret: Secret
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

    }
}
