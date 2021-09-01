using System;
using System.Collections.Generic;

namespace ApiCom.Models
{
    public partial class DetailLivraisonClient
    {
        public DetailLivraisonClient()
        {
            // Syntheses = new HashSet<Synthese>();
        }

        public Guid Id { get; set; }
        public string Numero { get; set; }
        public string Designation { get; set; }
        public Decimal Quantite { get; set; }
        public Decimal Prix { get; set; }
        public Decimal MontantHT { get; set; }
        public Decimal TVA { get; set; }
        public Decimal MontantTTC { get; set; }
        public Guid? IdLivraisonClient { get; set; }
        public virtual LivraisonClient LivraisonClient { get; set; }
        public Guid? IdArticle { get; set; }
        public virtual Article Article { get; set; }
        // public virtual ICollection<ReglementClient> ReglamentClient { get; set; }

    }
}
