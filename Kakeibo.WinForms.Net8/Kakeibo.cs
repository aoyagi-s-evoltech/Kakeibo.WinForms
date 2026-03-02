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
            // SQLitePCL.rawを初期化
            SQLitePCL.Batteries_V2.Init();
            repository = new SqliteExpenseRepository();
            table = new DataTable();
        }

        private void Kakeibo_Load1(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// フォーム起動時にデータを読み込み、一覧に反映する
        /// SQLiteまたはXMLからの読み込みを行う
        /// </summary>
        /// <param name="sender">イベントの送信元</param>
        /// <param name="e">イベントデータ</param>
        private void Kakeibo_Load(object sender, EventArgs e)
        {
            // リポジトリの初期化
            if (File.Exists("expenses.db"))
            {
                repository = new SqliteExpenseRepository();
            }
            else
            {
                repository = new XmlExpenseRepository();
            }

            // DataTableの列定義
            if(table.Columns.Count == 0)
            {
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("Date", typeof(DateTime));
                table.Columns.Add("Category", typeof(string));
                table.Columns.Add("Price", typeof(int));
                table.Columns.Add("Memo", typeof(string));
            }

            kakeiboDataGrid.AutoGenerateColumns = false;

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
            // 入力内容のチェック
            if (!CheckInput(out int price)) return;

            // 問題ないとわかったデータでリポジトリに登録処理を行う
            var expense = new Expense
            {
                Date = datePicker.Value,
                Category = categoryText.Text,
                Price = price,
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
            // 行が選択されているかチェック
            if (!HasData())
            {
                MessageBox.Show(this, "編集できるデータがありません。", "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 入力内容のチェック
            if(!CheckInput(out int price)) return;

            int id = (int)kakeiboDataGrid.CurrentRow.Cells["Id"].Value;

            var expense = new Expense
            {
                Id = id,
                Date = datePicker.Value,
                Category = categoryText.Text,
                Price = price,
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
            // 行が選択されているかチェック
            if (!HasData())
            {
                MessageBox.Show(this, "削除できるデータがありません。", "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = (int)kakeiboDataGrid.CurrentRow.Cells["Id"].Value;
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
            categoryText.Text = "";
            priceText.Text = "";
            memoText.Text = "";
        }
       
        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <param name="price">入力された金額</param>
        /// <returns>入力が整数の場合はtrue、それ以外の無効な入力の場合はfalse </returns>
        private bool CheckInput(out int price)
        {
            // 初期化
            price = 0;

            // カテゴリのチェック
            if(string.IsNullOrWhiteSpace(categoryText.Text))
            {
                MessageBox.Show(this, "カテゴリを入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 金額のチェック
            if (!int.TryParse(priceText.Text, out price))
            {
                MessageBox.Show(this, "金額は整数で入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // OKならtrueを返す
            return true;
        }

        /// <summary>
        /// データが存在するかどうかを確認する
        /// </summary>
        /// <returns>データが存在する場合はtrue、存在しない場合はfalse</returns>
        private bool HasData()
        {
            return kakeiboDataGrid.Rows.Count > 0;
        }
    }
}