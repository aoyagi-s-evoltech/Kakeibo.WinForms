using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Kakeibo.WinForms.Net8
{
    /// <summary>
    /// メイン画面
    /// 入力フォーム（項目・日付・金額・メモ）と一覧表示(DataGridView)の管理、
    /// データの追加・編集・削除・保存処理を担当する
    /// </summary>
    public partial class Kakeibo : Form
    {
        private IExpenseRepository repository;
        private DataTable table;

        /// <summary>
        /// フォームの初期化処理
        /// </summary>
        public Kakeibo()
        {
            InitializeComponent();
            SQLitePCL.Batteries_V2.Init();
            repository = new SqliteExpenseRepository();
            table = new DataTable();
        }

        /// <summary>
        /// フォーム起動時にデータを読み込み、一覧に反映する
        /// SQLiteまたはXMLからの読み込みを行う
        /// </summary>
        /// <param name="sender">イベントの送信元</param>
        /// <param name="e">イベントデータ</param>
        private void Kakeibo_Load(object sender, EventArgs e)
        {
            if(File.Exists("expenses.db"))
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
                DataPropertyName = "Id"
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

            // No列(連番)
            kakeiboDataGrid.Columns.Insert(0, new DataGridViewTextBoxColumn
            {
                Name = "No",
                HeaderText = "No",
                ReadOnly = true,
                Width = 40
            });

            //// No 列
            //kakeiboDataGrid.Columns["No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //kakeiboDataGrid.Columns["No"].Width = 50;
            //// 金額列
            //kakeiboDataGrid.Columns["PriceColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //kakeiboDataGrid.Columns["PriceColumn"].DefaultCellStyle.Format = "N0";
            //kakeiboDataGrid.Columns["PriceColumn"].Width = 100;
            
            //// メモ列
            //kakeiboDataGrid.Columns["MemoColumn"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //kakeiboDataGrid.Columns["MemoColumn"].Width = 200;
            //// 行の高さ自動調整
            //kakeiboDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //// 行ヘッダー非表示
            //kakeiboDataGrid.RowHeadersVisible = false; 
            //// 選択行を分かりやすく
            //kakeiboDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //kakeiboDataGrid.MultiSelect = false;

            kakeiboDataGrid.DataSource = table;

            Reload();
        }

        /// <summary>
        /// データをリポジトリから読み込み、DataGridViewに反映する
        /// </summary>
        /// <remarks> 
        /// DataTableを一度クリアしてから再構築する
        /// No列は1からの連番を振り直す
        /// DataGridViewのDataSourceを再設定して反映させる
        /// </remarks>
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

            // No列に連番を振る
            for (int i = 0; i < kakeiboDataGrid.Rows.Count; i++)
            {
                kakeiboDataGrid.Rows[i].Cells["No"].Value = i + 1;
            }
        }

        /// <summary>
        /// 入力された内容を新規登録し、一覧を更新する
        /// </summary>
        /// <param name="sender">登録ボタン</param>
        /// <param name="e">イベントデータ</param>
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

        /// <summary>
        /// 選択された行の内容を編集し、保存後に一覧を更新する
        /// </summary>
        /// <param name="sender">編集ボタン</param>
        /// <param name="e">イベントデータ</param>
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

        /// <summary>
        /// 選択された行を削除し、一覧を更新する
        /// </summary>
        /// <param name="sender">削除ボタン</param>
        /// <param name="e">イベントデータ</param>
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

        /// <summary>
        /// 入力欄を初期状態に戻す
        /// </summary>
        /// <param name="sender">クリアボタン</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// 日付は今日の日付に戻す
        /// カテゴリは未選択状態に戻す
        /// 金額とメモは空文字にする
        /// </remarks>
        private void clearButton_Click(object sender, EventArgs e)
        {
            datePicker.Value = DateTime.Today;
            categoryText.SelectedIndex = -1;
            priceText.Text = "";
            memoText.Text = "";
        }
    }
}