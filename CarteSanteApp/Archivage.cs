using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarteSanteApp
{
    [Table("archivage")]
    public class Archivage
    {
        [Key]
        [Column("arch_id")]
        public int ArchId { get; set; }

        [Column("user_id")]
        public int? UserId { get; set; }

        [Column("client_id")]
        public int? ClientId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("action_type")]
        public string? ActionType { get; set; }

        [Column("entity_name")]
        public string? EntityName { get; set; }

        [Column("entity_id")]
        public int? EntityId { get; set; }

        [Column("details")]
        public string? Details { get; set; }
        [Column("deleted_by_user_id")]
        public int? DeletedByUserId { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
        [Column("created_by_user_id")]
        public int? CreatedClientByUserId { get; set; }
        [Column("created_user_by_user_id")]
        public int? CreatedUserByUserId { get; set; }
    }
}