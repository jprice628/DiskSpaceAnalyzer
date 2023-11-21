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
            MenuStrip = new MenuStrip();
            StartScanMenuItem = new ToolStripMenuItem();
            StatusStrip = new StatusStrip();
            ProgressLabel = new ToolStripStatusLabel();
            FolderView = new TreeView();
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
            // FolderView
            // 
            FolderView.Dock = DockStyle.Fill;
            FolderView.Location = new Point(0, 24);
            FolderView.Name = "FolderView";
            FolderView.Size = new Size(980, 571);
            FolderView.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 617);
            Controls.Add(FolderView);
            Controls.Add(StatusStrip);
            Controls.Add(MenuStrip);
            MainMenuStrip = MenuStrip;
            Name = "Form1";
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
        private TreeView FolderView;
    }
}