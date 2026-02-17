namespace Kakeibo.WinForms
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.registerButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.kakeiboDataGrid = new System.Windows.Forms.DataGridView();
            this.category = new System.Windows.Forms.TextBox();
            this.price = new System.Windows.Forms.MaskedTextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.memo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.日付DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.カテゴリDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.金額DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.メモDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kakeiboDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kakeiboDataSet = new Kakeibo.WinForms.KakeiboDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.kakeiboDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kakeiboDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kakeiboDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(500, 290);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(75, 50);
            this.registerButton.TabIndex = 0;
            this.registerButton.Text = "登録";
            this.registerButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(603, 290);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 50);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "編集";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButtonClicked);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(713, 290);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 50);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "削除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClicked);
            // 
            // kakeiboDataGrid
            // 
            this.kakeiboDataGrid.AutoGenerateColumns = false;
            this.kakeiboDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kakeiboDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.日付DataGridViewTextBoxColumn,
            this.カテゴリDataGridViewTextBoxColumn,
            this.金額DataGridViewTextBoxColumn,
            this.メモDataGridViewTextBoxColumn});
            this.kakeiboDataGrid.DataSource = this.kakeiboDataTableBindingSource;
            this.kakeiboDataGrid.Location = new System.Drawing.Point(13, 12);
            this.kakeiboDataGrid.Name = "kakeiboDataGrid";
            this.kakeiboDataGrid.RowHeadersWidth = 62;
            this.kakeiboDataGrid.RowTemplate.Height = 27;
            this.kakeiboDataGrid.Size = new System.Drawing.Size(775, 197);
            this.kakeiboDataGrid.TabIndex = 3;
            // 
            // category
            // 
            this.category.Location = new System.Drawing.Point(92, 284);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(368, 25);
            this.category.TabIndex = 4;
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(92, 315);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(368, 25);
            this.price.TabIndex = 5;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(92, 229);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "日付";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "カテゴリ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "金額";
            // 
            // memo
            // 
            this.memo.Location = new System.Drawing.Point(92, 356);
            this.memo.Name = "memo";
            this.memo.Size = new System.Drawing.Size(368, 25);
            this.memo.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "メモ";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Width = 150;
            // 
            // 日付DataGridViewTextBoxColumn
            // 
            this.日付DataGridViewTextBoxColumn.DataPropertyName = "日付";
            this.日付DataGridViewTextBoxColumn.HeaderText = "日付";
            this.日付DataGridViewTextBoxColumn.MinimumWidth = 8;
            this.日付DataGridViewTextBoxColumn.Name = "日付DataGridViewTextBoxColumn";
            this.日付DataGridViewTextBoxColumn.Width = 150;
            // 
            // カテゴリDataGridViewTextBoxColumn
            // 
            this.カテゴリDataGridViewTextBoxColumn.DataPropertyName = "カテゴリ";
            this.カテゴリDataGridViewTextBoxColumn.HeaderText = "カテゴリ";
            this.カテゴリDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.カテゴリDataGridViewTextBoxColumn.Name = "カテゴリDataGridViewTextBoxColumn";
            this.カテゴリDataGridViewTextBoxColumn.Width = 150;
            // 
            // 金額DataGridViewTextBoxColumn
            // 
            this.金額DataGridViewTextBoxColumn.DataPropertyName = "金額";
            this.金額DataGridViewTextBoxColumn.HeaderText = "金額";
            this.金額DataGridViewTextBoxColumn.MinimumWidth = 8;
            this.金額DataGridViewTextBoxColumn.Name = "金額DataGridViewTextBoxColumn";
            this.金額DataGridViewTextBoxColumn.Width = 150;
            // 
            // メモDataGridViewTextBoxColumn
            // 
            this.メモDataGridViewTextBoxColumn.DataPropertyName = "メモ";
            this.メモDataGridViewTextBoxColumn.HeaderText = "メモ";
            this.メモDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.メモDataGridViewTextBoxColumn.Name = "メモDataGridViewTextBoxColumn";
            this.メモDataGridViewTextBoxColumn.Width = 150;
            // 
            // kakeiboDataTableBindingSource
            // 
            this.kakeiboDataTableBindingSource.DataMember = "kakeiboDataTable";
            this.kakeiboDataTableBindingSource.DataSource = this.kakeiboDataSet;
            // 
            // kakeiboDataSet
            // 
            this.kakeiboDataSet.DataSetName = "KakeiboDataSet";
            this.kakeiboDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.memo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.price);
            this.Controls.Add(this.category);
            this.Controls.Add(this.kakeiboDataGrid);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.registerButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.kakeiboDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kakeiboDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kakeiboDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridView kakeiboDataGrid;
        private System.Windows.Forms.TextBox category;
        private System.Windows.Forms.MaskedTextBox price;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox memo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 日付DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn カテゴリDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 金額DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn メモDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource kakeiboDataTableBindingSource;
        private KakeiboDataSet kakeiboDataSet;
    }
}

