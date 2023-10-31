
namespace DuAn_QuanLyKPI.GUI
{
    partial class FrmDangNhapTest
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
            this.txtUsername = new ControlProject1510.XFilteg();
            this.txtPassword = new ControlProject1510.XFilteg();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(564, 49);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 29);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Text = "kha";
            this.txtUsername.xCoTimMoRong = false;
            this.txtUsername.xDataGrid = null;
            this.txtUsername.xField_Key = "";
            this.txtUsername.xKeep_Old_Value = false;
            this.txtUsername.xTimChinhXac = false;
            this.txtUsername.xTimMoRong = "";
            this.txtUsername.xTimTrenField = null;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(564, 103);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 29);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "1";
            this.txtPassword.xCoTimMoRong = false;
            this.txtPassword.xDataGrid = null;
            this.txtPassword.xField_Key = "";
            this.txtPassword.xKeep_Old_Value = false;
            this.txtPassword.xTimChinhXac = false;
            this.txtPassword.xTimMoRong = "";
            this.txtPassword.xTimTrenField = null;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(555, 159);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(127, 54);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // FrmDangNhapTest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmDangNhapTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDangNhapTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlProject1510.XFilteg txtUsername;
        private ControlProject1510.XFilteg txtPassword;
        private System.Windows.Forms.Button btnLogin;
    }
}