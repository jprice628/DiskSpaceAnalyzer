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
            StatusStrip = new StatusStrip();
            ProgressLabel = new ToolStripStatusLabel();
            PathView = new ListView();
            NameColumnHeader = new ColumnHeader();
            SizeColumnHeader = new ColumnHeader();
            PathViewImageList = new ImageList(components);
            PathSelectDialog = new FolderBrowserDialog();
            AddressBar = new TextBox();
            StartScanButton = new Button();
            StatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // StatusStrip
            // 
            StatusStrip.Items.AddRange(new ToolStripItem[] { ProgressLabel });
            StatusStrip.Location = new Point(0, 603);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Size = new Size(901, 22);
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
            PathView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PathView.BorderStyle = BorderStyle.FixedSingle;
            PathView.Columns.AddRange(new ColumnHeader[] { NameColumnHeader, SizeColumnHeader });
            PathView.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            PathView.FullRowSelect = true;
            PathView.GridLines = true;
            PathView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            PathView.Location = new Point(12, 40);
            PathView.Name = "PathView";
            PathView.Size = new Size(877, 560);
            PathView.SmallImageList = PathViewImageList;
            PathView.TabIndex = 3;
            PathView.UseCompatibleStateImageBehavior = false;
            PathView.View = View.Details;
            PathView.Click += PathView_Click;
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
            // AddressBar
            // 
            AddressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AddressBar.BackColor = SystemColors.Window;
            AddressBar.BorderStyle = BorderStyle.FixedSingle;
            AddressBar.CausesValidation = false;
            AddressBar.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AddressBar.Location = new Point(93, 12);
            AddressBar.Name = "AddressBar";
            AddressBar.ReadOnly = true;
            AddressBar.Size = new Size(796, 21);
            AddressBar.TabIndex = 4;
            // 
            // StartScanButton
            // 
            StartScanButton.Location = new Point(12, 11);
            StartScanButton.Name = "StartScanButton";
            StartScanButton.Size = new Size(75, 23);
            StartScanButton.TabIndex = 5;
            StartScanButton.Text = "Start Scan";
            StartScanButton.UseVisualStyleBackColor = true;
            StartScanButton.Click += StartScanButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 625);
            Controls.Add(StartScanButton);
            Controls.Add(AddressBar);
            Controls.Add(PathView);
            Controls.Add(StatusStrip);
            MinimumSize = new Size(680, 369);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DiskSpaceAnalyzer";
            StatusStrip.ResumeLayout(false);
            StatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel ProgressLabel;
        private ListView PathView;
        private ColumnHeader NameColumnHeader;
        private ColumnHeader SizeColumnHeader;
        private ImageList PathViewImageList;
        private FolderBrowserDialog PathSelectDialog;
        private TextBox AddressBar;
        private Button StartScanButton;
    }
}