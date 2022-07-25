namespace VideoAudioMerge
{
    partial class VideoAudioMerge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoAudioMerge));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpenVideoOut = new AKANet.WinForms.Controls.CustomButton();
            this.textVideoOut = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.btnMerge = new AKANet.WinForms.Controls.CustomButton();
            this.btnBrowseVideoIn = new AKANet.WinForms.Controls.CustomButton();
            this.btnBrowseAudioIn = new AKANet.WinForms.Controls.CustomButton();
            this.txtAudioIn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVideoIn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenVideoOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMerge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowseVideoIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowseAudioIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOpenVideoOut);
            this.panel1.Controls.Add(this.textVideoOut);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtOutput);
            this.panel1.Controls.Add(this.btnMerge);
            this.panel1.Controls.Add(this.btnBrowseVideoIn);
            this.panel1.Controls.Add(this.btnBrowseAudioIn);
            this.panel1.Controls.Add(this.txtAudioIn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtVideoIn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 705);
            this.panel1.TabIndex = 109;
            // 
            // btnOpenVideoOut
            // 
            this.btnOpenVideoOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenVideoOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOpenVideoOut.BoarderWidth = 1.5F;
            this.btnOpenVideoOut.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnOpenVideoOut.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOpenVideoOut.FillStyle = AKANet.WinForms.Controls.FillStyle.Glow;
            this.btnOpenVideoOut.Location = new System.Drawing.Point(904, 140);
            this.btnOpenVideoOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenVideoOut.Name = "btnOpenVideoOut";
            this.btnOpenVideoOut.OuterBoundPaint = AKANet.WinForms.Controls.OuterBoundPaint.ParentBackColor;
            this.btnOpenVideoOut.ShapeStyle = AKANet.WinForms.Controls.ShapeStyle.Rectangle;
            this.btnOpenVideoOut.Size = new System.Drawing.Size(112, 45);
            this.btnOpenVideoOut.TabIndex = 116;
            this.btnOpenVideoOut.Text = "Open";
            this.btnOpenVideoOut.Click += new System.EventHandler(this.btnBrowseVideoOut_Click);
            // 
            // textVideoOut
            // 
            this.textVideoOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textVideoOut.BackColor = System.Drawing.SystemColors.Info;
            this.textVideoOut.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textVideoOut.Location = new System.Drawing.Point(135, 146);
            this.textVideoOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textVideoOut.Name = "textVideoOut";
            this.textVideoOut.ReadOnly = true;
            this.textVideoOut.Size = new System.Drawing.Size(758, 30);
            this.textVideoOut.TabIndex = 114;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 146);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 29);
            this.label1.TabIndex = 115;
            this.label1.Text = "Video Out";
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.BackColor = System.Drawing.Color.LightCyan;
            this.txtOutput.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(20, 318);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(996, 367);
            this.txtOutput.TabIndex = 113;
            this.txtOutput.Text = "";
            this.txtOutput.WordWrap = false;
            // 
            // btnMerge
            // 
            this.btnMerge.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMerge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(240)))), ((int)(((byte)(135)))));
            this.btnMerge.BoarderWidth = 1.5F;
            this.btnMerge.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnMerge.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(240)))), ((int)(((byte)(135)))));
            this.btnMerge.FillStyle = AKANet.WinForms.Controls.FillStyle.Glow;
            this.btnMerge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnMerge.Location = new System.Drawing.Point(428, 228);
            this.btnMerge.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.OuterBoundPaint = AKANet.WinForms.Controls.OuterBoundPaint.ParentBackColor;
            this.btnMerge.ShapeStyle = AKANet.WinForms.Controls.ShapeStyle.Rectangle;
            this.btnMerge.Size = new System.Drawing.Size(178, 63);
            this.btnMerge.TabIndex = 111;
            this.btnMerge.Text = "Merge";
            this.btnMerge.Click += new System.EventHandler(this.btnCalcDiff_Click);
            // 
            // btnBrowseVideoIn
            // 
            this.btnBrowseVideoIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseVideoIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBrowseVideoIn.BoarderWidth = 1.5F;
            this.btnBrowseVideoIn.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnBrowseVideoIn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBrowseVideoIn.FillStyle = AKANet.WinForms.Controls.FillStyle.Glow;
            this.btnBrowseVideoIn.Location = new System.Drawing.Point(904, 9);
            this.btnBrowseVideoIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowseVideoIn.Name = "btnBrowseVideoIn";
            this.btnBrowseVideoIn.OuterBoundPaint = AKANet.WinForms.Controls.OuterBoundPaint.ParentBackColor;
            this.btnBrowseVideoIn.ShapeStyle = AKANet.WinForms.Controls.ShapeStyle.Rectangle;
            this.btnBrowseVideoIn.Size = new System.Drawing.Size(112, 45);
            this.btnBrowseVideoIn.TabIndex = 107;
            this.btnBrowseVideoIn.Text = "Browse";
            this.btnBrowseVideoIn.Click += new System.EventHandler(this.btnBrowseVideoIn_Click);
            // 
            // btnBrowseAudioIn
            // 
            this.btnBrowseAudioIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseAudioIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBrowseAudioIn.BoarderWidth = 1.5F;
            this.btnBrowseAudioIn.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnBrowseAudioIn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBrowseAudioIn.FillStyle = AKANet.WinForms.Controls.FillStyle.Glow;
            this.btnBrowseAudioIn.Location = new System.Drawing.Point(904, 63);
            this.btnBrowseAudioIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowseAudioIn.Name = "btnBrowseAudioIn";
            this.btnBrowseAudioIn.OuterBoundPaint = AKANet.WinForms.Controls.OuterBoundPaint.ParentBackColor;
            this.btnBrowseAudioIn.ShapeStyle = AKANet.WinForms.Controls.ShapeStyle.Rectangle;
            this.btnBrowseAudioIn.Size = new System.Drawing.Size(112, 45);
            this.btnBrowseAudioIn.TabIndex = 106;
            this.btnBrowseAudioIn.Text = "Browse";
            this.btnBrowseAudioIn.Click += new System.EventHandler(this.btnBrowseAudioIn_Click);
            // 
            // txtAudioIn
            // 
            this.txtAudioIn.AllowDrop = true;
            this.txtAudioIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAudioIn.BackColor = System.Drawing.SystemColors.Info;
            this.txtAudioIn.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAudioIn.Location = new System.Drawing.Point(135, 69);
            this.txtAudioIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAudioIn.Name = "txtAudioIn";
            this.txtAudioIn.Size = new System.Drawing.Size(758, 30);
            this.txtAudioIn.TabIndex = 103;
            this.txtAudioIn.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtVideoAudioIn_DragDrop);
            this.txtAudioIn.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtVideoAudioIn_DragEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 29);
            this.label3.TabIndex = 104;
            this.label3.Text = "Audio In";
            // 
            // txtVideoIn
            // 
            this.txtVideoIn.AllowDrop = true;
            this.txtVideoIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVideoIn.BackColor = System.Drawing.SystemColors.Info;
            this.txtVideoIn.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVideoIn.Location = new System.Drawing.Point(135, 15);
            this.txtVideoIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVideoIn.Name = "txtVideoIn";
            this.txtVideoIn.Size = new System.Drawing.Size(758, 30);
            this.txtVideoIn.TabIndex = 101;
            this.txtVideoIn.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtVideoAudioIn_DragDrop);
            this.txtVideoIn.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtVideoAudioIn_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 29);
            this.label2.TabIndex = 102;
            this.label2.Text = "Video In";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
            this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Deleted);
            // 
            // VideoAudioMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1032, 705);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "VideoAudioMerge";
            this.Text = "Video Audio Merge";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenVideoOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMerge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowseVideoIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowseAudioIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtVideoIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAudioIn;
        private System.Windows.Forms.Label label3;
        private AKANet.WinForms.Controls.CustomButton btnBrowseVideoIn;
        private AKANet.WinForms.Controls.CustomButton btnBrowseAudioIn;
        private AKANet.WinForms.Controls.CustomButton btnMerge;
        private System.Windows.Forms.RichTextBox txtOutput;
        private AKANet.WinForms.Controls.CustomButton btnOpenVideoOut;
        private System.Windows.Forms.TextBox textVideoOut;
        private System.Windows.Forms.Label label1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}

