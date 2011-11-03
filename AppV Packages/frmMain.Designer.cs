namespace AppV_Packages
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.AppVTree = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAbout = new System.Windows.Forms.ToolStripButton();
            this.toolbtnExport = new System.Windows.Forms.ToolStripButton();
            this.toolbtnChange = new System.Windows.Forms.ToolStripButton();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblADGroup = new System.Windows.Forms.Label();
            this.lblPackage = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtADGroup = new System.Windows.Forms.TextBox();
            this.txtPackage = new System.Windows.Forms.TextBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtApp = new System.Windows.Forms.TextBox();
            this.lblApp = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AppVTree
            // 
            this.AppVTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppVTree.Location = new System.Drawing.Point(0, 0);
            this.AppVTree.Name = "AppVTree";
            this.AppVTree.Size = new System.Drawing.Size(422, 392);
            this.AppVTree.TabIndex = 2;
            this.AppVTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.AppVTree_AfterSelect);
            this.AppVTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.AppVTree_NodeMouseDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbout,
            this.toolbtnExport,
            this.toolbtnChange});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(639, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAbout
            // 
            this.btnAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(52, 22);
            this.btnAbout.Text = "About...";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // toolbtnExport
            // 
            this.toolbtnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtnExport.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnExport.Image")));
            this.toolbtnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnExport.Name = "toolbtnExport";
            this.toolbtnExport.Size = new System.Drawing.Size(84, 22);
            this.toolbtnExport.Text = "Export to Excel";
            this.toolbtnExport.Click += new System.EventHandler(this.toolbtnExport_Click);
            // 
            // toolbtnChange
            // 
            this.toolbtnChange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtnChange.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnChange.Image")));
            this.toolbtnChange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnChange.Name = "toolbtnChange";
            this.toolbtnChange.Size = new System.Drawing.Size(88, 22);
            this.toolbtnChange.Text = "Change Servers";
            this.toolbtnChange.Click += new System.EventHandler(this.toolbtnChange_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel1.Controls.Add(this.btnClear);
            this.splitContainer1.Panel1.Controls.Add(this.lblADGroup);
            this.splitContainer1.Panel1.Controls.Add(this.lblPackage);
            this.splitContainer1.Panel1.Controls.Add(this.lblApp);
            this.splitContainer1.Panel1.Controls.Add(this.lblVersion);
            this.splitContainer1.Panel1.Controls.Add(this.txtADGroup);
            this.splitContainer1.Panel1.Controls.Add(this.txtPackage);
            this.splitContainer1.Panel1.Controls.Add(this.txtApp);
            this.splitContainer1.Panel1.Controls.Add(this.txtVersion);
            this.splitContainer1.Panel1.Controls.Add(this.chkEnabled);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.AppVTree);
            this.splitContainer1.Size = new System.Drawing.Size(639, 392);
            this.splitContainer1.SplitterDistance = 213;
            this.splitContainer1.TabIndex = 6;
            // 
            // lblADGroup
            // 
            this.lblADGroup.AutoSize = true;
            this.lblADGroup.Location = new System.Drawing.Point(97, 178);
            this.lblADGroup.Name = "lblADGroup";
            this.lblADGroup.Size = new System.Drawing.Size(114, 13);
            this.lblADGroup.TabIndex = 3;
            this.lblADGroup.Text = "Active Directory Group";
            // 
            // lblPackage
            // 
            this.lblPackage.AutoSize = true;
            this.lblPackage.Location = new System.Drawing.Point(129, 129);
            this.lblPackage.Name = "lblPackage";
            this.lblPackage.Size = new System.Drawing.Size(81, 13);
            this.lblPackage.TabIndex = 3;
            this.lblPackage.Text = "Package Name";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(168, 72);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Version";
            // 
            // txtADGroup
            // 
            this.txtADGroup.Location = new System.Drawing.Point(4, 155);
            this.txtADGroup.Name = "txtADGroup";
            this.txtADGroup.Size = new System.Drawing.Size(207, 20);
            this.txtADGroup.TabIndex = 1;
            // 
            // txtPackage
            // 
            this.txtPackage.Location = new System.Drawing.Point(3, 106);
            this.txtPackage.Name = "txtPackage";
            this.txtPackage.Size = new System.Drawing.Size(207, 20);
            this.txtPackage.TabIndex = 1;
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(3, 49);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(207, 20);
            this.txtVersion.TabIndex = 1;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(145, 215);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 0;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtApp
            // 
            this.txtApp.Location = new System.Drawing.Point(4, 3);
            this.txtApp.Name = "txtApp";
            this.txtApp.Size = new System.Drawing.Size(207, 20);
            this.txtApp.TabIndex = 1;
            // 
            // lblApp
            // 
            this.lblApp.AutoSize = true;
            this.lblApp.Location = new System.Drawing.Point(151, 26);
            this.lblApp.Name = "lblApp";
            this.lblApp.Size = new System.Drawing.Size(59, 13);
            this.lblApp.TabIndex = 2;
            this.lblApp.Text = "Application";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(132, 245);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 245);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 417);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "AppV Package List";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private System.Windows.Forms.TreeView AppVTree;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAbout;
        private System.Windows.Forms.ToolStripButton toolbtnExport;
        private System.Windows.Forms.ToolStripButton toolbtnChange;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox txtADGroup;
        private System.Windows.Forms.TextBox txtPackage;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label lblADGroup;
        private System.Windows.Forms.Label lblPackage;
        private System.Windows.Forms.Label lblApp;
        private System.Windows.Forms.TextBox txtApp;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
    }
}

