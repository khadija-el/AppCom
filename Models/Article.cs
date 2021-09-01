using System;
using System.Collections.Generic;

namespace ApiCom.Models
{
    public partial class Article
    {
        public Article()
        {
            // Syntheses = new HashSet<Synthese>();
        }

        public Guid Id { get; set; }
        public string Reference { get; set; }
        public string Designation { get; set; }
        public string Couleur { get; set; }
        public decimal Longeur { get; set; }
        public decimal Largeur { get; set; }
        public Decimal stockFinal { get; set; }
        public Decimal stockInitial { get; set; }
        public Decimal QteVendue { get; set; }
        public Decimal QteAcheté { get; set; }
        public Decimal stockMinimal { get; set; }
        public Decimal PrixAchat_HT { get; set; }
        public Decimal PrixAchat_TTC { get; set; }
        public Decimal PrixVente_HT { get; set; }
        public Decimal PrixVente_TTC { get; set; }
        public String Info { get; set; }
        public virtual ICollection<DetailLivraisonClient> DetailLivraisonClients { get; set; }

    }
}
