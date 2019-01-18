using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    public class ClientCorsOrigin
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Origin { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

    }
}
