namespace DiskSpaceAnalyzer
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            MenuStrip = new MenuStrip();
            StartScanMenuItem = new ToolStripMenuItem();
            StatusStrip = new StatusStrip();
            ProgressLabel = new ToolStripStatusLabel();
            PathView = new ListView();
            NameColumnHeader = new ColumnHeader();
            SizeColumnHeader = new ColumnHeader();
            PathViewImageList = new ImageList(components);
            PathSelectDialog = new FolderBrowserDialog();
            MenuStrip.SuspendLayout();
            StatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MenuStrip
            // 
            MenuStrip.Items.AddRange(new ToolStripItem[] { StartScanMenuItem });
            MenuStrip.Location = new Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(980, 24);
            MenuStrip.TabIndex = 1;
            MenuStrip.Text = "menuStrip1";
            // 
            // StartScanMenuItem
            // 
            StartScanMenuItem.Name = "StartScanMenuItem";
            StartScanMenuItem.Size = new Size(71, 20);
            StartScanMenuItem.Text = "Start Scan";
            StartScanMenuItem.Click += StartScanMenuItem_Click;
            // 
            // StatusStrip
            // 
            StatusStrip.Items.AddRange(new ToolStripItem[] { ProgressLabel });
            StatusStrip.Location = new Point(0, 595);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Size = new Size(980, 22);
            StatusStrip.TabIndex = 2;
            StatusStrip.Text = "statusStrip1";
            // 
            // ProgressLabel
            // 
            ProgressLabel.Name = "ProgressLabel";
            ProgressLabel.Size = new Size(170, 17);
            ProgressLabel.Text = "Click 'Start Scan' to get started.";
            // 
            // PathView
            // 
            PathView.Columns.AddRange(new ColumnHeader[] { NameColumnHeader, SizeColumnHeader });
            PathView.Dock = DockStyle.Fill;
            PathView.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            PathView.FullRowSelect = true;
            PathView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            PathView.Location = new Point(0, 24);
            PathView.Name = "PathView";
            PathView.Size = new Size(980, 571);
            PathView.SmallImageList = PathViewImageList;
            PathView.TabIndex = 3;
            PathView.UseCompatibleStateImageBehavior = false;
            PathView.View = View.Details;
            PathView.DoubleClick += PathView_DoubleClick;
            // 
            // NameColumnHeader
            // 
            NameColumnHeader.Text = "Name";
            NameColumnHeader.Width = 512;
            // 
            // SizeColumnHeader
            // 
            SizeColumnHeader.Text = "Size";
            SizeColumnHeader.TextAlign = HorizontalAlignment.Right;
            SizeColumnHeader.Width = 128;
            // 
            // PathViewImageList
            // 
            PathViewImageList.ColorDepth = ColorDepth.Depth8Bit;
            PathViewImageList.ImageStream = (ImageListStreamer)resources.GetObject("PathViewImageList.ImageStream");
            PathViewImageList.TransparentColor = Color.Transparent;
            PathViewImageList.Images.SetKeyName(0, "folder.png");
            PathViewImageList.Images.SetKeyName(1, "file.png");
            // 
            // PathSelectDialog
            // 
            PathSelectDialog.ShowNewFolderButton = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 617);
            Controls.Add(PathView);
            Controls.Add(StatusStrip);
            Controls.Add(MenuStrip);
            MainMenuStrip = MenuStrip;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DiskSpaceAnalyzer";
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            StatusStrip.ResumeLayout(false);
            StatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip MenuStrip;
        private ToolStripMenuItem StartScanMenuItem;
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel ProgressLabel;
        private ListView PathView;
        private ColumnHeader NameColumnHeader;
        private ColumnHeader SizeColumnHeader;
        private ImageList PathViewImageList;
        private FolderBrowserDialog PathSelectDialog;
    }
}