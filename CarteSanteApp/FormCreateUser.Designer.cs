namespace CarteSanteApp
{
    partial class FormCreateUser
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
            lbl_Username = new Label();
            lbl_Password = new Label();
            lbl_Nom = new Label();
            lbl_Prenom = new Label();
            lbl_Email = new Label();
            lbl_Role = new Label();
            txt_Username = new TextBox();
            txt_Password = new TextBox();
            txt_Name = new TextBox();
            txt_Firstname = new TextBox();
            txt_Email = new TextBox();
            txt_Role = new TextBox();
            btn_Close = new Button();
            btn_LogOut = new Button();
            btn_CreateUser = new Button();
            SuspendLayout();
            // 
            // lbl_Username
            // 
            lbl_Username.AutoSize = true;
            lbl_Username.Location = new Point(15, 25);
            lbl_Username.Name = "lbl_Username";
            lbl_Username.Size = new Size(79, 20);
            lbl_Username.TabIndex = 0;
            lbl_Username.Text = "Username ";
            // 
            // lbl_Password
            // 
            lbl_Password.AutoSize = true;
            lbl_Password.Location = new Point(15, 71);
            lbl_Password.Name = "lbl_Password";
            lbl_Password.Size = new Size(70, 20);
            lbl_Password.TabIndex = 1;
            lbl_Password.Text = "Password";
            // 
            // lbl_Nom
            // 
            lbl_Nom.AutoSize = true;
            lbl_Nom.Location = new Point(15, 118);
            lbl_Nom.Name = "lbl_Nom";
            lbl_Nom.Size = new Size(42, 20);
            lbl_Nom.TabIndex = 2;
            lbl_Nom.Text = "Nom";
            // 
            // lbl_Prenom
            // 
            lbl_Prenom.AutoSize = true;
            lbl_Prenom.Location = new Point(15, 165);
            lbl_Prenom.Name = "lbl_Prenom";
            lbl_Prenom.Size = new Size(60, 20);
            lbl_Prenom.TabIndex = 3;
            lbl_Prenom.Text = "Prenom";
            // 
            // lbl_Email
            // 
            lbl_Email.AutoSize = true;
            lbl_Email.Location = new Point(12, 210);
            lbl_Email.Name = "lbl_Email";
            lbl_Email.Size = new Size(52, 20);
            lbl_Email.TabIndex = 4;
            lbl_Email.Text = "E-Mail";
            // 
            // lbl_Role
            // 
            lbl_Role.AutoSize = true;
            lbl_Role.Location = new Point(15, 260);
            lbl_Role.Name = "lbl_Role";
            lbl_Role.Size = new Size(56, 20);
            lbl_Role.TabIndex = 5;
            lbl_Role.Text = "Rôle Id";
            // 
            // txt_Username
            // 
            txt_Username.Location = new Point(145, 25);
            txt_Username.Name = "txt_Username";
            txt_Username.Size = new Size(125, 27);
            txt_Username.TabIndex = 6;
            // 
            // txt_Password
            // 
            txt_Password.Location = new Point(145, 71);
            txt_Password.Name = "txt_Password";
            txt_Password.Size = new Size(125, 27);
            txt_Password.TabIndex = 7;
            // 
            // txt_Name
            // 
            txt_Name.Location = new Point(145, 118);
            txt_Name.Name = "txt_Name";
            txt_Name.Size = new Size(125, 27);
            txt_Name.TabIndex = 8;
            // 
            // txt_Firstname
            // 
            txt_Firstname.Location = new Point(145, 165);
            txt_Firstname.Name = "txt_Firstname";
            txt_Firstname.Size = new Size(125, 27);
            txt_Firstname.TabIndex = 9;
            // 
            // txt_Email
            // 
            txt_Email.Location = new Point(145, 210);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(125, 27);
            txt_Email.TabIndex = 10;
            // 
            // txt_Role
            // 
            txt_Role.Location = new Point(145, 253);
            txt_Role.Name = "txt_Role";
            txt_Role.Size = new Size(125, 27);
            txt_Role.TabIndex = 11;
            // 
            // btn_Close
            // 
            btn_Close.BackColor = SystemColors.GradientActiveCaption;
            btn_Close.Location = new Point(12, 409);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new Size(94, 29);
            btn_Close.TabIndex = 12;
            btn_Close.Text = "Close";
            btn_Close.UseVisualStyleBackColor = false;
            btn_Close.Click += btn_Close_Click;
            // 
            // btn_LogOut
            // 
            btn_LogOut.BackColor = SystemColors.GradientActiveCaption;
            btn_LogOut.ForeColor = SystemColors.ActiveCaptionText;
            btn_LogOut.Location = new Point(15, 362);
            btn_LogOut.Name = "btn_LogOut";
            btn_LogOut.Size = new Size(91, 29);
            btn_LogOut.TabIndex = 13;
            btn_LogOut.Text = "Log Out";
            btn_LogOut.UseVisualStyleBackColor = false;
            // 
            // btn_CreateUser
            // 
            btn_CreateUser.BackColor = SystemColors.GradientActiveCaption;
            btn_CreateUser.ForeColor = SystemColors.Desktop;
            btn_CreateUser.Location = new Point(145, 315);
            btn_CreateUser.Name = "btn_CreateUser";
            btn_CreateUser.Size = new Size(125, 29);
            btn_CreateUser.TabIndex = 14;
            btn_CreateUser.Text = "Create User";
            btn_CreateUser.UseVisualStyleBackColor = false;
            btn_CreateUser.Click += btn_CreateUser_Click;
            // 
            // FormCreateUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_CreateUser);
            Controls.Add(btn_LogOut);
            Controls.Add(btn_Close);
            Controls.Add(txt_Role);
            Controls.Add(txt_Email);
            Controls.Add(txt_Firstname);
            Controls.Add(txt_Name);
            Controls.Add(txt_Password);
            Controls.Add(txt_Username);
            Controls.Add(lbl_Role);
            Controls.Add(lbl_Email);
            Controls.Add(lbl_Prenom);
            Controls.Add(lbl_Nom);
            Controls.Add(lbl_Password);
            Controls.Add(lbl_Username);
            Name = "FormCreateUser";
            Text = "FormCreateUser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Username;
        private Label lbl_Password;
        private Label lbl_Nom;
        private Label lbl_Prenom;
        private Label lbl_Email;
        private Label lbl_Role;
        private TextBox txt_Username;
        private TextBox txt_Password;
        private TextBox txt_Name;
        private TextBox txt_Firstname;
        private TextBox txt_Email;
        private TextBox txt_Role;
        private Button btn_Close;
        private Button btn_LogOut;
        private Button btn_CreateUser;
    }
}