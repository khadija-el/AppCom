using System;
using System.Collections.Generic;

namespace ApiCom.Models
{
    public partial class User
    {
        public User()
        {
            // Syntheses = new HashSet<Synthese>();
        }

        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        // [System.Text.Json.Serialization.JsonIgnore]
        public string Password { get; set; }
        public string Adresse { get; set; }
        public string Username { get; set; }
        public virtual ICollection<LivraisonClient> LivrasoinClients { get; set; }

   
   }
}
