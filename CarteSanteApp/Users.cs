
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CarteSanteApp
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; } // Corrige les erreurs CS1061 'UserId'

        [Column("username")]
        public string Username { get; set; } = string.Empty;

        [Column("password_hash")]
        public string PasswordHash { get; set; } = string.Empty;

        [Column("email_adresse")]
        public string EmailAdresse { get; set; } = string.Empty;

        [Column("nom")]
        public string Name { get; set; } = string.Empty;

        [Column("prenom")]
        public string FirstName { get; set; } = string.Empty;

        [Column("droit")]
        public string Droit { get; set; } = "READ_ONLY"; // Corrige les erreurs CS1061 'Droit'

        // Tracking CREATE
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("created_by_user_id")]
        public int? CreatedUserByUserId { get; set; }

        // Tracking UPDATE
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_by_user_id")]
        public int? UpdatedByUserId { get; set; }

        // Tracking DELETE
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [Column("deleted_by_user_id")]
        public int? DeletedByUserId { get; set; }

        // Rôle (Enum ou Int)
        [Column("role_id")]
        public UserRole RoleId { get; set; } // Utilise l'enum UserRole directement
    }
}