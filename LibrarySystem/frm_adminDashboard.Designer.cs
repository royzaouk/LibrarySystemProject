namespace LibrarySystem
{
    partial class frm_adminDashboard
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblTotalBooks = new System.Windows.Forms.Label();
            this.lblCurrentlyBorrowed = new System.Windows.Forms.Label();
            this.lblTotalMembers = new System.Windows.Forms.Label();
            this.btnManageBooks = new System.Windows.Forms.Button();
            this.btnBorrowBook = new System.Windows.Forms.Button();
            this.btnManageMembers = new System.Windows.Forms.Button();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.SystemColors.Control;
            this.lblWelcome.Location = new System.Drawing.Point(13, 9);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(237, 36);
            this.lblWelcome.TabIndex = 45;
            this.lblWelcome.Text = "Welcome, Admin";
            // 
            // lblTotalBooks
            // 
            this.lblTotalBooks.AutoSize = true;
            this.lblTotalBooks.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBooks.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTotalBooks.Location = new System.Drawing.Point(13, 170);
            this.lblTotalBooks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalBooks.Name = "lblTotalBooks";
            this.lblTotalBooks.Size = new System.Drawing.Size(201, 36);
            this.lblTotalBooks.TabIndex = 46;
            this.lblTotalBooks.Text = "Total Books: 0";
            // 
            // lblCurrentlyBorrowed
            // 
            this.lblCurrentlyBorrowed.AutoSize = true;
            this.lblCurrentlyBorrowed.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentlyBorrowed.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCurrentlyBorrowed.Location = new System.Drawing.Point(13, 242);
            this.lblCurrentlyBorrowed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentlyBorrowed.Name = "lblCurrentlyBorrowed";
            this.lblCurrentlyBorrowed.Size = new System.Drawing.Size(314, 36);
            this.lblCurrentlyBorrowed.TabIndex = 47;
            this.lblCurrentlyBorrowed.Text = "Currently Borrowed: 0";
            // 
            // lblTotalMembers
            // 
            this.lblTotalMembers.AutoSize = true;
            this.lblTotalMembers.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMembers.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTotalMembers.Location = new System.Drawing.Point(13, 206);
            this.lblTotalMembers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalMembers.Name = "lblTotalMembers";
            this.lblTotalMembers.Size = new System.Drawing.Size(244, 36);
            this.lblTotalMembers.TabIndex = 48;
            this.lblTotalMembers.Text = "Total Members: 0";
            // 
            // btnManageBooks
            // 
            this.btnManageBooks.Location = new System.Drawing.Point(19, 81);
            this.btnManageBooks.Name = "btnManageBooks";
            this.btnManageBooks.Size = new System.Drawing.Size(160, 40);
            this.btnManageBooks.TabIndex = 49;
            this.btnManageBooks.Text = "Manage Books";
            this.btnManageBooks.UseVisualStyleBackColor = true;
            this.btnManageBooks.Click += new System.EventHandler(this.btnManageBooks_Click);
            // 
            // btnBorrowBook
            // 
            this.btnBorrowBook.Location = new System.Drawing.Point(220, 81);
            this.btnBorrowBook.Name = "btnBorrowBook";
            this.btnBorrowBook.Size = new System.Drawing.Size(160, 40);
            this.btnBorrowBook.TabIndex = 50;
            this.btnBorrowBook.Text = "Borrow Book";
            this.btnBorrowBook.UseVisualStyleBackColor = true;
            this.btnBorrowBook.Click += new System.EventHandler(this.btnBorrowBook_Click);
            // 
            // btnManageMembers
            // 
            this.btnManageMembers.Location = new System.Drawing.Point(19, 127);
            this.btnManageMembers.Name = "btnManageMembers";
            this.btnManageMembers.Size = new System.Drawing.Size(160, 40);
            this.btnManageMembers.TabIndex = 51;
            this.btnManageMembers.Text = "Manage Members";
            this.btnManageMembers.UseVisualStyleBackColor = true;
            this.btnManageMembers.Click += new System.EventHandler(this.btnManageMembers_Click);
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.Location = new System.Drawing.Point(220, 127);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(160, 40);
            this.btnReturnBook.TabIndex = 52;
            this.btnReturnBook.Text = "Return Book";
            this.btnReturnBook.UseVisualStyleBackColor = true;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(412, 106);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 30);
            this.btnLogout.TabIndex = 53;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // frm_adminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1016, 649);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnReturnBook);
            this.Controls.Add(this.btnManageMembers);
            this.Controls.Add(this.btnBorrowBook);
            this.Controls.Add(this.btnManageBooks);
            this.Controls.Add(this.lblTotalMembers);
            this.Controls.Add(this.lblCurrentlyBorrowed);
            this.Controls.Add(this.lblTotalBooks);
            this.Controls.Add(this.lblWelcome);
            this.Name = "frm_adminDashboard";
            this.Text = "frm_adminDashboard";
            this.Load += new System.EventHandler(this.frm_adminDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblTotalBooks;
        private System.Windows.Forms.Label lblCurrentlyBorrowed;
        private System.Windows.Forms.Label lblTotalMembers;
        private System.Windows.Forms.Button btnManageBooks;
        private System.Windows.Forms.Button btnBorrowBook;
        private System.Windows.Forms.Button btnManageMembers;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Button btnLogout;
    }
}