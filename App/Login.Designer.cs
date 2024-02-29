namespace App
{
    partial class Login
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
            UsernameTxt = new TextBox();
            LoginBtn = new Button();
            PasswordTxt = new TextBox();
            lblUsername = new Label();
            lblPassword = new Label();
            SuspendLayout();
            // 
            // UsernameTxt
            // 
            UsernameTxt.Location = new Point(97, 77);
            UsernameTxt.Name = "UsernameTxt";
            UsernameTxt.Size = new Size(163, 27);
            UsernameTxt.TabIndex = 0;
            // 
            // LoginBtn
            // 
            LoginBtn.Location = new Point(120, 180);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(94, 29);
            LoginBtn.TabIndex = 1;
            LoginBtn.Text = "Giriş Yap";
            LoginBtn.UseVisualStyleBackColor = true;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // PasswordTxt
            // 
            PasswordTxt.Location = new Point(97, 132);
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.Size = new Size(163, 27);
            PasswordTxt.TabIndex = 2;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(97, 54);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(92, 20);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Kullanıcı Adı";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(97, 109);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(50, 20);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Parola";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(367, 246);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(PasswordTxt);
            Controls.Add(LoginBtn);
            Controls.Add(UsernameTxt);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UsernameTxt;
        private Button LoginBtn;
        private TextBox PasswordTxt;
        private Label lblUsername;
        private Label lblPassword;
    }
}
