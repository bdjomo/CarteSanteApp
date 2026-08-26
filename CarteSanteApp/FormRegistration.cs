using System.Text;

namespace CarteSanteApp
{
    public partial class Anmeldung : Form
    {
        public Anmeldung()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Registration_Click(object sender, EventArgs e)
        {
            // Créer une instance de la deuxième fenêtre
            //FormMain mainForm = new FormMain();

            // Afficher la nouvelle fenêtre
            //mainForm.Show();

            // Masquer la fenêtre de connexion actuelle (optionnel)
            //this.Hide();

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    // Login-Prüfung mit Entity Framework Core (LINQ)
                    var user = db.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == password);

                    if (user != null)
                    {
                        MessageBox.Show($"Bienvenue {user.Username} !\nPrivilège : {user.Droit}", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        FormMain mainForm = new FormMain(user.UserId, user.Username, user.Droit);

                        // Wenn FormMain geschlossen wird, die Anmeldung (und die Anwendung) komplett schließen
                        mainForm.FormClosed += (s, args) => this.Close();

                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de connexion DB :\n{ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
