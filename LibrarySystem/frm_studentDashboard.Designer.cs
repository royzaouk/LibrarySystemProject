namespace LibrarySystem
{
    partial class frm_studentDashboard
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
            this.lblStudentName = new System.Windows.Forms.Label();
            this.lblAvailableBooks = new System.Windows.Forms.Label();
            this.dgvAvailableBooks = new System.Windows.Forms.DataGridView();
            this.lblMyBorrows = new System.Windows.Forms.Label();
            this.dgvMyBorrows = new System.Windows.Forms.DataGridView();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyBorrows)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentName.ForeColor = System.Drawing.SystemColors.Control;
            this.lblStudentName.Location = new System.Drawing.Point(14, 9);
            this.lblStudentName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(248, 36);
            this.lblStudentName.TabIndex = 46;
            this.lblStudentName.Text = "Welcome, [Name]";
            // 
            // lblAvailableBooks
            // 
            this.lblAvailableBooks.AutoSize = true;
            this.lblAvailableBooks.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableBooks.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAvailableBooks.Location = new System.Drawing.Point(14, 79);
            this.lblAvailableBooks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAvailableBooks.Name = "lblAvailableBooks";
            this.lblAvailableBooks.Size = new System.Drawing.Size(230, 36);
            this.lblAvailableBooks.TabIndex = 47;
            this.lblAvailableBooks.Text = "Available Books";
            // 
            // dgvAvailableBooks
            // 
            this.dgvAvailableBooks.AllowUserToAddRows = false;
            this.dgvAvailableBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvailableBooks.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvAvailableBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableBooks.Location = new System.Drawing.Point(312, 93);
            this.dgvAvailableBooks.MultiSelect = false;
            this.dgvAvailableBooks.Name = "dgvAvailableBooks";
            this.dgvAvailableBooks.ReadOnly = true;
            this.dgvAvailableBooks.RowHeadersVisible = false;
            this.dgvAvailableBooks.RowHeadersWidth = 51;
            this.dgvAvailableBooks.RowTemplate.Height = 24;
            this.dgvAvailableBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailableBooks.Size = new System.Drawing.Size(663, 248);
            this.dgvAvailableBooks.TabIndex = 48;
            // 
            // lblMyBorrows
            // 
            this.lblMyBorrows.AutoSize = true;
            this.lblMyBorrows.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyBorrows.ForeColor = System.Drawing.SystemColors.Control;
            this.lblMyBorrows.Location = new System.Drawing.Point(14, 439);
            this.lblMyBorrows.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMyBorrows.Name = "lblMyBorrows";
            this.lblMyBorrows.Size = new System.Drawing.Size(282, 36);
            this.lblMyBorrows.TabIndex = 49;
            this.lblMyBorrows.Text = "My Borrowed Books";
            // 
            // dgvMyBorrows
            // 
            this.dgvMyBorrows.AllowUserToAddRows = false;
            this.dgvMyBorrows.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyBorrows.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvMyBorrows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyBorrows.Location = new System.Drawing.Point(312, 439);
            this.dgvMyBorrows.Name = "dgvMyBorrows";
            this.dgvMyBorrows.ReadOnly = true;
            this.dgvMyBorrows.RowHeadersVisible = false;
            this.dgvMyBorrows.RowHeadersWidth = 51;
            this.dgvMyBorrows.RowTemplate.Height = 24;
            this.dgvMyBorrows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyBorrows.Size = new System.Drawing.Size(663, 150);
            this.dgvMyBorrows.TabIndex = 50;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(312, 607);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(190, 50);
            this.btnLogout.TabIndex = 51;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // frm_studentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1058, 713);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.dgvMyBorrows);
            this.Controls.Add(this.lblMyBorrows);
            this.Controls.Add(this.dgvAvailableBooks);
            this.Controls.Add(this.lblAvailableBooks);
            this.Controls.Add(this.lblStudentName);
            this.Name = "frm_studentDashboard";
            this.Text = "frm_studentDashboard";
            this.Load += new System.EventHandler(this.frm_studentDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyBorrows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Label lblAvailableBooks;
        private System.Windows.Forms.DataGridView dgvAvailableBooks;
        private System.Windows.Forms.Label lblMyBorrows;
        private System.Windows.Forms.DataGridView dgvMyBorrows;
        private System.Windows.Forms.Button btnLogout;
    }
}