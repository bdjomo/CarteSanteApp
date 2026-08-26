namespace CarteSanteApp
{
    partial class Anmeldung
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnClose = new Button();
            btn_Registration = new Button();
            lbl_Username = new Label();
            lbl_Password = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Location = new Point(11, 412);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += button1_Click;
            // 
            // btn_Registration
            // 
            btn_Registration.Location = new Point(102, 204);
            btn_Registration.Name = "btn_Registration";
            btn_Registration.Size = new Size(144, 29);
            btn_Registration.TabIndex = 1;
            btn_Registration.Text = "LogIn";
            btn_Registration.UseVisualStyleBackColor = true;
            btn_Registration.Click += btn_Registration_Click;
            // 
            // lbl_Username
            // 
            lbl_Username.AutoSize = true;
            lbl_Username.Location = new Point(30, 54);
            lbl_Username.Name = "lbl_Username";
            lbl_Username.Size = new Size(75, 20);
            lbl_Username.TabIndex = 2;
            lbl_Username.Text = "Username";
            // 
            // lbl_Password
            // 
            lbl_Password.AutoSize = true;
            lbl_Password.Location = new Point(35, 117);
            lbl_Password.Name = "lbl_Password";
            lbl_Password.Size = new Size(70, 20);
            lbl_Password.TabIndex = 3;
            lbl_Password.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(220, 47);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(125, 27);
            txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(220, 114);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 5;
            // 
            // Anmeldung
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lbl_Password);
            Controls.Add(lbl_Username);
            Controls.Add(btn_Registration);
            Controls.Add(btnClose);
            Name = "Anmeldung";
            Text = "Anmeldung";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private Button btn_Registration;
        private Label lbl_Username;
        private Label lbl_Password;
        private TextBox txtUsername;
        private TextBox txtPassword;
    }
}
