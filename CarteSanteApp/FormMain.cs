using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
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
    public partial class FormMain : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentUserId { get; set; }

        // Eigenschaften zur Speicherung der übergebenen Daten
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] //Suppresses the designer warning WFO100C (juste pour Supprime l'avertissement du concepteur WFO100C)
        public string? CurrentUsername { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] //Suppresses the designer warning WFO100C (juste pour Supprime l'avertissement du concepteur WFO100C)
        public string? CurrentDroit { get; set; }

        // Standard-Konstruktor (benötigt für den Windows Forms Designer)
        public FormMain()
        {
            InitializeComponent();

            // Falls nicht im Designer zugewiesen, hier verknüpfen:
            dgvClients.CellFormatting += dgvClients_CellFormatting;

        }


        // Überladener Konstruktor, der die Parameter beim Login entgegennimmt
        public FormMain(int userId, string username, string droit) : this()
        {
            this.CurrentUserId = userId;
            this.CurrentUsername = username;
            this.CurrentDroit = droit;

            // Direkt im Konstruktor ausführen:
            ApplyPermissions();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            Anmeldung registrationForm = new Anmeldung();
            registrationForm.Show();
            this.Hide();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ApplyPermissions();
        }

        /* ****************** La fonction qui gère le Rôle des users (utuisateurs) ****************** */
        private void ApplyPermissions()
        {
            // 1. Masquer tous les boutons d'action par défaut (sauf LogOut et Close)
            btn_ReadOnly.Visible = false;
            btn_ReadOnlyUser.Visible = false;

            btn_DeleteClient.Visible = false;
            btn_DeleteUser.Visible = false;

            btn_UpdateClient.Visible = false;
            btn_UpdateUser.Visible = false;

            btn_CreateNewClient.Visible = false;
            btn_CreateNewUser.Visible = false;

            // Assurer que LogOut et Close restent toujours visibles
            btn_LogOut.Visible = true;
            btn_Close.Visible = true; 
            //dgvClients.Visible = false;
            dgvUser.Visible = false;

            // 2. Afficher les boutons selon la valeur de CurrentDroit
            switch (CurrentDroit)
            {
                case "READ_ONLY":
                    btn_ReadOnly.Visible = true;
                    btn_ReadOnlyUser.Visible = false;
                    break;

                case "READ_DELETE":
                    btn_ReadOnly.Visible = true;
                    btn_ReadOnlyUser.Visible = true;
                    btn_DeleteClient.Visible = true;
                    btn_DeleteUser.Visible = true;
                    break;

                case "READ_DELETE_UPDATE":
                    btn_ReadOnly.Visible = true;
                    btn_ReadOnlyUser.Visible = true;
                    btn_DeleteClient.Visible = true;
                    btn_DeleteUser.Visible = true;
                    btn_UpdateClient.Visible = true;
                    btn_UpdateUser.Visible = true;
                    break;

                case "FULL_CLIENT_ACCESS":
                    btn_ReadOnly.Visible = true;
                    btn_ReadOnlyUser.Visible = true;
                    btn_DeleteClient.Visible = true;
                    btn_DeleteUser.Visible = true;
                    btn_UpdateClient.Visible = true;
                    btn_UpdateUser.Visible = true;
                    btn_CreateNewClient.Visible = true;
                    break;

                case "ADMIN":
                    // L'administrateur a accès à tous les boutons
                    btn_ReadOnly.Visible = true;
                    btn_ReadOnlyUser.Visible = true;
                    btn_DeleteClient.Visible = true;
                    btn_DeleteUser.Visible = true;
                    btn_UpdateClient.Visible = true;
                    btn_UpdateUser.Visible = true;
                    btn_CreateNewClient.Visible = true;
                    btn_CreateNewUser.Visible = true;
                    break;

                default:
                    break;
            }
        }

        /* ****************** Lire tous es données de la Table Clients ****************** */
        private void btn_ReadOnly_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    // 1. Récupération des données de la table clients
                    var clientsList = db.VClients.ToList();
                    //var clientsList = db.Clients.ToList();

                    // 2. Liaison des données au DataGridView (ex: dgvClients)
                    dgvClients.DataSource = clientsList;

                    // 3. Verrouillage du DataGridView en mode Lecture Seule
                    ConfigureReadOnlyGrid(dgvClients);

                    // Rendre le DataGridView visible s'il était caché
                    dgvClients.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des clients : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvClients_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            // Prüfen, ob wir in der gewünschten Spalte sind (Spaltenname "Status" oder "is_solde_positif")
            if (dgvClients.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string? statusValue = e.Value.ToString();

                if (statusValue == "Solvable")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.ForeColor = Color.DarkGreen;
                }
                else if (statusValue == "Insolvable")
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.DarkRed;
                }
            }
        }

        private void ConfigureReadOnlyGrid(DataGridView grid)
        {
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToOrderColumns = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /* ****************** Lire tous les données de la Tabele User ****************** */
        private void btn_ReadOnlyUser_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    // 1. Récupération des données de la table clients
                    var usersList = db.Users.ToList();

                    // 2. Liaison des données au DataGridView (ex: dgvClients)
                    dgvUser.DataSource = usersList;

                    // 3. Verrouillage du DataGridView en mode Lecture Seule
                    ConfigureReadOnlyGrid(dgvUser);

                    // Rendre le DataGridView visible s'il était caché
                    dgvUser.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des clients : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbl_Clients_Click(object sender, EventArgs e)
        {

        }

        /* ****************** Efaccer un clein de la base de données ****************** */
        private void btn_DeleteClient_Click(object sender, EventArgs e)
        {
            // Überprüfen, ob eine Zeile im Client-Grid ausgewählt ist
            if (dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie zuerst einen Client aus der Tabelle aus.",
                                "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ausgewählten Client ermitteln
            var selectedClient = dgvClients.SelectedRows[0].DataBoundItem as Client;
            if (selectedClient == null) return;

            // Sicherheitsabfrage
            var confirm = MessageBox.Show($"Möchten Sie den Client '{selectedClient.Nom}' wirklich löschen?",
                                          "Löschen bestätigen",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (var db = new AppDbContext())
                    {
                        var clientInDb = db.Clients.Find(selectedClient.ClientId);
                        if (clientInDb != null)
                        {
                            // 1. Enregistrement de la trace de suppression dans ARCHIVAGE avant le Remove
                            var logAudit = new Archivage
                            {
                                UserId = this.CurrentUserId,
                                DeletedByUserId = this.CurrentUserId,
                                ClientId = clientInDb.ClientId,
                                DeletedAt = DateTime.UtcNow,
                                ActionType = "DELETE_CLIENT",
                                EntityName = "Client",
                                EntityId = clientInDb.ClientId,
                                Details = $"Suppression du client {clientInDb.Nom} {clientInDb.Prenom} par l'utilisateur ID {this.CurrentUserId}"

                            };

                            // 2. Sauvegader la trace dans l archivage
                            db.Archives.Add(logAudit);
                            db.SaveChanges(); // <-- Audit-Log festschreiben

                            // 3. Suppression du client
                            db.Clients.Remove(clientInDb);
                            db.SaveChanges();


                            // 4. Mise à jour de l'affichage
                            dgvClients.DataSource = db.Clients.ToList();
                            MessageBox.Show("Client supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Löschen: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /* ****************** Efaccer un clein de la base de données ****************** */
        private void btn_DeleteUser_Click(object sender, EventArgs e)
        {
            // Überprüfen, ob eine Zeile im User-Grid ausgewählt ist
            if (dgvUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie zuerst einen User aus der Tabelle aus.",
                                "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ausgewählten User ermitteln
            var selectedUser = dgvUser.SelectedRows[0].DataBoundItem as User;
            if (selectedUser == null) return;

            // Sicherheitsabfrage
            var confirm = MessageBox.Show($"Möchten Sie den User '{selectedUser.Username}' wirklich löschen?",
                                          "Löschen bestätigen",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (var db = new AppDbContext())
                    {
                        var userInDb = db.Users.Find(selectedUser.UserId);
                        if (userInDb != null)
                        {
                            // 1. Enregistrement de la trace de suppression dans ARCHIVAGE avant le Remove
                            var logAudit = new Archivage
                            {
                                UserId = this.CurrentUserId,
                                //UserId = userInDb.UserId,
                                DeletedByUserId = this.CurrentUserId,
                                
                                DeletedAt = DateTime.UtcNow,
                                ActionType = "DELETE_User",
                                EntityName = "User",
                                EntityId = userInDb.UserId,
                                Details = $"Suppression dde l´utulisateur (User) {userInDb.Name} {userInDb.FirstName} par l'utilisateur ID {this.CurrentUserId}"

                            };

                            // 2. Sauvegader la trace dans l archivage
                            db.Archives.Add(logAudit);
                            db.SaveChanges(); // <-- Audit-Log festschreiben

                            // 3. Suppression du client
                            db.Users.Remove(userInDb);
                            db.SaveChanges();

                            // 4. Mise à jour de l'affichage (Grid aktualisieren)
                            dgvUser.DataSource = db.Users.ToList();
                            MessageBox.Show("User erfolgreich gelöscht.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Löschen: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_ReadOnly_OneClient_Click(object sender, EventArgs e)
        {
            // 1. Récupération des valeurs saisies dans les TextBox
            string searchClientID = textBox_ClientID.Text.Trim();
            string searchName = textBox_Nom.Text.Trim();
            string searchVorname = textBox_Prenom.Text.Trim();

            try
            {
                using (var db = new AppDbContext())
                {
                    VClient? foundClient = null;

                    // CAS 1 : Recherche prioritaire par ID (ClientId)
                    if (!string.IsNullOrEmpty(searchClientID))
                    {
                        if (int.TryParse(searchClientID, out int searchID))
                        {
                            // Hier VClients statt Clients nutzen
                            foundClient = db.VClients.FirstOrDefault(c => c.ClientId == searchID);
                        }
                        else
                        {
                            MessageBox.Show("L'ID doit être un nombre entier valide.",
                                            "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    // CAS 2 : Recherche par Nom et Prénom
                    else if (!string.IsNullOrEmpty(searchName) && !string.IsNullOrEmpty(searchVorname))
                    {
                        // 1. Suche zuerst NUR nach Nom und Prénom in VClients
                        var clientFoundByName = db.VClients.FirstOrDefault(c =>
                            c.Nom.ToLower() == searchName.ToLower() &&
                            c.Prenom.ToLower() == searchVorname.ToLower());

                        if (clientFoundByName != null)
                        {
                            // 2. Kunde existiert: Prüfe das Geburtsdatum (DateNaissance)
                            if (clientFoundByName.DateNaissance.HasValue &&
                                clientFoundByName.DateNaissance.Value.Date == dtp_BirthDate.Value.Date)
                            {
                                foundClient = clientFoundByName;
                            }
                            else
                            {
                                MessageBox.Show("La date de naissance ne correspond pas à ce nom et prénom.",
                                                "Erreur de date",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Aucun client trouvé avec ce nom et prénom.",
                                            "Introuvable",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez saisir soit un ID, soit le Nom, le Prénom et la date de naissance du client.",
                                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // 2. Affichage des résultats dans le DataGridView
                    if (foundClient != null)
                    {
                        dgvClients.DataSource = new List<VClient> { foundClient };
                        ConfigureReadOnlyGrid(dgvClients); // Zeile hinzufügen
                        dgvClients.ClearSelection();       // Zeile hinzufügen, um blaue Markierung aufzuheben
                        dgvClients.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Aucun client correspondant trouvé dans la base de données.",
                                        "Introuvable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvClients.DataSource = null;
                    }
                }

                // Préparer le champ pour la prochaine lecture RFID (2ème Partie du Projet)
                textBox_ClientID.Focus();
                textBox_ClientID.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la recherche du client : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            /*
            try
            {
                using (var db = new AppDbContext())
                {
                    Client? foundClient = null;

                    // CAS 1 : Recherche prioritaire par ID (ClientId)
                    if (!string.IsNullOrEmpty(searchClientID))
                    {
                        if (int.TryParse(searchClientID, out int searchID))
                        {
                            foundClient = db.Clients.FirstOrDefault(c => c.ClientId == searchID);
                        }
                        else
                        {
                            MessageBox.Show("L'ID doit être un nombre entier valide.",
                                            "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    // CAS 2 : Recherche par Nom et Prénom
                    else if (!string.IsNullOrEmpty(searchName) && !string.IsNullOrEmpty(searchVorname))
                    {
                        // 1. Suche zuerst NUR nach Nom und Prénom
                        var clientFoundByName = db.Clients.FirstOrDefault(c =>
                            c.Nom.ToLower() == searchName.ToLower() &&
                            c.Prenom.ToLower() == searchVorname.ToLower());
                        if (clientFoundByName != null)
                        {
                            // 2. Kunde existiert: Prüfe das Geburtsdatum
                            if (clientFoundByName.DateNaissance.Date == dtp_BirthDate.Value.Date)
                            {
                                foundClient = clientFoundByName;
                            }
                            else
                            {
                                MessageBox.Show("La date de naissance ne correspond pas à ce nom et prénom.",
                                                "Erreur de date",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Aucun client trouvé avec ce nom et prénom.",
                                            "Introuvable",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            return;
                        }


                        // Remarque : Si vous avez un DateTimePicker (ex: dtpDateNaissance), 
                        // vous pouvez ajouter && c.DateNaissance.Date == dtpDateNaissance.Value.Date
                        //   foundClient = db.Clients.FirstOrDefault(c =>
                        //       (c.Nom.ToLower() == searchName.ToLower() &&
                        //        c.Prenom.ToLower() == searchVorname.ToLower()) &&
                        //       c.DateNaissance.Date == dtp_BirthDate.Value.Date);
                        

                    }
                    else
                    {
                        MessageBox.Show("Veuillez saisir soit un ID, soit le Nom, le Prénom et la date de naissance du client.",
                                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // 2. Affichage des résultats dans le DataGridView
                    if (foundClient != null)
                    {
                        dgvClients.DataSource = new List<Client> { foundClient };
                        dgvClients.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Aucun client correspondant trouvé dans la base de données.",
                                        "Introuvable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvClients.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la recherche du client : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }

        /*
         * 2ème Partie du Projet: l'événement KeyDown sur textBox_ClientID permet que, quand la carte est posée sur la lecture RFID, 
         * les rechreches des données du client son automatiquement déclenchées et sont affichées   
         */
        private void textBox_ClientID_KeyDown(object sender, KeyEventArgs e)
        {
            // Le lecteur RFID simule la touche 'Enter' (Entrée) à la fin de la lecture
            if (e.KeyCode == Keys.Enter)
            {
                // Empêche le son "bip" agaçant de Windows
                e.SuppressKeyPress = true;

                // Déclenche automatiquement votre méthode de recherche existante
                btn_ReadOnly_OneClient_Click(sender, e);
            }
        }


        /*
         *          1. Charger les données du DataGridView vers les TextBox (Événement SelectionChanged ou CellClick) 
         *          Lorsque l'utilisateur sélectionne un client dans dgvClients, ses données sont chargées dans 
         *          les champs de saisie pour modification :
         */
        private void dgvClients_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count > 0)
            {
                var selectedClient = dgvClients.SelectedRows[0].DataBoundItem as Client;

                if (selectedClient != null)
                {
                    // Remplissage des champs textuels
                    textBox_ClientID.Text = selectedClient.ClientId.ToString();
                    textBox_Nom.Text = selectedClient.Nom;
                    textBox_Prenom.Text = selectedClient.Prenom;

                    // Formatage de la date dans le TextBox
                    //textBox_DateNaissance.Text = selectedClient.DateNaissance.ToString("yyyy-MM-dd");
                    dtp_BirthDate.Value = selectedClient.DateNaissance;

                    // Directement .ToString() car PayementMensuel n'est pas nullable (pas de .Value)
                    // Remplacez 'textBox_PayementMensuel' par le vrai nom de votre TextBox si besoin
                    textBox_PayementMensuel.Text = selectedClient.PayementMensuel.ToString();
                }
            }
        }


        /* 
         *          Code du bouton "Enregistrer / Mettre à jour" (btn_UpdateClient_Click)
         *          Ce bouton récupère l'ID du client, va le chercher dans la base de données PostgreSQL via 
         *          le DbContext, met à jour ses valeurs et enregistre la transacti}on.
         */
        private void btn_UpdateClient_Click(object sender, EventArgs e)
        {
            // 1. Verification qu'un ID valide est présent
            if (!int.TryParse(textBox_ClientID.Text, out int clientId))
            {
                MessageBox.Show("Veuillez d'abord sélectionner ou chercher un client à modifier.",
                                "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validation des champs obligatoires
            if (string.IsNullOrWhiteSpace(textBox_Nom.Text) || string.IsNullOrWhiteSpace(textBox_Prenom.Text))
            {
                MessageBox.Show("Le Nom et le Prénom ne peuvent pas être vides.",
                                "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    // 3. Recherche de l'enregistrement en base de données
                    var clientToUpdate = db.Clients.FirstOrDefault(c => c.ClientId == clientId);

                    if (clientToUpdate == null)
                    {
                        MessageBox.Show("Le client à modifier n'existe plus dans la base de données.",
                                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 4. Mise à jour des propriétés
                    clientToUpdate.Nom = textBox_Nom.Text.Trim();
                    clientToUpdate.Prenom = textBox_Prenom.Text.Trim();
                    clientToUpdate.DateNaissance = dtp_BirthDate.Value;

                    if (decimal.TryParse(textBox_PayementMensuel.Text, out decimal payement))
                    {
                        clientToUpdate.PayementMensuel = payement;
                    }

                    // Hier die ID des aktuell angemeldeten Benutzers für Nachvollziehbarkeit hinterlegen:

                    // 5. Tracing sur le client
                    clientToUpdate.UserId = this.CurrentUserId; // Ou un champ specifique comme UpdatedByUserId

                    // 6. Sauvegarde des modifications dans PostgreSQ et journalisation dans ARCHIVAGEL 
                    db.SaveChanges();

                    var logAudit = new Archivage
                    {
                        UserId = this.CurrentUserId,
                        ClientId = clientToUpdate.ClientId,
                        CreatedAt = DateTime.UtcNow,
                        ActionType = "UPDATE_CLIENT",
                        EntityName = "Client",
                        EntityId = clientToUpdate.ClientId,
                        Details = $"Modification du client {clientToUpdate.Nom} {clientToUpdate.Prenom} par l'utilisateur ID {this.CurrentUserId}"
                    };

                    // Vérifiez dans AppDbContext si le DbSet s'appelle "Archivages" (au pluriel) ou "Archivage"
                    db.Archives.Add(logAudit);
                    db.SaveChanges();

                    MessageBox.Show("Les modifications ont été enregistrées avec succès !",
                                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 6. Rafraîchissement du DataGridView
                    dgvClients.DataSource = new List<Client> { clientToUpdate };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sauvegarde : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_CreateNewClient_Click(object sender, EventArgs e)
        {
            // Eigenschaft aus FormMain oder UserSession nutzen
            using (FormCreateClient fCreateClient = new FormCreateClient(this.CurrentUserId))
            {
                this.Hide();

                if (fCreateClient.ShowDialog() == DialogResult.OK)
                {
                    using (var db = new AppDbContext())
                    {
                        dgvClients.DataSource = db.Clients.ToList();
                    }
                }
            }
        }

        private void btn_CreateNewUser_Click(object sender, EventArgs e)
        {
            // Eigenschaft aus FormMain oder UserSession nutzen
            using (FormCreateUser fCreateUser = new FormCreateUser(this.CurrentUserId))
            {
                this.Hide();

                if (fCreateUser.ShowDialog() == DialogResult.OK)
                {
                    using (var db = new AppDbContext())
                    {
                        dgvClients.DataSource = db.Users.ToList();
                    }
                }
            }

        }

        private void btn_UpdateUser_Click(object sender, EventArgs e)
        {
           
        }
    }
}
