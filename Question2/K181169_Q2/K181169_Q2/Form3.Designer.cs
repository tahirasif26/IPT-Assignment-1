
namespace K181169_Q2
{
    partial class Form3
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
            this.p = new System.Windows.Forms.Label();
            this.vp = new System.Windows.Forms.Label();
            this.gs = new System.Windows.Forms.Label();
            this.pre = new System.Windows.Forms.ComboBox();
            this.vpre = new System.Windows.Forms.ComboBox();
            this.gen_sec = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // p
            // 
            this.p.AutoSize = true;
            this.p.Location = new System.Drawing.Point(257, 155);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(62, 15);
            this.p.TabIndex = 0;
            this.p.Text = "President :";
            // 
            // vp
            // 
            this.vp.AutoSize = true;
            this.vp.Location = new System.Drawing.Point(257, 205);
            this.vp.Name = "vp";
            this.vp.Size = new System.Drawing.Size(87, 15);
            this.vp.TabIndex = 1;
            this.vp.Text = "Vice President :";
            // 
            // gs
            // 
            this.gs.AutoSize = true;
            this.gs.Location = new System.Drawing.Point(257, 254);
            this.gs.Name = "gs";
            this.gs.Size = new System.Drawing.Size(104, 15);
            this.gs.TabIndex = 2;
            this.gs.Text = "General Secretary :";
            // 
            // pre
            // 
            this.pre.FormattingEnabled = true;
            this.pre.Location = new System.Drawing.Point(402, 147);
            this.pre.Name = "pre";
            this.pre.Size = new System.Drawing.Size(121, 23);
            this.pre.TabIndex = 3;
            // 
            // vpre
            // 
            this.vpre.FormattingEnabled = true;
            this.vpre.Location = new System.Drawing.Point(402, 197);
            this.vpre.Name = "vpre";
            this.vpre.Size = new System.Drawing.Size(121, 23);
            this.vpre.TabIndex = 4;
            // 
            // gen_sec
            // 
            this.gen_sec.FormattingEnabled = true;
            this.gen_sec.Location = new System.Drawing.Point(402, 246);
            this.gen_sec.Name = "gen_sec";
            this.gen_sec.Size = new System.Drawing.Size(121, 23);
            this.gen_sec.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(346, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(257, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Vote to your Candidate";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gen_sec);
            this.Controls.Add(this.vpre);
            this.Controls.Add(this.pre);
            this.Controls.Add(this.gs);
            this.Controls.Add(this.vp);
            this.Controls.Add(this.p);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label p;
        private System.Windows.Forms.Label vp;
        private System.Windows.Forms.Label gs;
        private System.Windows.Forms.ComboBox pre;
        private System.Windows.Forms.ComboBox vpre;
        private System.Windows.Forms.ComboBox gen_sec;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}