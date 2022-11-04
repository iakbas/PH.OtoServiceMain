namespace PH.Default.Pages.Modals
{
    partial class DanismanForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DanismanForm));
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions3 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.txtUnvani = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtKodu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbRenkSecim = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.GRC = new DevExpress.XtraGrid.GridControl();
            this.GRW = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnvani.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRenkSecim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GRC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRW)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 371);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(545, 33);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(458, 5);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 23);
            this.simpleButton3.TabIndex = 6;
            this.simpleButton3.Text = "Kaydet";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // txtUnvani
            // 
            this.txtUnvani.Location = new System.Drawing.Point(84, 41);
            this.txtUnvani.Name = "txtUnvani";
            this.txtUnvani.Size = new System.Drawing.Size(446, 20);
            this.txtUnvani.TabIndex = 42;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(30, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 13);
            this.labelControl2.TabIndex = 41;
            this.labelControl2.Text = "Ünvanı";
            // 
            // txtKodu
            // 
            this.txtKodu.Location = new System.Drawing.Point(84, 12);
            this.txtKodu.Name = "txtKodu";
            this.txtKodu.Size = new System.Drawing.Size(102, 20);
            this.txtKodu.TabIndex = 40;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 13);
            this.labelControl1.TabIndex = 39;
            this.labelControl1.Text = "Kodu";
            // 
            // cmbRenkSecim
            // 
            this.cmbRenkSecim.Location = new System.Drawing.Point(84, 67);
            this.cmbRenkSecim.Name = "cmbRenkSecim";
            this.cmbRenkSecim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRenkSecim.Properties.DropDownRows = 10;
            this.cmbRenkSecim.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Renk-1", 1, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Renk-2", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Renk-3", 3, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Renk-4", 4, 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Renk-5", 5, 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Renk-6", 6, 5),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Renk-7", 7, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Renk-8", 8, 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Renk-9", 9, 8),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Renk-10", 10, 9)});
            this.cmbRenkSecim.Properties.SmallImages = this.imageList1;
            this.cmbRenkSecim.Size = new System.Drawing.Size(100, 20);
            this.cmbRenkSecim.TabIndex = 45;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "re1.png");
            this.imageList1.Images.SetKeyName(1, "Re2.png");
            this.imageList1.Images.SetKeyName(2, "re3.png");
            this.imageList1.Images.SetKeyName(3, "re4.png");
            this.imageList1.Images.SetKeyName(4, "re5.png");
            this.imageList1.Images.SetKeyName(5, "re6.png");
            this.imageList1.Images.SetKeyName(6, "re7.png");
            this.imageList1.Images.SetKeyName(7, "re8.png");
            this.imageList1.Images.SetKeyName(8, "re9.png");
            this.imageList1.Images.SetKeyName(9, "re10.png");
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(28, 70);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 13);
            this.labelControl4.TabIndex = 46;
            this.labelControl4.Text = "Renk";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.GRC);
            this.groupControl1.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Yeni İzin", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Düzenle", true, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("İptal", true, buttonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1)});
            this.groupControl1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 100);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(545, 271);
            this.groupControl1.TabIndex = 47;
            this.groupControl1.Text = "İzinler";
            this.groupControl1.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.groupControl1_CustomButtonClick);
            // 
            // GRC
            // 
            this.GRC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GRC.Location = new System.Drawing.Point(2, 23);
            this.GRC.MainView = this.GRW;
            this.GRC.Name = "GRC";
            this.GRC.Size = new System.Drawing.Size(541, 246);
            this.GRC.TabIndex = 4;
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
            this.GRW.OptionsFind.FindNullPrompt = "";
            this.GRW.OptionsFind.ShowClearButton = false;
            this.GRW.OptionsFind.ShowCloseButton = false;
            this.GRW.OptionsFind.ShowFindButton = false;
            this.GRW.OptionsFind.ShowSearchNavButtons = false;
            this.GRW.OptionsView.ShowGroupPanel = false;
            this.GRW.OptionsView.ShowIndicator = false;
            // 
            // DanismanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 404);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.cmbRenkSecim);
            this.Controls.Add(this.txtUnvani);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtKodu);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DanismanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danisman Form";
            this.Load += new System.EventHandler(this.DanismanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUnvani.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKodu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRenkSecim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GRC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRW)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.TextEdit txtUnvani;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtKodu;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ImageComboBoxEdit cmbRenkSecim;
        private ImageList imageList1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl GRC;
        private DevExpress.XtraGrid.Views.Grid.GridView GRW;
    }
}