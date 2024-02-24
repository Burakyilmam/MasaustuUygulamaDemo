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
            SuspendLayout();
            // 
            // UsernameTxt
            // 
            UsernameTxt.Location = new Point(286, 104);
            UsernameTxt.Name = "UsernameTxt";
            UsernameTxt.Size = new Size(163, 27);
            UsernameTxt.TabIndex = 0;
            // 
            // LoginBtn
            // 
            LoginBtn.Location = new Point(322, 206);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(94, 29);
            LoginBtn.TabIndex = 1;
            LoginBtn.Text = "Giriş Yap";
            LoginBtn.UseVisualStyleBackColor = true;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // PasswordTxt
            // 
            PasswordTxt.Location = new Point(286, 153);
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.Size = new Size(163, 27);
            PasswordTxt.TabIndex = 2;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PasswordTxt);
            Controls.Add(LoginBtn);
            Controls.Add(UsernameTxt);
            Name = "Login";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UsernameTxt;
        private Button LoginBtn;
        private TextBox PasswordTxt;
    }
}
