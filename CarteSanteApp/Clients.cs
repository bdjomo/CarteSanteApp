using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarteSanteApp
{
    [Table("clients")]
    public class Client
    {
        [Key]
        [Column("client_id")]
        public int ClientId { get; set; }

        [Column("nom")]
        public string Nom { get; set; } = string.Empty;

        [Column("prenom")]
        public string Prenom { get; set; } = string.Empty;

        [Column("date_naissance")]
        public DateTime DateNaissance { get; set; }

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

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("solde")]
        public decimal Solde { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("is_solde_positif")]
        public bool IsSoldePositif { get; private set; }

        [Column("user_id")]
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        [System.ComponentModel.Browsable(false)]
        public virtual User? User { get; set; }

        // Tracking für Erstellung (CREATE)
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("created_by_user_id")]
        public int? CreatedClientByUserId { get; set; }

        // Tracking für Aktualisierung (UPDATE)
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_by_user_id")]
        public int? UpdatedByUserId { get; set; }

        // Tracking für Soft Delete (DELETE)
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [Column("deleted_by_user_id")]
        public int? DeletedByUserId { get; set; }
    }
}
