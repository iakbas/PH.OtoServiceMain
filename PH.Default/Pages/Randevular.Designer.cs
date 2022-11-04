namespace PH.Default.Pages
{
    partial class Randevular
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Randevular));
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkTemplate = new DevExpress.XtraEditors.CheckButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.randevuOluşturToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seçilenRandevuyuDüzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randevuyuİptalEtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.görünümDeğiştirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.günlükToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.haftalıkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aylıkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yıllıkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ekranYenilemesiniDurdurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schdStore = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.schd = new DevExpress.XtraScheduler.SchedulerControl();
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schdStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkTemplate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1080, 81);
            this.panelControl1.TabIndex = 0;
            this.panelControl1.Visible = false;
            // 
            // chkTemplate
            // 
            this.chkTemplate.Appearance.BackColor = System.Drawing.Color.White;
            this.chkTemplate.Appearance.Options.UseBackColor = true;
            this.chkTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkTemplate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("chkTemplate.ImageOptions.Image")));
            this.chkTemplate.Location = new System.Drawing.Point(31, 12);
            this.chkTemplate.Name = "chkTemplate";
            this.chkTemplate.Size = new System.Drawing.Size(163, 32);
            this.chkTemplate.TabIndex = 15;
            this.chkTemplate.Text = "Tümü";
            this.chkTemplate.Visible = false;
            this.chkTemplate.CheckedChanged += new System.EventHandler(this.chkTemplate_CheckedChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randevuOluşturToolStripMenuItem,
            this.seçilenRandevuyuDüzenleToolStripMenuItem,
            this.randevuyuİptalEtToolStripMenuItem,
            this.toolStripSeparator1,
            this.görünümDeğiştirToolStripMenuItem,
            this.ekranYenilemesiniDurdurToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(219, 120);
            // 
            // randevuOluşturToolStripMenuItem
            // 
            this.randevuOluşturToolStripMenuItem.Name = "randevuOluşturToolStripMenuItem";
            this.randevuOluşturToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.randevuOluşturToolStripMenuItem.Text = "Randevu Oluştur";
            this.randevuOluşturToolStripMenuItem.Click += new System.EventHandler(this.randevuOluşturToolStripMenuItem_Click);
            // 
            // seçilenRandevuyuDüzenleToolStripMenuItem
            // 
            this.seçilenRandevuyuDüzenleToolStripMenuItem.Name = "seçilenRandevuyuDüzenleToolStripMenuItem";
            this.seçilenRandevuyuDüzenleToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.seçilenRandevuyuDüzenleToolStripMenuItem.Text = "Seçilen Randevuyu Düzenle";
            this.seçilenRandevuyuDüzenleToolStripMenuItem.Click += new System.EventHandler(this.seçilenRandevuyuDüzenleToolStripMenuItem_Click);
            // 
            // randevuyuİptalEtToolStripMenuItem
            // 
            this.randevuyuİptalEtToolStripMenuItem.Name = "randevuyuİptalEtToolStripMenuItem";
            this.randevuyuİptalEtToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.randevuyuİptalEtToolStripMenuItem.Text = "Randevuyu İptal Et";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
            // 
            // görünümDeğiştirToolStripMenuItem
            // 
            this.görünümDeğiştirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.günlükToolStripMenuItem,
            this.haftalıkToolStripMenuItem,
            this.aylıkToolStripMenuItem,
            this.yıllıkToolStripMenuItem});
            this.görünümDeğiştirToolStripMenuItem.Name = "görünümDeğiştirToolStripMenuItem";
            this.görünümDeğiştirToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.görünümDeğiştirToolStripMenuItem.Text = "Görünüm Değiştir";
            // 
            // günlükToolStripMenuItem
            // 
            this.günlükToolStripMenuItem.Name = "günlükToolStripMenuItem";
            this.günlükToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.günlükToolStripMenuItem.Text = "Günlük";
            this.günlükToolStripMenuItem.Click += new System.EventHandler(this.günlükToolStripMenuItem_Click);
            // 
            // haftalıkToolStripMenuItem
            // 
            this.haftalıkToolStripMenuItem.Name = "haftalıkToolStripMenuItem";
            this.haftalıkToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.haftalıkToolStripMenuItem.Text = "Haftalık";
            this.haftalıkToolStripMenuItem.Click += new System.EventHandler(this.haftalıkToolStripMenuItem_Click);
            // 
            // aylıkToolStripMenuItem
            // 
            this.aylıkToolStripMenuItem.Name = "aylıkToolStripMenuItem";
            this.aylıkToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.aylıkToolStripMenuItem.Text = "Aylık";
            this.aylıkToolStripMenuItem.Click += new System.EventHandler(this.aylıkToolStripMenuItem_Click);
            // 
            // yıllıkToolStripMenuItem
            // 
            this.yıllıkToolStripMenuItem.Name = "yıllıkToolStripMenuItem";
            this.yıllıkToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.yıllıkToolStripMenuItem.Text = "Yıllık";
            this.yıllıkToolStripMenuItem.Click += new System.EventHandler(this.yıllıkToolStripMenuItem_Click);
            // 
            // ekranYenilemesiniDurdurToolStripMenuItem
            // 
            this.ekranYenilemesiniDurdurToolStripMenuItem.Name = "ekranYenilemesiniDurdurToolStripMenuItem";
            this.ekranYenilemesiniDurdurToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.ekranYenilemesiniDurdurToolStripMenuItem.Text = "Ekran Yenilemesini Durdur";
            this.ekranYenilemesiniDurdurToolStripMenuItem.Click += new System.EventHandler(this.ekranYenilemesiniDurdurToolStripMenuItem_Click);
            // 
            // schdStore
            // 
            // 
            // 
            // 
            this.schdStore.AppointmentDependencies.AutoReload = false;
            // 
            // 
            // 
            this.schdStore.Appointments.Labels.CreateNewLabel(0, "None", "&None", System.Drawing.SystemColors.Window);
            this.schdStore.Appointments.Labels.CreateNewLabel(1, "Important", "&Important", System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(190))))));
            this.schdStore.Appointments.Labels.CreateNewLabel(2, "Business", "&Business", System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(213)))), ((int)(((byte)(255))))));
            this.schdStore.Appointments.Labels.CreateNewLabel(3, "Personal", "&Personal", System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(244)))), ((int)(((byte)(156))))));
            this.schdStore.Appointments.Labels.CreateNewLabel(4, "Vacation", "&Vacation", System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(228)))), ((int)(((byte)(199))))));
            this.schdStore.Appointments.Labels.CreateNewLabel(5, "Must Attend", "Must &Attend", System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(206)))), ((int)(((byte)(147))))));
            this.schdStore.Appointments.Labels.CreateNewLabel(6, "Travel Required", "&Travel Required", System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(244)))), ((int)(((byte)(255))))));
            this.schdStore.Appointments.Labels.CreateNewLabel(7, "Needs Preparation", "&Needs Preparation", System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(152))))));
            this.schdStore.Appointments.Labels.CreateNewLabel(8, "Birthday", "&Birthday", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(207)))), ((int)(((byte)(233))))));
            this.schdStore.Appointments.Labels.CreateNewLabel(9, "Anniversary", "&Anniversary", System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(233)))), ((int)(((byte)(223))))));
            this.schdStore.Appointments.Labels.CreateNewLabel(10, "Phone Call", "Phone &Call", System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(165))))));
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // schd
            // 
            this.schd.ContextMenuStrip = this.contextMenuStrip1;
            this.schd.DataStorage = this.schdStore;
            this.schd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schd.Location = new System.Drawing.Point(0, 81);
            this.schd.Name = "schd";
            this.schd.Size = new System.Drawing.Size(832, 360);
            this.schd.Start = new System.DateTime(2022, 6, 6, 0, 0, 0, 0);
            this.schd.TabIndex = 1;
            this.schd.Text = "schedulerControl1";
            this.schd.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schd.Views.DayView.VisibleTime = new DevExpress.XtraScheduler.TimeOfDayInterval(System.TimeSpan.Parse("08:00:00"), System.TimeSpan.Parse("18:00:00"));
            this.schd.Views.FullWeekView.Enabled = true;
            this.schd.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.schd.Views.WeekView.Enabled = false;
            this.schd.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            this.schd.Views.YearView.UseOptimizedScrolling = false;
            this.schd.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.schd_EditAppointmentFormShowing);
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.CalendarAppearance.DayCellSpecial.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.dateNavigator1.CalendarAppearance.DayCellSpecial.Options.UseFont = true;
            this.dateNavigator1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNavigator1.DateTime = new System.DateTime(2022, 6, 6, 0, 0, 0, 0);
            this.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dateNavigator1.EditValue = new System.DateTime(2022, 6, 6, 0, 0, 0, 0);
            this.dateNavigator1.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.dateNavigator1.Location = new System.Drawing.Point(832, 81);
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.SchedulerControl = this.schd;
            this.dateNavigator1.Size = new System.Drawing.Size(248, 360);
            this.dateNavigator1.TabIndex = 16;
            // 
            // Randevular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 441);
            this.Controls.Add(this.schd);
            this.Controls.Add(this.dateNavigator1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Randevular";
            this.Text = "Randevular";
            this.Load += new System.EventHandler(this.Randevular_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.schdStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraScheduler.SchedulerDataStorage schdStore;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem randevuOluşturToolStripMenuItem;
        private ToolStripMenuItem seçilenRandevuyuDüzenleToolStripMenuItem;
        private ToolStripMenuItem randevuyuİptalEtToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem görünümDeğiştirToolStripMenuItem;
        private ToolStripMenuItem günlükToolStripMenuItem;
        private ToolStripMenuItem haftalıkToolStripMenuItem;
        private ToolStripMenuItem aylıkToolStripMenuItem;
        private ToolStripMenuItem yıllıkToolStripMenuItem;
        private DevExpress.XtraEditors.CheckButton chkTemplate;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraScheduler.SchedulerControl schd;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
        private ToolStripMenuItem ekranYenilemesiniDurdurToolStripMenuItem;
    }
}