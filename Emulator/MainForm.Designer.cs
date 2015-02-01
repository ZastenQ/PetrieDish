namespace Emulator
{
    partial class MainForm
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
            this.pnDish = new System.Windows.Forms.Panel();
            this.bnRun = new System.Windows.Forms.Button();
            this.lbCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnDish
            // 
            this.pnDish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnDish.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnDish.Location = new System.Drawing.Point(12, 12);
            this.pnDish.Name = "pnDish";
            this.pnDish.Size = new System.Drawing.Size(800, 800);
            this.pnDish.TabIndex = 0;
            // 
            // bnRun
            // 
            this.bnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnRun.Location = new System.Drawing.Point(293, 829);
            this.bnRun.Name = "bnRun";
            this.bnRun.Size = new System.Drawing.Size(244, 95);
            this.bnRun.TabIndex = 1;
            this.bnRun.Text = "Run";
            this.bnRun.UseVisualStyleBackColor = true;
            this.bnRun.Click += new System.EventHandler(this.bnRun_Click);
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(31, 870);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(70, 25);
            this.lbCount.TabIndex = 2;
            this.lbCount.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(825, 1182);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.bnRun);
            this.Controls.Add(this.pnDish);
            this.Name = "MainForm";
            this.Text = "Petrie Dish Emulation";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnDish;
        private System.Windows.Forms.Button bnRun;
        private System.Windows.Forms.Label lbCount;
    }
}

