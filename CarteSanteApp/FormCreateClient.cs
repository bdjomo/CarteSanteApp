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
    public partial class FormCreateClient : Form
    {
        // Dans FormCreateClient.cs
        private readonly int _currentUserId;
        public FormCreateClient(int currentUserId)
        {
            InitializeComponent();
            _currentUserId = currentUserId;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCreateClient_Load(object sender, EventArgs e)
        {

        }

        private void ClearFormFields()
        {
            txt_Name.Clear();
            txt_Vorname.Clear();
            dtp_BirthDate.Value = DateTime.Now;
            txt_MonthlyPayment.Clear();
            txt_CostConsultation.Clear();

            // Remet le focus sur le premier champ de saisie
            txt_Name.Focus();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            // 1. Validation des champs obligatoires
            if (string.IsNullOrWhiteSpace(txt_Name.Text) || string.IsNullOrWhiteSpace(txt_Vorname.Text))
            {
                MessageBox.Show("Le Nom, le Prénom et la date de naissance sont obligatoires.",
                                "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Conversion des montants décimaux
            decimal.TryParse(txt_MonthlyPayment.Text.Trim(), out decimal payementMensuel);
            decimal.TryParse(txt_CostConsultation.Text.Trim(), out decimal coutConsultation);

            try
            {
                using (var db = new AppDbContext())
                {
                    // 3. Création du client avec le UserId récupéré depuis la session
                    var newClient = new Client
                    {
                        Nom = txt_Name.Text.Trim(),
                        Prenom = txt_Vorname.Text.Trim(),
                        DateNaissance = dtp_BirthDate.Value.ToUniversalTime(),
                        PayementMensuel = payementMensuel,
                        CoutConsultationExamenPharmacie = coutConsultation,

                        // AUTOMATIQUE : Affectation du UserId de l'utilisateur connecté
                        //UserId = UserSession.CurrentUserId,
                        UserId = _currentUserId,
                        CreatedClientByUserId = _currentUserId,
                        CreatedAt = DateTime.UtcNow,

                        // Dates de suivi initiales
                        DatePayement = DateTime.UtcNow,
                        DateConsultationExamenPharmacie = DateTime.UtcNow,
                        DateSolde = DateTime.UtcNow
                    };

                    // 4. Enregistrement dans PostgreSQL
                    db.Clients.Add(newClient);
                    db.SaveChanges();

                    // 5. Audit-Eintrag in ARCHIVAGE erstellen
                    var logAudit = new Archivage
                    {
                        UserId = _currentUserId,
                        CreatedClientByUserId = _currentUserId,
                        ClientId = newClient.ClientId, // Nun ist die ID verfügbar!
                        CreatedAt = DateTime.UtcNow,
                        ActionType = "CREATE_CLIENT",
                        EntityName = "Client",
                        EntityId = newClient.ClientId,
                        Details = $"Création du Client {newClient.Nom} {newClient.Prenom}"
                    };

                    // 6. Audit-Eintrag in ARCHIVAGE speichern
                    db.Archives.Add(logAudit);
                    db.SaveChanges(); // <-- Audit speichern

                    //AuditService.LogAction("CREATE_CLIENT", "Client", newClient.ClientId, $"Création du Client {newClient.Nom} {newClient.Prenom} le {DateTime.Now:dd/MM/yyyy HH:mm:ss}", userId: _currentUserId, clientId: newClient.ClientId);

                    DialogResult result = MessageBox.Show(
                        "Nouveau client créé avec succès !\nVoulez-vous créer un autre client ?",
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
                MessageBox.Show($"Erreur lors de l'enregistrement : {ex.Message}",
                                "Erreur BDD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            Anmeldung registrationForm = new Anmeldung();
            registrationForm.Show();
            this.Hide();
        }
    }
}
