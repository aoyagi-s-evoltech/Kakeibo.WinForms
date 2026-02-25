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
            datePicker = new DateTimePicker();
            categoryText = new ComboBox();
            priceText = new TextBox();
            memoText = new TextBox();
            registerButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            clearButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)kakeiboDataGrid).BeginInit();
            SuspendLayout();
            // 
            // kakeiboDataGrid
            // 
            kakeiboDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            kakeiboDataGrid.Location = new Point(40, 12);
            kakeiboDataGrid.Name = "kakeiboDataGrid";
            kakeiboDataGrid.RowHeadersWidth = 62;
            kakeiboDataGrid.Size = new Size(1032, 355);
            kakeiboDataGrid.TabIndex = 0;
            // 
            // datePicker
            // 
            datePicker.Location = new Point(159, 397);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(449, 31);
            datePicker.TabIndex = 1;
            // 
            // categoryText
            // 
            categoryText.FormattingEnabled = true;
            categoryText.Items.AddRange(new object[] { "食費", "日用品", "衣服", "交通費", "固定費", "医療", "交際費", "娯楽", "美容", "その他" });
            categoryText.Location = new Point(159, 447);
            categoryText.Name = "categoryText";
            categoryText.Size = new Size(449, 33);
            categoryText.TabIndex = 2;
            // 
            // priceText
            // 
            priceText.Location = new Point(159, 507);
            priceText.Name = "priceText";
            priceText.Size = new Size(449, 31);
            priceText.TabIndex = 3;
            // 
            // memoText
            // 
            memoText.Location = new Point(159, 562);
            memoText.Name = "memoText";
            memoText.Size = new Size(449, 31);
            memoText.TabIndex = 4;
            // 
            // registerButton
            // 
            registerButton.Location = new Point(725, 448);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(81, 73);
            registerButton.TabIndex = 5;
            registerButton.Text = "追加";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(848, 447);
            editButton.Name = "editButton";
            editButton.Size = new Size(89, 74);
            editButton.TabIndex = 6;
            editButton.Text = "編集";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(985, 447);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(87, 74);
            deleteButton.TabIndex = 7;
            deleteButton.Text = "削除";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(630, 539);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(112, 34);
            clearButton.TabIndex = 8;
            clearButton.Text = "クリア";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 402);
            label1.Name = "label1";
            label1.Size = new Size(48, 25);
            label1.TabIndex = 9;
            label1.Text = "日付";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 455);
            label2.Name = "label2";
            label2.Size = new Size(64, 25);
            label2.TabIndex = 10;
            label2.Text = "カテゴリ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 507);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 11;
            label3.Text = "金額";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 562);
            label4.Name = "label4";
            label4.Size = new Size(38, 25);
            label4.TabIndex = 12;
            label4.Text = "メモ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 624);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
