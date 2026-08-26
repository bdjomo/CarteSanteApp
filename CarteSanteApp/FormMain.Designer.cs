namespace CarteSanteApp
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_Close = new Button();
            btn_ReadOnly = new Button();
            btn_DeleteClient = new Button();
            btn_UpdateClient = new Button();
            btn_CreateNewUser = new Button();
            btn_CreateNewClient = new Button();
            btn_LogOut = new Button();
            dgvClients = new DataGridView();
            dgvUser = new DataGridView();
            btn_ReadOnlyUser = new Button();
            btn_DeleteUser = new Button();
            btn_UpdateUser = new Button();
            lbl_Clients = new Label();
            lbl_Users = new Label();
            btn_ReadOnly_OneClient = new Button();
            textBox_ClientID = new TextBox();
            textBox_Nom = new TextBox();
            textBox_Prenom = new TextBox();
            lbl_ClientID = new Label();
            lbl_DateNaissance = new Label();
            lbl_Nom = new Label();
            lbl_Prenom = new Label();
            textBox_PayementMensuel = new TextBox();
            lbl_payementMensuel = new Label();
            dtp_BirthDate = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUser).BeginInit();
            SuspendLayout();
            // 
            // btn_Close
            // 
            btn_Close.Location = new Point(12, 666);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new Size(160, 29);
            btn_Close.TabIndex = 0;
            btn_Close.Text = "Close";
            btn_Close.UseVisualStyleBackColor = true;
            btn_Close.Click += btn_Close_Click;
            // 
            // btn_ReadOnly
            // 
            btn_ReadOnly.Location = new Point(12, 15);
            btn_ReadOnly.Name = "btn_ReadOnly";
            btn_ReadOnly.Size = new Size(160, 29);
            btn_ReadOnly.TabIndex = 1;
            btn_ReadOnly.Text = "Read Only All Clients";
            btn_ReadOnly.UseVisualStyleBackColor = true;
            btn_ReadOnly.Click += btn_ReadOnly_Click;
            // 
            // btn_DeleteClient
            // 
            btn_DeleteClient.Location = new Point(12, 209);
            btn_DeleteClient.Name = "btn_DeleteClient";
            btn_DeleteClient.Size = new Size(160, 29);
            btn_DeleteClient.TabIndex = 2;
            btn_DeleteClient.Text = "Delete Client";
            btn_DeleteClient.UseVisualStyleBackColor = true;
            btn_DeleteClient.Click += btn_DeleteClient_Click;
            // 
            // btn_UpdateClient
            // 
            btn_UpdateClient.Location = new Point(12, 337);
            btn_UpdateClient.Name = "btn_UpdateClient";
            btn_UpdateClient.Size = new Size(160, 29);
            btn_UpdateClient.TabIndex = 3;
            btn_UpdateClient.Text = "Update Client";
            btn_UpdateClient.UseVisualStyleBackColor = true;
            btn_UpdateClient.Click += btn_UpdateClient_Click;
            // 
            // btn_CreateNewUser
            // 
            btn_CreateNewUser.Location = new Point(12, 535);
            btn_CreateNewUser.Name = "btn_CreateNewUser";
            btn_CreateNewUser.Size = new Size(160, 29);
            btn_CreateNewUser.TabIndex = 4;
            btn_CreateNewUser.Text = "Create User";
            btn_CreateNewUser.UseVisualStyleBackColor = true;
            btn_CreateNewUser.Click += btn_CreateNewUser_Click;
            // 
            // btn_CreateNewClient
            // 
            btn_CreateNewClient.Location = new Point(12, 465);
            btn_CreateNewClient.Name = "btn_CreateNewClient";
            btn_CreateNewClient.Size = new Size(160, 29);
            btn_CreateNewClient.TabIndex = 5;
            btn_CreateNewClient.Text = "Create Client";
            btn_CreateNewClient.UseVisualStyleBackColor = true;
            btn_CreateNewClient.Click += btn_CreateNewClient_Click;
            // 
            // btn_LogOut
            // 
            btn_LogOut.Location = new Point(12, 598);
            btn_LogOut.Name = "btn_LogOut";
            btn_LogOut.Size = new Size(160, 29);
            btn_LogOut.TabIndex = 6;
            btn_LogOut.Text = "LogOut";
            btn_LogOut.UseVisualStyleBackColor = true;
            btn_LogOut.Click += btn_LogOut_Click;
            // 
            // dgvClients
            // 
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(190, 60);
            dgvClients.Name = "dgvClients";
            dgvClients.RowHeadersWidth = 51;
            dgvClients.Size = new Size(927, 372);
            dgvClients.TabIndex = 7;
            dgvClients.SelectionChanged += dgvClients_SelectionChanged;
            // 
            // dgvUser
            // 
            dgvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUser.Location = new Point(1133, 60);
            dgvUser.Name = "dgvUser";
            dgvUser.RowHeadersWidth = 51;
            dgvUser.Size = new Size(736, 372);
            dgvUser.TabIndex = 8;
            // 
            // btn_ReadOnlyUser
            // 
            btn_ReadOnlyUser.Location = new Point(12, 142);
            btn_ReadOnlyUser.Name = "btn_ReadOnlyUser";
            btn_ReadOnlyUser.Size = new Size(160, 29);
            btn_ReadOnlyUser.TabIndex = 9;
            btn_ReadOnlyUser.Text = "Read Only User";
            btn_ReadOnlyUser.UseVisualStyleBackColor = true;
            btn_ReadOnlyUser.Click += btn_ReadOnlyUser_Click;
            // 
            // btn_DeleteUser
            // 
            btn_DeleteUser.Location = new Point(12, 273);
            btn_DeleteUser.Name = "btn_DeleteUser";
            btn_DeleteUser.Size = new Size(160, 29);
            btn_DeleteUser.TabIndex = 10;
            btn_DeleteUser.Text = "Delete User";
            btn_DeleteUser.UseVisualStyleBackColor = true;
            btn_DeleteUser.Click += btn_DeleteUser_Click;
            // 
            // btn_UpdateUser
            // 
            btn_UpdateUser.Location = new Point(12, 403);
            btn_UpdateUser.Name = "btn_UpdateUser";
            btn_UpdateUser.Size = new Size(160, 29);
            btn_UpdateUser.TabIndex = 11;
            btn_UpdateUser.Text = "Update User";
            btn_UpdateUser.UseVisualStyleBackColor = true;
            btn_UpdateUser.Click += btn_UpdateUser_Click;
            // 
            // lbl_Clients
            // 
            lbl_Clients.AutoSize = true;
            lbl_Clients.Location = new Point(460, 20);
            lbl_Clients.Name = "lbl_Clients";
            lbl_Clients.Size = new Size(53, 20);
            lbl_Clients.TabIndex = 16;
            lbl_Clients.Text = "Clients";
            lbl_Clients.Click += lbl_Clients_Click;
            // 
            // lbl_Users
            // 
            lbl_Users.AutoSize = true;
            lbl_Users.Location = new Point(1379, 30);
            lbl_Users.Name = "lbl_Users";
            lbl_Users.Size = new Size(44, 20);
            lbl_Users.TabIndex = 17;
            lbl_Users.Text = "Users";
            // 
            // btn_ReadOnly_OneClient
            // 
            btn_ReadOnly_OneClient.Location = new Point(516, 622);
            btn_ReadOnly_OneClient.Name = "btn_ReadOnly_OneClient";
            btn_ReadOnly_OneClient.Size = new Size(160, 29);
            btn_ReadOnly_OneClient.TabIndex = 18;
            btn_ReadOnly_OneClient.Text = "Read Only One Client";
            btn_ReadOnly_OneClient.UseVisualStyleBackColor = true;
            btn_ReadOnly_OneClient.Click += btn_ReadOnly_OneClient_Click;
            // 
            // textBox_ClientID
            // 
            textBox_ClientID.Location = new Point(379, 472);
            textBox_ClientID.Name = "textBox_ClientID";
            textBox_ClientID.Size = new Size(250, 27);
            textBox_ClientID.TabIndex = 19;
            // 
            // textBox_Nom
            // 
            textBox_Nom.Location = new Point(773, 483);
            textBox_Nom.Name = "textBox_Nom";
            textBox_Nom.Size = new Size(250, 27);
            textBox_Nom.TabIndex = 20;
            // 
            // textBox_Prenom
            // 
            textBox_Prenom.Location = new Point(773, 522);
            textBox_Prenom.Name = "textBox_Prenom";
            textBox_Prenom.Size = new Size(250, 27);
            textBox_Prenom.TabIndex = 21;
            // 
            // lbl_ClientID
            // 
            lbl_ClientID.AutoSize = true;
            lbl_ClientID.Location = new Point(306, 476);
            lbl_ClientID.Name = "lbl_ClientID";
            lbl_ClientID.Size = new Size(62, 20);
            lbl_ClientID.TabIndex = 23;
            lbl_ClientID.Text = "ClientID";
            // 
            // lbl_DateNaissance
            // 
            lbl_DateNaissance.AutoSize = true;
            lbl_DateNaissance.Location = new Point(236, 526);
            lbl_DateNaissance.Name = "lbl_DateNaissance";
            lbl_DateNaissance.Size = new Size(132, 20);
            lbl_DateNaissance.TabIndex = 24;
            lbl_DateNaissance.Text = "Date de Naissance";
            // 
            // lbl_Nom
            // 
            lbl_Nom.AutoSize = true;
            lbl_Nom.Location = new Point(724, 483);
            lbl_Nom.Name = "lbl_Nom";
            lbl_Nom.Size = new Size(42, 20);
            lbl_Nom.TabIndex = 25;
            lbl_Nom.Text = "Nom";
            // 
            // lbl_Prenom
            // 
            lbl_Prenom.AutoSize = true;
            lbl_Prenom.Location = new Point(706, 526);
            lbl_Prenom.Name = "lbl_Prenom";
            lbl_Prenom.Size = new Size(60, 20);
            lbl_Prenom.TabIndex = 26;
            lbl_Prenom.Text = "Prénom";
            // 
            // textBox_PayementMensuel
            // 
            textBox_PayementMensuel.Location = new Point(1188, 482);
            textBox_PayementMensuel.Name = "textBox_PayementMensuel";
            textBox_PayementMensuel.Size = new Size(250, 27);
            textBox_PayementMensuel.TabIndex = 27;
            // 
            // lbl_payementMensuel
            // 
            lbl_payementMensuel.AutoSize = true;
            lbl_payementMensuel.Location = new Point(1045, 486);
            lbl_payementMensuel.Name = "lbl_payementMensuel";
            lbl_payementMensuel.Size = new Size(132, 20);
            lbl_payementMensuel.TabIndex = 28;
            lbl_payementMensuel.Text = "Payement Mensuel";
            // 
            // dtp_BirthDate
            // 
            dtp_BirthDate.Location = new Point(379, 522);
            dtp_BirthDate.Name = "dtp_BirthDate";
            dtp_BirthDate.Size = new Size(250, 27);
            dtp_BirthDate.TabIndex = 29;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1881, 707);
            Controls.Add(dtp_BirthDate);
            Controls.Add(lbl_payementMensuel);
            Controls.Add(textBox_PayementMensuel);
            Controls.Add(lbl_Prenom);
            Controls.Add(lbl_Nom);
            Controls.Add(lbl_DateNaissance);
            Controls.Add(lbl_ClientID);
            Controls.Add(textBox_Prenom);
            Controls.Add(textBox_Nom);
            Controls.Add(textBox_ClientID);
            Controls.Add(btn_ReadOnly_OneClient);
            Controls.Add(lbl_Users);
            Controls.Add(lbl_Clients);
            Controls.Add(btn_UpdateUser);
            Controls.Add(btn_DeleteUser);
            Controls.Add(btn_ReadOnlyUser);
            Controls.Add(dgvUser);
            Controls.Add(dgvClients);
            Controls.Add(btn_LogOut);
            Controls.Add(btn_CreateNewClient);
            Controls.Add(btn_CreateNewUser);
            Controls.Add(btn_UpdateClient);
            Controls.Add(btn_DeleteClient);
            Controls.Add(btn_ReadOnly);
            Controls.Add(btn_Close);
            Name = "FormMain";
            Text = "FormMain";
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUser).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Close;
        private Button btn_ReadOnly;
        private Button btn_DeleteClient;
        private Button btn_UpdateClient;
        private Button btn_CreateNewUser;
        private Button btn_CreateNewClient;
        private Button btn_LogOut;
        private DataGridView dgvClients;
        private DataGridView dgvUser;
        private Button btn_ReadOnlyUser;
        private Button btn_DeleteUser;
        private Button btn_UpdateUser;
        private Label lbl_Clients;
        private Label lbl_Users;
        private Button btn_ReadOnly_OneClient;
        private TextBox textBox_ClientID;
        private TextBox textBox_Nom;
        private TextBox textBox_Prenom;
        private Label lbl_ClientID;
        private Label lbl_DateNaissance;
        private Label lbl_Nom;
        private Label lbl_Prenom;
        private TextBox textBox_PayementMensuel;
        private Label lbl_payementMensuel;
        private DateTimePicker dtp_BirthDate;
    }
}