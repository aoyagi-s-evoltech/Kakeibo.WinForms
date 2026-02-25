namespace Kakeibo.WinForms.Net8
{
    partial class Form1
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
            kakeiboDataGrid = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            Category = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Memo = new DataGridViewTextBoxColumn();
            datePicker = new DateTimePicker();
            categoryText = new ComboBox();
            priceText = new TextBox();
            memoText = new TextBox();
            registerButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            clearButton = new Button();
            ((System.ComponentModel.ISupportInitialize)kakeiboDataGrid).BeginInit();
            SuspendLayout();
            // 
            // kakeiboDataGrid
            // 
            kakeiboDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            kakeiboDataGrid.Columns.AddRange(new DataGridViewColumn[] { Id, Date, Category, Price, Memo });
            kakeiboDataGrid.Location = new Point(40, 12);
            kakeiboDataGrid.Name = "kakeiboDataGrid";
            kakeiboDataGrid.RowHeadersWidth = 62;
            kakeiboDataGrid.Size = new Size(1032, 355);
            kakeiboDataGrid.TabIndex = 0;
            kakeiboDataGrid.CellContentClick += kakeiboDataGrid_CellContentClick;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "id";
            Id.MinimumWidth = 8;
            Id.Name = "Id";
            Id.Width = 150;
            // 
            // Date
            // 
            Date.DataPropertyName = "Date";
            Date.HeaderText = "日付";
            Date.MinimumWidth = 8;
            Date.Name = "Date";
            Date.Width = 150;
            // 
            // Category
            // 
            Category.DataPropertyName = "Category";
            Category.HeaderText = "カテゴリ";
            Category.MinimumWidth = 8;
            Category.Name = "Category";
            Category.Width = 150;
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            Price.HeaderText = "金額";
            Price.MinimumWidth = 8;
            Price.Name = "Price";
            Price.Width = 150;
            // 
            // Memo
            // 
            Memo.DataPropertyName = "Memo";
            Memo.HeaderText = "メモ";
            Memo.MinimumWidth = 8;
            Memo.Name = "Memo";
            Memo.Width = 150;
            // 
            // datePicker
            // 
            datePicker.Location = new Point(89, 393);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(300, 31);
            datePicker.TabIndex = 1;
            datePicker.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // categoryText
            // 
            categoryText.FormattingEnabled = true;
            categoryText.Location = new Point(89, 441);
            categoryText.Name = "categoryText";
            categoryText.Size = new Size(300, 33);
            categoryText.TabIndex = 2;
            categoryText.SelectedIndexChanged += category_SelectedIndexChanged;
            // 
            // priceText
            // 
            priceText.Location = new Point(88, 510);
            priceText.Name = "priceText";
            priceText.Size = new Size(301, 31);
            priceText.TabIndex = 3;
            // 
            // memoText
            // 
            memoText.Location = new Point(89, 574);
            memoText.Name = "memoText";
            memoText.Size = new Size(300, 31);
            memoText.TabIndex = 4;
            // 
            // registerButton
            // 
            registerButton.Location = new Point(661, 464);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(112, 34);
            registerButton.TabIndex = 5;
            registerButton.Text = "追加";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click_1;
            // 
            // editButton
            // 
            editButton.Location = new Point(822, 464);
            editButton.Name = "editButton";
            editButton.Size = new Size(112, 34);
            editButton.TabIndex = 6;
            editButton.Text = "編集";
            editButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(960, 464);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(112, 34);
            deleteButton.TabIndex = 7;
            deleteButton.Text = "削除";
            deleteButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(428, 556);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(112, 34);
            clearButton.TabIndex = 8;
            clearButton.Text = "クリア";
            clearButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 624);
            Controls.Add(clearButton);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(registerButton);
            Controls.Add(memoText);
            Controls.Add(priceText);
            Controls.Add(categoryText);
            Controls.Add(datePicker);
            Controls.Add(kakeiboDataGrid);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)kakeiboDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView kakeiboDataGrid;
        private DateTimePicker datePicker;
        private ComboBox categoryText;
        private TextBox priceText;
        private TextBox memoText;
        private Button registerButton;
        private Button editButton;
        private Button deleteButton;
        private Button clearButton;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Memo;
    }
}
