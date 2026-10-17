using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarteSanteApp
{
    [Table("v_clients")]
    public class VClient
    {
        [Column("client_id")]
        public int ClientId { get; set; }

        [Column("nom")]
        public string Nom { get; set; } = string.Empty;

        [Column("prenom")]
        public string Prenom { get; set; } = string.Empty;

        [Column("date_naissance")]
        public DateTime? DateNaissance { get; set; }

        [Column("date_payement")]
        public DateTime? DatePayement { get; set; }

        [Column("date_consultation_examen_pharmacie")]
        public DateTime? DateConsultationExamenPharmacie { get; set; }

        [Column("date_solde")]
        public DateTime? DateSolde { get; set; }

        [Column("payement_mensuel")]
        public decimal PayementMensuel { get; set; }

        [Column("cout_consultation_examen_pharmacie")]
        public decimal CoutConsultationExamenPharmacie { get; set; }

        [Column("solde")]
        public decimal Solde { get; set; }

        [Column("is_solde_positif")]
        public bool IsSoldePositif { get; set; }

        [Column("user_id")]
        public int? UserId { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [Column("created_by_user_id")]
        public int? CreatedByUserId { get; set; }

        [Column("updated_by_user_id")]
        public int? UpdatedByUserId { get; set; }

        [Column("deleted_by_user_id")]
        public int? DeletedByUserId { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        [Column("Status")]
        public string? Status { get; set; }

        [Column("numero_carte")]
        public string? NumeroCarte { get; set; }
    }
}
