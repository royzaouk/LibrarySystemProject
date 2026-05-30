namespace LibrarySystem
{
    partial class frm_borrowBook
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
            this.lblMember = new System.Windows.Forms.Label();
            this.cmbMember = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBook = new System.Windows.Forms.ComboBox();
            this.lblBorrowDate = new System.Windows.Forms.Label();
            this.dtpBorrowDate = new System.Windows.Forms.DateTimePicker();
            this.btnConfirmBorrow = new System.Windows.Forms.Button();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMember
            // 
            this.lblMember.AutoSize = true;
            this.lblMember.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMember.ForeColor = System.Drawing.SystemColors.Control;
            this.lblMember.Location = new System.Drawing.Point(24, 32);
            this.lblMember.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(140, 36);
            this.lblMember.TabIndex = 53;
            this.lblMember.Text = "Member :";
            // 
            // cmbMember
            // 
            this.cmbMember.DisplayMember = "FullName";
            this.cmbMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMember.FormattingEnabled = true;
            this.cmbMember.Location = new System.Drawing.Point(230, 44);
            this.cmbMember.Name = "cmbMember";
            this.cmbMember.Size = new System.Drawing.Size(272, 24);
            this.cmbMember.TabIndex = 54;
            this.cmbMember.ValueMember = "UserID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(24, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 36);
            this.label1.TabIndex = 55;
            this.label1.Text = "Book :";
            // 
            // cmbBook
            // 
            this.cmbBook.DisplayMember = "Title";
            this.cmbBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBook.FormattingEnabled = true;
            this.cmbBook.Location = new System.Drawing.Point(230, 105);
            this.cmbBook.Name = "cmbBook";
            this.cmbBook.Size = new System.Drawing.Size(272, 24);
            this.cmbBook.TabIndex = 56;
            this.cmbBook.ValueMember = "BookID";
            // 
            // lblBorrowDate
            // 
            this.lblBorrowDate.AutoSize = true;
            this.lblBorrowDate.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBorrowDate.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBorrowDate.Location = new System.Drawing.Point(24, 161);
            this.lblBorrowDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBorrowDate.Name = "lblBorrowDate";
            this.lblBorrowDate.Size = new System.Drawing.Size(199, 36);
            this.lblBorrowDate.TabIndex = 57;
            this.lblBorrowDate.Text = "Borrow Date :";
            // 
            // dtpBorrowDate
            // 
            this.dtpBorrowDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBorrowDate.Location = new System.Drawing.Point(230, 175);
            this.dtpBorrowDate.Name = "dtpBorrowDate";
            this.dtpBorrowDate.Size = new System.Drawing.Size(272, 22);
            this.dtpBorrowDate.TabIndex = 58;
            // 
            // btnConfirmBorrow
            // 
            this.btnConfirmBorrow.Location = new System.Drawing.Point(271, 295);
            this.btnConfirmBorrow.Name = "btnConfirmBorrow";
            this.btnConfirmBorrow.Size = new System.Drawing.Size(172, 34);
            this.btnConfirmBorrow.TabIndex = 59;
            this.btnConfirmBorrow.Text = "Confirm Borrow";
            this.btnConfirmBorrow.UseVisualStyleBackColor = true;
            this.btnConfirmBorrow.Click += new System.EventHandler(this.btnConfirmBorrow_Click);
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReturnDate.Location = new System.Drawing.Point(230, 228);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(272, 22);
            this.dtpReturnDate.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(24, 214);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 36);
            this.label2.TabIndex = 60;
            this.label2.Text = "Return Date :";
            // 
            // frm_borrowBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(800, 612);
            this.Controls.Add(this.dtpReturnDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConfirmBorrow);
            this.Controls.Add(this.dtpBorrowDate);
            this.Controls.Add(this.lblBorrowDate);
            this.Controls.Add(this.cmbBook);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMember);
            this.Controls.Add(this.lblMember);
            this.Name = "frm_borrowBook";
            this.Text = "frm_borrowBook";
            this.Load += new System.EventHandler(this.frm_borrowBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.ComboBox cmbMember;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBook;
        private System.Windows.Forms.Label lblBorrowDate;
        private System.Windows.Forms.DateTimePicker dtpBorrowDate;
        private System.Windows.Forms.Button btnConfirmBorrow;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.Label label2;
    }
}