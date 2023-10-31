
namespace DuAn_QuanLyKPI
{
    partial class Frm_ImportExcel_GUI
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnTaiFile = new DevExpress.XtraEditors.SimpleButton();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnChinhSua = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnGuiDi = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportWord = new DevExpress.XtraEditors.SimpleButton();
            this.btnExxportPDF = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gcData = new DevExpress.XtraGrid.GridControl();
            this.gvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1364, 736);
            this.panel2.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnTaiFile);
            this.panel4.Controls.Add(this.txtPath);
            this.panel4.Controls.Add(this.btnChinhSua);
            this.panel4.Controls.Add(this.labelControl1);
            this.panel4.Controls.Add(this.btnGuiDi);
            this.panel4.Controls.Add(this.btnExportWord);
            this.panel4.Controls.Add(this.btnExxportPDF);
            this.panel4.Controls.Add(this.btnExportExcel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 668);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1364, 68);
            this.panel4.TabIndex = 7;
            // 
            // btnTaiFile
            // 
            this.btnTaiFile.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiFile.Appearance.Options.UseFont = true;
            this.btnTaiFile.ImageOptions.Image = global::DuAn_QuanLyKPI.Properties.Resources.previous_32x32;
            this.btnTaiFile.Location = new System.Drawing.Point(927, 10);
            this.btnTaiFile.Name = "btnTaiFile";
            this.btnTaiFile.Size = new System.Drawing.Size(127, 49);
            this.btnTaiFile.TabIndex = 5;
            this.btnTaiFile.Text = "Tải File lên";
            this.btnTaiFile.Click += new System.EventHandler(this.btnTaiFile_Click_1);
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(497, 18);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(424, 32);
            this.txtPath.TabIndex = 4;
            // 
            // btnChinhSua
            // 
            this.btnChinhSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChinhSua.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChinhSua.Appearance.Options.UseFont = true;
            this.btnChinhSua.ImageOptions.SvgImage = global::DuAn_QuanLyKPI.Properties.Resources.editnames;
            this.btnChinhSua.Location = new System.Drawing.Point(1060, 10);
            this.btnChinhSua.Name = "btnChinhSua";
            this.btnChinhSua.Size = new System.Drawing.Size(122, 49);
            this.btnChinhSua.TabIndex = 10;
            this.btnChinhSua.Text = "Chỉnh sửa";
            this.btnChinhSua.Click += new System.EventHandler(this.btnChinhSua_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(448, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 24);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Path";
            // 
            // btnGuiDi
            // 
            this.btnGuiDi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuiDi.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiDi.Appearance.Options.UseFont = true;
            this.btnGuiDi.ImageOptions.Image = global::DuAn_QuanLyKPI.Properties.Resources.apply_32x32;
            this.btnGuiDi.Location = new System.Drawing.Point(1188, 10);
            this.btnGuiDi.Name = "btnGuiDi";
            this.btnGuiDi.Size = new System.Drawing.Size(164, 49);
            this.btnGuiDi.TabIndex = 9;
            this.btnGuiDi.Text = "Xác nhận gửi đi ";
            this.btnGuiDi.Click += new System.EventHandler(this.btnGuiDi_Click);
            // 
            // btnExportWord
            // 
            this.btnExportWord.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportWord.Appearance.Options.UseFont = true;
            this.btnExportWord.ImageOptions.SvgImage = global::DuAn_QuanLyKPI.Properties.Resources.underlineword;
            this.btnExportWord.Location = new System.Drawing.Point(12, 10);
            this.btnExportWord.Name = "btnExportWord";
            this.btnExportWord.Size = new System.Drawing.Size(141, 49);
            this.btnExportWord.TabIndex = 8;
            this.btnExportWord.Text = "Export Word";
            this.btnExportWord.Click += new System.EventHandler(this.btnExportWord_Click);
            // 
            // btnExxportPDF
            // 
            this.btnExxportPDF.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExxportPDF.Appearance.Options.UseFont = true;
            this.btnExxportPDF.ImageOptions.SvgImage = global::DuAn_QuanLyKPI.Properties.Resources.documentpdf;
            this.btnExxportPDF.Location = new System.Drawing.Point(159, 10);
            this.btnExxportPDF.Name = "btnExxportPDF";
            this.btnExxportPDF.Size = new System.Drawing.Size(133, 49);
            this.btnExxportPDF.TabIndex = 7;
            this.btnExxportPDF.Text = "Export PDF";
            this.btnExxportPDF.Click += new System.EventHandler(this.btnExxportPDF_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Appearance.Options.UseFont = true;
            this.btnExportExcel.ImageOptions.SvgImage = global::DuAn_QuanLyKPI.Properties.Resources.exporttoxlsx;
            this.btnExportExcel.Location = new System.Drawing.Point(298, 10);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(141, 49);
            this.btnExportExcel.TabIndex = 6;
            this.btnExportExcel.Text = "Export Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gcData);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1364, 736);
            this.panel3.TabIndex = 6;
            // 
            // gcData
            // 
            this.gcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcData.Location = new System.Drawing.Point(0, 0);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(1364, 736);
            this.gcData.TabIndex = 0;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // gvData
            // 
            this.gvData.GridControl = this.gcData;
            this.gvData.Name = "gvData";
            this.gvData.OptionsView.ShowGroupPanel = false;
            // 
            // Frm_ImportExcel_GUI
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 736);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Frm_ImportExcel_GUI";
            this.Text = "Import Excel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_ImportExcel_GUI_Load);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SimpleButton btnTaiFile;
        private System.Windows.Forms.TextBox txtPath;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gcData;
        private DevExpress.XtraGrid.Views.Grid.GridView gvData;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraEditors.SimpleButton btnExxportPDF;
        private DevExpress.XtraEditors.SimpleButton btnExportWord;
        private DevExpress.XtraEditors.SimpleButton btnChinhSua;
        private DevExpress.XtraEditors.SimpleButton btnGuiDi;
    }
}