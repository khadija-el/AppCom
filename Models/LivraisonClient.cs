using System;
using System.Collections.Generic;

namespace ApiCom.Models
{
    public partial class LivraisonClient
    {
        public LivraisonClient()
        {
            // Syntheses = new HashSet<Synthese>();
        }

        public Guid Id { get; set; }
        public string Numero { get; set; }
        public DateTime date { get; set; }
        public string Telephone { get; set; }
        public string Info { get; set; }
        public Decimal MontantHT { get; set; }
        public Decimal TVA { get; set; }
        public Decimal MontantTTC { get; set; }
        public Decimal Escompte { get; set; }
        public Guid? IdClient { get; set; }
        public virtual Client Client { get; set; }
        public Guid? IdUser { get; set; }
        public virtual User User   { get; set; }
        public virtual ICollection<DetailLivraisonClient> DetailLivrasoinClients { get; set; }
        public virtual ICollection<ReglementClient> ReglementClient { get; set; }

    

    }
}
