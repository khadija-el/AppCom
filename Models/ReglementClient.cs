using System;
using System.Collections.Generic;

namespace ApiCom.Models
{
    public partial class ReglementClient
    {
        public ReglementClient()
        {
            // Syntheses = new HashSet<Synthese>();
        }

        public Guid Id { get; set; }
        public decimal Montant { get; set; }
        public DateTime D_Creation { get; set; }
        public Guid? IdLivraisonClient { get; set; }
        public virtual LivraisonClient LivraisonClient { get; set; }
    
    }
}
