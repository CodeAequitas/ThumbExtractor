namespace ThumbExtractor.GUI
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_top = new System.Windows.Forms.Panel();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_browse_outdir = new System.Windows.Forms.Button();
            this.btn_browse_db = new System.Windows.Forms.Button();
            this.text_outdir = new System.Windows.Forms.TextBox();
            this.text_thumbfile = new System.Windows.Forms.TextBox();
            this.text_status = new System.Windows.Forms.TextBox();
            this.panel_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "ThumbExtractor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thumb Database:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Output Directory:";
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.btn_start);
            this.panel_top.Controls.Add(this.btn_browse_outdir);
            this.panel_top.Controls.Add(this.btn_browse_db);
            this.panel_top.Controls.Add(this.text_outdir);
            this.panel_top.Controls.Add(this.text_thumbfile);
            this.panel_top.Controls.Add(this.label1);
            this.panel_top.Controls.Add(this.label3);
            this.panel_top.Controls.Add(this.label2);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(630, 167);
            this.panel_top.TabIndex = 3;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(535, 125);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(83, 32);
            this.btn_start.TabIndex = 7;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_browse_outdir
            // 
            this.btn_browse_outdir.Location = new System.Drawing.Point(576, 88);
            this.btn_browse_outdir.Name = "btn_browse_outdir";
            this.btn_browse_outdir.Size = new System.Drawing.Size(42, 23);
            this.btn_browse_outdir.TabIndex = 6;
            this.btn_browse_outdir.Text = "...";
            this.btn_browse_outdir.UseVisualStyleBackColor = true;
            this.btn_browse_outdir.Click += new System.EventHandler(this.btn_browse_outdir_Click);
            // 
            // btn_browse_db
            // 
            this.btn_browse_db.Location = new System.Drawing.Point(576, 52);
            this.btn_browse_db.Name = "btn_browse_db";
            this.btn_browse_db.Size = new System.Drawing.Size(42, 23);
            this.btn_browse_db.TabIndex = 5;
            this.btn_browse_db.Text = "...";
            this.btn_browse_db.UseVisualStyleBackColor = true;
            this.btn_browse_db.Click += new System.EventHandler(this.btn_browse_db_Click);
            // 
            // text_outdir
            // 
            this.text_outdir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_outdir.Location = new System.Drawing.Point(130, 88);
            this.text_outdir.Name = "text_outdir";
            this.text_outdir.Size = new System.Drawing.Size(440, 25);
            this.text_outdir.TabIndex = 4;
            // 
            // text_thumbfile
            // 
            this.text_thumbfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_thumbfile.Location = new System.Drawing.Point(130, 52);
            this.text_thumbfile.Name = "text_thumbfile";
            this.text_thumbfile.Size = new System.Drawing.Size(440, 25);
            this.text_thumbfile.TabIndex = 3;
            // 
            // text_status
            // 
            this.text_status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_status.Location = new System.Drawing.Point(0, 167);
            this.text_status.Multiline = true;
            this.text_status.Name = "text_status";
            this.text_status.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.text_status.Size = new System.Drawing.Size(630, 308);
            this.text_status.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 475);
            this.Controls.Add(this.text_status);
            this.Controls.Add(this.panel_top);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeAequitas ThumbExtractor";
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.TextBox text_status;
        private System.Windows.Forms.Button btn_browse_outdir;
        private System.Windows.Forms.Button btn_browse_db;
        private System.Windows.Forms.TextBox text_outdir;
        private System.Windows.Forms.TextBox text_thumbfile;
        private System.Windows.Forms.Button btn_start;
    }
}

