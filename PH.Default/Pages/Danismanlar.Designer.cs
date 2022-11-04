namespace PH.Default.Pages
{
    partial class Danismanlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Danismanlar));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.GRC = new DevExpress.XtraGrid.GridControl();
            this.GRW = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GRC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRW)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton5);
            this.panelControl1.Controls.Add(this.simpleButton4);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 454);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(498, 34);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButton5
            // 
            this.simpleButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton5.ImageOptions.Image")));
            this.simpleButton5.Location = new System.Drawing.Point(23, 7);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(82, 23);
            this.simpleButton5.TabIndex = 13;
            this.simpleButton5.Text = "Kaldır";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.ImageOptions.Image")));
            this.simpleButton4.Location = new System.Drawing.Point(313, 7);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(82, 23);
            this.simpleButton4.TabIndex = 12;
            this.simpleButton4.Text = "Düzenle";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(401, 7);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(82, 23);
            this.simpleButton1.TabIndex = 11;
            this.simpleButton1.Text = "Yeni Ekle";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // GRC
            // 
            this.GRC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GRC.Location = new System.Drawing.Point(0, 0);
            this.GRC.MainView = this.GRW;
            this.GRC.Name = "GRC";
            this.GRC.Size = new System.Drawing.Size(498, 454);
            this.GRC.TabIndex = 62;
            this.GRC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GRW});
            // 
            // GRW
            // 
            this.GRW.Appearance.FocusedCell.BackColor = System.Drawing.Color.Orange;
            this.GRW.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GRW.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.GRW.Appearance.FocusedCell.Options.UseBackColor = true;
            this.GRW.Appearance.FocusedCell.Options.UseFont = true;
            this.GRW.Appearance.FocusedCell.Options.UseForeColor = true;
            this.GRW.Appearance.FocusedRow.BackColor = System.Drawing.Color.Orange;
            this.GRW.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GRW.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.GRW.Appearance.FocusedRow.Options.UseBackColor = true;
            this.GRW.Appearance.FocusedRow.Options.UseFont = true;
            this.GRW.Appearance.FocusedRow.Options.UseForeColor = true;
            this.GRW.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Orange;
            this.GRW.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GRW.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.White;
            this.GRW.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.GRW.Appearance.HideSelectionRow.Options.UseFont = true;
            this.GRW.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.GRW.Appearance.SelectedRow.BackColor = System.Drawing.Color.Orange;
            this.GRW.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GRW.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.GRW.Appearance.SelectedRow.Options.UseBackColor = true;
            this.GRW.Appearance.SelectedRow.Options.UseFont = true;
            this.GRW.Appearance.SelectedRow.Options.UseForeColor = true;
            this.GRW.GridControl = this.GRC;
            this.GRW.Name = "GRW";
            this.GRW.OptionsBehavior.Editable = false;
            this.GRW.OptionsBehavior.ReadOnly = true;
            this.GRW.OptionsFind.AlwaysVisible = true;
            this.GRW.OptionsFind.FindNullPrompt = "";
            this.GRW.OptionsFind.ShowClearButton = false;
            this.GRW.OptionsFind.ShowCloseButton = false;
            this.GRW.OptionsFind.ShowFindButton = false;
            this.GRW.OptionsFind.ShowSearchNavButtons = false;
            this.GRW.OptionsView.ShowFooter = true;
            this.GRW.OptionsView.ShowGroupPanel = false;
            this.GRW.OptionsView.ShowIndicator = false;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(225, 6);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(82, 23);
            this.simpleButton2.TabIndex = 14;
            this.simpleButton2.Text = "İzin Ekle";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // Danismanlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 488);
            this.Controls.Add(this.GRC);
            this.Controls.Add(this.panelControl1);
            this.Name = "Danismanlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danismanlar";
            this.Load += new System.EventHandler(this.Danismanlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GRC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRW)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl GRC;
        private DevExpress.XtraGrid.Views.Grid.GridView GRW;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}