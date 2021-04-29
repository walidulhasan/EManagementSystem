
namespace EManagementSystem
{
    partial class frmEBA
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
            this.dtview = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtview)).BeginInit();
            this.SuspendLayout();
            // 
            // dtview
            // 
            this.dtview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))));
            this.dtview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtview.Location = new System.Drawing.Point(0, 0);
            this.dtview.Name = "dtview";
            this.dtview.Size = new System.Drawing.Size(1427, 709);
            this.dtview.TabIndex = 5;
            // 
            // frmEBA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 709);
            this.Controls.Add(this.dtview);
            this.Name = "frmEBA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEBA";
            this.Load += new System.EventHandler(this.frmEBA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtview;
    }
}