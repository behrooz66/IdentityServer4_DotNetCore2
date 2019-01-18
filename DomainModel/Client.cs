using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace DomainModel
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string ClientId { get; set; }
        public bool AllowOfflineAccess { get; set; } = true;
        public bool AccessTokenIsReference { get; set; } = false;
        public int AccessTokenLifeTime { get; set; } = 3600;
        public int RefreshTokenExpiration { get; set; } = 0;
        public int SlidingRefreshTokenLifetime { get; set; } = 1296000;
        public bool Enabled { get; set; } = true;

        public virtual ICollection<ClientGrantType> AllowedGrantTypes { get; set; }
        public virtual ICollection<ClientSecret> ClientSecrets { get; set; }
        public virtual ICollection<ClientScope> AllowedScopes { get; set; }
        public virtual ICollection<ClientCorsOrigin> AllowedCorsOrigins { get; set; }
    }
}
