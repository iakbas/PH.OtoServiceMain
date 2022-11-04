namespace PH.Default.Pages
{
    partial class Aramalar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aramalar));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.dt2 = new DevExpress.XtraEditors.DateEdit();
            this.dt1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.GRC = new DevExpress.XtraGrid.GridControl();
            this.GRW = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yeniEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.güncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRW)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton3);
            this.panelControl1.Controls.Add(this.dt2);
            this.panelControl1.Controls.Add(this.dt1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(883, 46);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(367, 11);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 23);
            this.simpleButton3.TabIndex = 6;
            this.simpleButton3.Text = "Ara";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // dt2
            // 
            this.dt2.EditValue = null;
            this.dt2.Location = new System.Drawing.Point(248, 13);
            this.dt2.Name = "dt2";
            this.dt2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dt2.Size = new System.Drawing.Size(100, 20);
            this.dt2.TabIndex = 3;
            // 
            // dt1
            // 
            this.dt1.EditValue = null;
            this.dt1.Location = new System.Drawing.Point(92, 12);
            this.dt1.Name = "dt1";
            this.dt1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dt1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dt1.Size = new System.Drawing.Size(100, 20);
            this.dt1.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(213, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(19, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Bitiş";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(33, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Başlangıç";
            // 
            // GRC
            // 
            this.GRC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GRC.Location = new System.Drawing.Point(0, 46);
            this.GRC.MainView = this.GRW;
            this.GRC.Name = "GRC";
            this.GRC.Size = new System.Drawing.Size(883, 448);
            this.GRC.TabIndex = 3;
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
            this.GRW.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.GRW_PopupMenuShowing);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniEkleToolStripMenuItem,
            this.güncelleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 48);
            // 
            // yeniEkleToolStripMenuItem
            // 
            this.yeniEkleToolStripMenuItem.Image = global::PH.Default.Properties.Resources.icons8_add_16;
            this.yeniEkleToolStripMenuItem.Name = "yeniEkleToolStripMenuItem";
            this.yeniEkleToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.yeniEkleToolStripMenuItem.Text = "Yeni Ekle";
            this.yeniEkleToolStripMenuItem.Click += new System.EventHandler(this.yeniEkleToolStripMenuItem_Click);
            // 
            // güncelleToolStripMenuItem
            // 
            this.güncelleToolStripMenuItem.Image = global::PH.Default.Properties.Resources.icons8_available_updates_16;
            this.güncelleToolStripMenuItem.Name = "güncelleToolStripMenuItem";
            this.güncelleToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.güncelleToolStripMenuItem.Text = "Güncelle";
            this.güncelleToolStripMenuItem.Click += new System.EventHandler(this.güncelleToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Aramalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 494);
            this.Controls.Add(this.GRC);
            this.Controls.Add(this.panelControl1);
            this.Name = "Aramalar";
            this.Text = "Aramalar";
            this.Load += new System.EventHandler(this.Aramalar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRW)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit dt2;
        private DevExpress.XtraEditors.DateEdit dt1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraGrid.GridControl GRC;
        private DevExpress.XtraGrid.Views.Grid.GridView GRW;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem yeniEkleToolStripMenuItem;
        private ToolStripMenuItem güncelleToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}