
namespace TRUCKCOY.forms
{
    partial class LoginForm
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
            this.pnlHead = new System.Windows.Forms.Panel();
            this.User = new System.Windows.Forms.TextBox();
            this.InputUser = new System.Windows.Forms.Panel();
            this.InputPass = new System.Windows.Forms.Panel();
            this.Pass = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Tittle = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.ForgotPass = new System.Windows.Forms.Label();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.background = new System.Windows.Forms.PictureBox();
            this.pnlHead.SuspendLayout();
            this.InputUser.SuspendLayout();
            this.InputPass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHead
            // 
            this.pnlHead.BackColor = System.Drawing.Color.White;
            this.pnlHead.Controls.Add(this.ForgotPass);
            this.pnlHead.Controls.Add(this.Password);
            this.pnlHead.Controls.Add(this.Username);
            this.pnlHead.Controls.Add(this.Tittle);
            this.pnlHead.Controls.Add(this.button2);
            this.pnlHead.Controls.Add(this.button1);
            this.pnlHead.Controls.Add(this.Logo);
            this.pnlHead.Controls.Add(this.InputPass);
            this.pnlHead.Controls.Add(this.InputUser);
            this.pnlHead.Controls.Add(this.background);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlHead.Location = new System.Drawing.Point(0, 0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(286, 580);
            this.pnlHead.TabIndex = 0;
            // 
            // User
            // 
            this.User.BackColor = System.Drawing.Color.WhiteSmoke;
            this.User.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.User.Font = new System.Drawing.Font("Gill Sans MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User.ForeColor = System.Drawing.Color.Gray;
            this.User.Location = new System.Drawing.Point(38, 12);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(159, 16);
            this.User.TabIndex = 0;
            this.User.Text = "acr_0291204";
            // 
            // InputUser
            // 
            this.InputUser.BackColor = System.Drawing.Color.Gainsboro;
            this.InputUser.Controls.Add(this.pictureBox1);
            this.InputUser.Controls.Add(this.User);
            this.InputUser.Location = new System.Drawing.Point(42, 240);
            this.InputUser.Name = "InputUser";
            this.InputUser.Size = new System.Drawing.Size(200, 39);
            this.InputUser.TabIndex = 1;
            // 
            // InputPass
            // 
            this.InputPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(165)))), ((int)(((byte)(229)))));
            this.InputPass.Controls.Add(this.pictureBox2);
            this.InputPass.Controls.Add(this.Pass);
            this.InputPass.Location = new System.Drawing.Point(42, 307);
            this.InputPass.Name = "InputPass";
            this.InputPass.Size = new System.Drawing.Size(200, 39);
            this.InputPass.TabIndex = 3;
            // 
            // Pass
            // 
            this.Pass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(165)))), ((int)(((byte)(229)))));
            this.Pass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Pass.Font = new System.Drawing.Font("Gill Sans MT", 9.75F, System.Drawing.FontStyle.Bold);
            this.Pass.ForeColor = System.Drawing.Color.White;
            this.Pass.Location = new System.Drawing.Point(38, 12);
            this.Pass.Name = "Pass";
            this.Pass.PasswordChar = '*';
            this.Pass.Size = new System.Drawing.Size(159, 16);
            this.Pass.TabIndex = 0;
            this.Pass.Text = "acr_0291204";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(42, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 39);
            this.button1.TabIndex = 8;
            this.button1.Text = "Ingresar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(42, 433);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 39);
            this.button2.TabIndex = 9;
            this.button2.Text = "Registrarme";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // Tittle
            // 
            this.Tittle.AutoSize = true;
            this.Tittle.BackColor = System.Drawing.Color.Transparent;
            this.Tittle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Tittle.Font = new System.Drawing.Font("LEMON MILK Bold", 14.25F, System.Drawing.FontStyle.Bold);
            this.Tittle.ForeColor = System.Drawing.Color.White;
            this.Tittle.Location = new System.Drawing.Point(107, 159);
            this.Tittle.Name = "Tittle";
            this.Tittle.Size = new System.Drawing.Size(81, 27);
            this.Tittle.TabIndex = 11;
            this.Tittle.Text = "LOGIN";
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.BackColor = System.Drawing.Color.Transparent;
            this.Username.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.Username.ForeColor = System.Drawing.Color.White;
            this.Username.Location = new System.Drawing.Point(39, 219);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(56, 18);
            this.Username.TabIndex = 12;
            this.Username.Text = "Usuario";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.BackColor = System.Drawing.Color.Transparent;
            this.Password.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.Password.ForeColor = System.Drawing.Color.White;
            this.Password.Location = new System.Drawing.Point(39, 286);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(78, 18);
            this.Password.TabIndex = 13;
            this.Password.Text = "Contraseña";
            // 
            // ForgotPass
            // 
            this.ForgotPass.BackColor = System.Drawing.Color.Transparent;
            this.ForgotPass.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.ForgotPass.ForeColor = System.Drawing.Color.White;
            this.ForgotPass.Location = new System.Drawing.Point(39, 515);
            this.ForgotPass.Name = "ForgotPass";
            this.ForgotPass.Size = new System.Drawing.Size(203, 18);
            this.ForgotPass.TabIndex = 14;
            this.ForgotPass.Text = "¿Olvidaste tu contraseña?";
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.Image = global::TRUCKCOY.Properties.Resources.profile_pic_default;
            this.Logo.Location = new System.Drawing.Point(80, 12);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(132, 127);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 6;
            this.Logo.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TRUCKCOY.Properties.Resources.pass_login_ico;
            this.pictureBox2.Location = new System.Drawing.Point(7, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TRUCKCOY.Properties.Resources.user_login_ico;
            this.pictureBox1.Location = new System.Drawing.Point(7, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // background
            // 
            this.background.Image = global::TRUCKCOY.Properties.Resources._7d060031c60049314536131e18168655;
            this.background.Location = new System.Drawing.Point(-17, 0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(303, 580);
            this.background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.background.TabIndex = 0;
            this.background.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(286, 580);
            this.Controls.Add(this.pnlHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.pnlHead.ResumeLayout(false);
            this.pnlHead.PerformLayout();
            this.InputUser.ResumeLayout(false);
            this.InputUser.PerformLayout();
            this.InputPass.ResumeLayout(false);
            this.InputPass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.Panel InputPass;
        private System.Windows.Forms.TextBox Pass;
        private System.Windows.Forms.Panel InputUser;
        private System.Windows.Forms.TextBox User;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label Tittle;
        private System.Windows.Forms.Label ForgotPass;
    }
}