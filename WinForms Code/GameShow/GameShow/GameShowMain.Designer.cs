namespace GameShow
{
    partial class GameShowMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameShowMain));
            CboPuertos = new ComboBox();
            labelPlayer = new Label();
            btnRefresh = new Button();
            btnListen = new Button();
            btnHide = new Button();
            SuspendLayout();
            // 
            // CboPuertos
            // 
            CboPuertos.DropDownStyle = ComboBoxStyle.DropDownList;
            CboPuertos.FormattingEnabled = true;
            CboPuertos.Location = new Point(12, 12);
            CboPuertos.Name = "CboPuertos";
            CboPuertos.Size = new Size(121, 23);
            CboPuertos.TabIndex = 0;
            // 
            // labelPlayer
            // 
            labelPlayer.Anchor = AnchorStyles.None;
            labelPlayer.BackColor = Color.Transparent;
            labelPlayer.Font = new Font("Showcard Gothic", 129.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPlayer.ForeColor = Color.MintCream;
            labelPlayer.Location = new Point(-112, 0);
            labelPlayer.Name = "labelPlayer";
            labelPlayer.Size = new Size(1275, 467);
            labelPlayer.TabIndex = 1;
            labelPlayer.Text = "-";
            labelPlayer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(139, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(67, 23);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refrescar";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += button1_Click;
            // 
            // btnListen
            // 
            btnListen.Location = new Point(12, 41);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(194, 23);
            btnListen.TabIndex = 3;
            btnListen.Text = "Escuchar Puerto";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += button2_Click;
            // 
            // btnHide
            // 
            btnHide.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnHide.BackColor = SystemColors.ActiveCaptionText;
            btnHide.FlatStyle = FlatStyle.Flat;
            btnHide.ForeColor = Color.FromArgb(82, 44, 65);
            btnHide.Location = new Point(12, 432);
            btnHide.Name = "btnHide";
            btnHide.Size = new Size(27, 23);
            btnHide.TabIndex = 4;
            btnHide.Text = "👁️";
            btnHide.UseVisualStyleBackColor = false;
            btnHide.Click += button3_Click;
            // 
            // GameShowMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1051, 467);
            Controls.Add(btnHide);
            Controls.Add(btnListen);
            Controls.Add(btnRefresh);
            Controls.Add(CboPuertos);
            Controls.Add(labelPlayer);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "GameShowMain";
            Text = "Competencias Biblicas";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox CboPuertos;
        private Label labelPlayer;
        private Button btnRefresh;
        private Button btnListen;
        private Button btnHide;
    }
}
