using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace CarteSanteApp
{
    public partial class FormCreateUser : Form
    {
        private readonly int _currentUserId;
        public FormCreateUser(int currentUserId)
        {
            InitializeComponent();
            _currentUserId = currentUserId;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearFormFields()
        {
            txt_Name.Clear();
            txt_Firstname.Clear();
            txt_Username.Clear();
            txt_Password.Clear();
            txt_Email.Clear();
            txt_Role.Clear();
        }

        private void btn_CreateUser_Click(object sender, EventArgs e)
        {
            // 1. Validation des champs obligatoires
            if (string.IsNullOrWhiteSpace(txt_Name.Text) || string.IsNullOrWhiteSpace(txt_Firstname.Text) || string.IsNullOrWhiteSpace(txt_Username.Text) ||
                string.IsNullOrWhiteSpace(txt_Password.Text) || string.IsNullOrWhiteSpace(txt_Email.Text) || string.IsNullOrWhiteSpace(txt_Role.Text))
            {
                MessageBox.Show("Le Nom, le Prénom, UserName, Mot de pass, E_mail et le Role_Id sont obligatoires.",
                                "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    // 2. Rolle sicher in eine Zahl umwandeln
                    if (!int.TryParse(txt_Role.Text.Trim(), out int roleId /*roleIdNum*/))
                    {
                        MessageBox.Show("Bitte geben Sie eine gültige Zahlen-ID für die Rolle ein.", "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 4. Droit passend zur RoleId zuweisen
                    string droitValue = roleId switch
                    {
                        1 => "READ_ONLY",
                        2 => "READ_UPDATE",
                        3 => "READ_DELETE_UPDATE",
                        4 => "FULL_CLIENT_ACCESS",
                        5 => "ADMIN",
                        _ => "READ_ONLY"
                    };

                    // 5. Création d´utulisateur (User) avec le UserId récupéré depuis la session
                    var newUser = new User
                    {
                        Name = txt_Name.Text.Trim(),
                        FirstName = txt_Firstname.Text.Trim(),
                        Username = txt_Username.Text.Trim(),    
                        PasswordHash = txt_Password.Text.Trim(),
                        EmailAdresse = txt_Email.Text.Trim(),
                        RoleId = (UserRole)roleId, // <-- Hier den Int explizit zu (UserRole) casten!,
                        Droit = droitValue,

                        // AUTOMATIQUE : Affectation du UserId de l'utilisateur connecté
                        //UserId = UserSession.CurrentUserId,
                        CreatedUserByUserId = _currentUserId,
                        CreatedAt = DateTime.UtcNow
                    };

                    // 6. Enregistrement dans PostgreSQL
                    db.Users.Add(newUser);
                    db.SaveChanges();

                    // 7. Audit-Eintrag in ARCHIVAGE erstellen
                    var logAudit = new Archivage
                    {
                        //UserId = _currentUserId,
                        CreatedUserByUserId = _currentUserId,
                        UserId = newUser.UserId, // Nun ist die ID verfügbar!
                        CreatedAt = DateTime.UtcNow,
                        ActionType = "CREATE_User",
                        EntityName = "User",
                        EntityId = newUser.UserId,
                        Details = $"Création du User {newUser.Name} {newUser.FirstName}"
                    };

                    // 8. Audit-Eintrag in ARCHIVAGE speichern
                    db.Archives.Add(logAudit);
                    db.SaveChanges(); // <-- Audit speichern

                    // Lors de la création d'un utilisateur
                    //AuditService.LogAction("CREATE_USER", "User", newUser.UserId, $"Création de l'utilisateur {newUser.Username}", userId: _currentUserId);
                    AuditService.LogAction("CREATE_USER", "User", newUser.UserId, $"Création de l'utilisateur {newUser.Username} le {DateTime.Now:dd/MM/yyyy HH:mm:ss}", userId: _currentUserId);

                    //MessageBox.Show("Nouveau utilisateur créé avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // this.DialogResult = DialogResult.OK;
                    // this.Close();



                    DialogResult result = MessageBox.Show(
                       "Nouveau Utulisateure (User) créé avec succès !\nVoulez-vous créer un autre client ?",
                                   "Succès",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question
                   );

                    if (result == DialogResult.Yes)
                    {
                        // Option 1 : On réinitialise les champs et on reste sur FormCreateClient
                        ClearFormFields();
                    }
                    else
                    {
                        // Option 2 : On ferme la fenêtre pour retourner sur FormMain
                        // Masque la fenêtre FormCreateClient au lieu de la fermer
                        this.Hide();

                        FormMain mainForm = new FormMain();
                        mainForm.Show();
                    }
                }            
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Erreur lors de l'enregistrement : {ex.Message}", "Erreur BDD", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Zeigt den genauen Datenbank-Fehler an (InnerException)
                string errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show($"Erreur BDD : {errorMessage}", "Erreur BDD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
