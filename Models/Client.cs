using System;
using System.Collections.Generic;

namespace ApiCom.Models
{
    public partial class Client
    {
        public Client()
        {
            // Syntheses = new HashSet<Synthese>();
        }

        public Guid Id { get; set; }
        public string Raisonsociale { get; set; }
        public string code { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        // [System.Text.Json.Serialization.JsonIgnore]
        public string Adresse { get; set; }
        public virtual ICollection<LivraisonClient> LivrasoinClients { get; set; }

    }
}
