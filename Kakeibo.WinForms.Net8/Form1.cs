using System.Data;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kakeibo.WinForms.Net8
{
    public partial class Form1 : Form
    {
        private IExpenseRepository repository;
        private DataTable table;

        public Form1()
        {
            InitializeComponent();
            SQLitePCL.Batteries_V2.Init();
            repository = new SqliteExpenseRepository();

            table = new DataTable();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("expenses.db"))
            {
                repository = new SqliteExpenseRepository();
            }
            else
            {
                repository = new XmlExpenseRepository();
            }

            // DataTable の列
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("Price", typeof(int));
            table.Columns.Add("Memo", typeof(string));

            kakeiboDataGrid.AutoGenerateColumns = false;

            // DataGridView の列をコードで作る
            kakeiboDataGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Visible = false
            });

            kakeiboDataGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DateColumn",
                HeaderText = "日付",
                DataPropertyName = "Date"
            });

            kakeiboDataGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CategoryColumn",
                HeaderText = "カテゴリ",
                DataPropertyName = "Category"
            });

            kakeiboDataGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PriceColumn",
                HeaderText = "金額",
                DataPropertyName = "Price"
            });

            kakeiboDataGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MemoColumn",
                HeaderText = "メモ",
                DataPropertyName = "Memo"
            });

            // No 列
            kakeiboDataGrid.Columns.Insert(0, new DataGridViewTextBoxColumn
            {
                Name = "No",
                HeaderText = "No",
                ReadOnly = true,
                Width = 40
            });

            kakeiboDataGrid.DataSource = table;

            Reload();
        }


        private void Reload()
        {
            var items = repository.GetAll();
            table.Rows.Clear();

            foreach (var expense in items)
            {
                table.Rows.Add(
                    expense.Id,
                    expense.Date,
                    expense.Category,
                    expense.Price,
                    expense.Memo
                );
            }

            kakeiboDataGrid.DataSource = table;

            // No 列に連番を振る
            for (int i = 0; i < kakeiboDataGrid.Rows.Count; i++)
            {
                kakeiboDataGrid.Rows[i].Cells["No"].Value = i + 1;
            }
        }
        private void registerButton_Click(object sender, EventArgs e)
        {
            var expense = new Expense
            {
                Date = datePicker.Value,
                Category = categoryText.Text,
                Price = int.Parse(priceText.Text),
                Memo = memoText.Text
            };

            repository.Insert(expense);
            Reload();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (kakeiboDataGrid.CurrentRow == null) return;

            int id = (int)kakeiboDataGrid.CurrentRow.Cells["id"].Value;

            var expense = new Expense
            {
                Id = id,
                Date = datePicker.Value,
                Category = categoryText.Text,
                Price = int.Parse(priceText.Text),
                Memo = memoText.Text
            };

            repository.Update(expense);
            Reload();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (kakeiboDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("削除する行を選択してください。");
                return;
            }

            int id = (int)kakeiboDataGrid.SelectedRows[0].Cells["id"].Value;
            repository.Delete(id);
            Reload();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            datePicker.Value = DateTime.Today;
            categoryText.SelectedIndex = -1;
            categoryText.Text = "";
            priceText.Text = "";
            memoText.Text = "";
        }
    }
}