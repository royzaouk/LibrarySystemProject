namespace LibrarySystem
{
    partial class frm_returnBook
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
            this.dgvActiveBorrows = new System.Windows.Forms.DataGridView();
            this.btnMarkReturned = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveBorrows)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvActiveBorrows
            // 
            this.dgvActiveBorrows.AllowUserToAddRows = false;
            this.dgvActiveBorrows.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActiveBorrows.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvActiveBorrows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveBorrows.Location = new System.Drawing.Point(21, 49);
            this.dgvActiveBorrows.MultiSelect = false;
            this.dgvActiveBorrows.Name = "dgvActiveBorrows";
            this.dgvActiveBorrows.ReadOnly = true;
            this.dgvActiveBorrows.RowHeadersVisible = false;
            this.dgvActiveBorrows.RowHeadersWidth = 51;
            this.dgvActiveBorrows.RowTemplate.Height = 24;
            this.dgvActiveBorrows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActiveBorrows.Size = new System.Drawing.Size(1027, 312);
            this.dgvActiveBorrows.TabIndex = 0;
            // 
            // btnMarkReturned
            // 
            this.btnMarkReturned.Location = new System.Drawing.Point(431, 379);
            this.btnMarkReturned.Name = "btnMarkReturned";
            this.btnMarkReturned.Size = new System.Drawing.Size(168, 50);
            this.btnMarkReturned.TabIndex = 1;
            this.btnMarkReturned.Text = "Mark As Returned";
            this.btnMarkReturned.UseVisualStyleBackColor = true;
            this.btnMarkReturned.Click += new System.EventHandler(this.btnMarkReturned_Click);
            // 
            // frm_returnBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1073, 557);
            this.Controls.Add(this.btnMarkReturned);
            this.Controls.Add(this.dgvActiveBorrows);
            this.Name = "frm_returnBook";
            this.Text = "frm_returnBook";
            this.Load += new System.EventHandler(this.frm_returnBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveBorrows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvActiveBorrows;
        private System.Windows.Forms.Button btnMarkReturned;
    }
}