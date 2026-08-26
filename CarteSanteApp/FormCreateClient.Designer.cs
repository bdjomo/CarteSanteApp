namespace CarteSanteApp
{
    partial class FormCreateClient
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
            txt_Name = new TextBox();
            txt_Vorname = new TextBox();
            txt_MonthlyPayment = new TextBox();
            txt_CostConsultation = new TextBox();
            btn_Save = new Button();
            dtp_BirthDate = new DateTimePicker();
            btn_LogOut = new Button();
            btn_Close = new Button();
            lbl_Name = new Label();
            lbl_Vorname = new Label();
            lblBirthDate = new Label();
            lbl_MonthlyPayment = new Label();
            lbl_CostOfConsultation = new Label();
            SuspendLayout();
            // 
            // txt_Name
            // 
            txt_Name.Location = new Point(177, 9);
            txt_Name.Name = "txt_Name";
            txt_Name.Size = new Size(250, 27);
            txt_Name.TabIndex = 0;
            // 
            // txt_Vorname
            // 
            txt_Vorname.Location = new Point(177, 62);
            txt_Vorname.Name = "txt_Vorname";
            txt_Vorname.Size = new Size(250, 27);
            txt_Vorname.TabIndex = 1;
            // 
            // txt_MonthlyPayment
            // 
            txt_MonthlyPayment.Location = new Point(177, 169);
            txt_MonthlyPayment.Name = "txt_MonthlyPayment";
            txt_MonthlyPayment.Size = new Size(250, 27);
            txt_MonthlyPayment.TabIndex = 2;
            // 
            // txt_CostConsultation
            // 
            txt_CostConsultation.Location = new Point(177, 219);
            txt_CostConsultation.Name = "txt_CostConsultation";
            txt_CostConsultation.Size = new Size(250, 27);
            txt_CostConsultation.TabIndex = 3;
            // 
            // btn_Save
            // 
            btn_Save.BackColor = SystemColors.ButtonShadow;
            btn_Save.BackgroundImageLayout = ImageLayout.Center;
            btn_Save.Location = new Point(177, 307);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(250, 29);
            btn_Save.TabIndex = 5;
            btn_Save.Text = "Create Client";
            btn_Save.UseVisualStyleBackColor = false;
            btn_Save.Click += btn_Save_Click;
            // 
            // dtp_BirthDate
            // 
            dtp_BirthDate.Location = new Point(177, 118);
            dtp_BirthDate.Name = "dtp_BirthDate";
            dtp_BirthDate.Size = new Size(250, 27);
            dtp_BirthDate.TabIndex = 6;
            // 
            // btn_LogOut
            // 
            btn_LogOut.BackColor = SystemColors.ButtonShadow;
            btn_LogOut.Location = new Point(12, 381);
            btn_LogOut.Name = "btn_LogOut";
            btn_LogOut.Size = new Size(94, 29);
            btn_LogOut.TabIndex = 7;
            btn_LogOut.Text = "LogOut";
            btn_LogOut.UseVisualStyleBackColor = false;
            btn_LogOut.Click += btn_LogOut_Click;
            // 
            // btn_Close
            // 
            btn_Close.BackColor = SystemColors.ButtonShadow;
            btn_Close.Location = new Point(12, 467);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new Size(94, 29);
            btn_Close.TabIndex = 8;
            btn_Close.Text = "Close";
            btn_Close.UseVisualStyleBackColor = false;
            btn_Close.Click += btn_Close_Click;
            // 
            // lbl_Name
            // 
            lbl_Name.AutoSize = true;
            lbl_Name.Location = new Point(99, 16);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Size = new Size(49, 20);
            lbl_Name.TabIndex = 9;
            lbl_Name.Text = "Name";
            // 
            // lbl_Vorname
            // 
            lbl_Vorname.AutoSize = true;
            lbl_Vorname.Location = new Point(99, 69);
            lbl_Vorname.Name = "lbl_Vorname";
            lbl_Vorname.Size = new Size(68, 20);
            lbl_Vorname.TabIndex = 10;
            lbl_Vorname.Text = "Vorname";
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Location = new Point(99, 125);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(68, 20);
            lblBirthDate.TabIndex = 11;
            lblBirthDate.Text = "Birth day";
            // 
            // lbl_MonthlyPayment
            // 
            lbl_MonthlyPayment.AutoSize = true;
            lbl_MonthlyPayment.Location = new Point(44, 176);
            lbl_MonthlyPayment.Name = "lbl_MonthlyPayment";
            lbl_MonthlyPayment.Size = new Size(123, 20);
            lbl_MonthlyPayment.TabIndex = 12;
            lbl_MonthlyPayment.Text = "Monthly Payment";
            // 
            // lbl_CostOfConsultation
            // 
            lbl_CostOfConsultation.AutoSize = true;
            lbl_CostOfConsultation.Location = new Point(1, 222);
            lbl_CostOfConsultation.Name = "lbl_CostOfConsultation";
            lbl_CostOfConsultation.Size = new Size(166, 20);
            lbl_CostOfConsultation.TabIndex = 13;
            lbl_CostOfConsultation.Text = "Cost of the consultation";
            // 
            // FormCreateClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(877, 508);
            Controls.Add(lbl_CostOfConsultation);
            Controls.Add(lbl_MonthlyPayment);
            Controls.Add(lblBirthDate);
            Controls.Add(lbl_Vorname);
            Controls.Add(lbl_Name);
            Controls.Add(btn_Close);
            Controls.Add(btn_LogOut);
            Controls.Add(dtp_BirthDate);
            Controls.Add(btn_Save);
            Controls.Add(txt_CostConsultation);
            Controls.Add(txt_MonthlyPayment);
            Controls.Add(txt_Vorname);
            Controls.Add(txt_Name);
            Name = "FormCreateClient";
            Text = "FormCreateClient";
            Load += FormCreateClient_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Name;
        private TextBox txt_Vorname;
        private TextBox txt_MonthlyPayment;
        private TextBox txt_CostConsultation;
       // private TextBox textBox5;
        private Button btn_Save;
        private DateTimePicker dtp_BirthDate;
        private Button btn_LogOut;
        private Button btn_Close;
        private Label lbl_Name;
        private Label lbl_Vorname;
        private Label lblBirthDate;
        private Label lbl_MonthlyPayment;
        private Label lbl_CostOfConsultation;
        //private Label label6;
    }
}