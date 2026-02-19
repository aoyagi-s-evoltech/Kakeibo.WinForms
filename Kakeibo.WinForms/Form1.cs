using System;
using System.IO;
using System.Windows.Forms;

namespace Kakeibo.WinForms
{
    public partial class Form1 : Form
    {
        private IExpenseRepository repository;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// アプリ起動時にRepositoryを選択し、データを読み込む
        /// </summary>
        /// <param name="sender">フォーム本体</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// SQLiteが存在する場合はSQLiteを、存在しない場合はXMLを使用する
        /// </remarks>
        private void Form1_Load(object sender, EventArgs e)
        {
            // SQLiteが存在するか確認し、存在しない場合は新規作成する
            if (File.Exists("expenses.db"))
            {
                repository = new SqliteExpenseRepository();
            }
            else
            {
                // 後で作成
                repository = new XmlExpenseRepository();
            }
            Reload();
        }

        /// <summary>
        /// Repositoryから最新のデータを取得し、DataGridViewに表示する
        /// </summary>
        /// <remarks>
        /// DBまたはXMLの内容を画面に反映させるための共通処理
        /// </remarks>
        private void Reload()
        {
            // Repositoryから最新データを取得
            var items = repository.GetAll();

            // DataTableをクリア
            kakeiboDataSet.kakeiboDataTable.Clear();

            // DataTableにデータを追加
            foreach (var expense in items)
            {
                kakeiboDataSet.kakeiboDataTable.AddkakeiboDataTableRow(
                    expense.Date,
                    expense.Category,
                    expense.Price,
                    expense.Memo
                );
            }
        }

        /// <summary>
        /// ユーザーから入力された内容をもとに、あたらしい支出データを作成し、Repositoryに保存する
        /// </summary>
        /// <param name="sender">クリックされた登録ボタン</param>
        /// <param name="e">クリックイベントの情報</param>
        /// <remarks>
        /// 更新後はReload()で画面を最新状態にする
        /// </remarks>
        private void registerButton_Click(object sender, EventArgs e)
        {
            var expense = new Expense
            {
                Date = dateTimePicker.Value,
                Category = category.Text,
                Price = int.Parse(price.Text),
                Memo = memo.Text
            };

            repository.Insert(expense);
            Reload();
        }

        /// <summary>
        /// 選択された支出データを入力欄の内容で更新する
        /// </summary>
        /// <param name="sender">クリックされた編集ボタン</param>
        /// <param name="e">クリックイベントの情報</param>
        /// <remarks>
        /// DataGridViewからIDを取得し、該当データのみを更新する
        /// 更新後はReload()で画面を最新状態にする
        /// </remarks>
        private void editButton_Click(object sender, EventArgs e)
        {
            // 選択された行のデータを編集する
            int rowIndex = kakeiboDataGrid.CurrentRow.Index;
            int id = (int)kakeiboDataGrid.Rows[rowIndex].Cells["Id"].Value;

            var expense = new Expense
            {
                Id = id,
                Date = dateTimePicker.Value,
                Category = category.Text,
                Price = int.Parse(price.Text),
                Memo = memo.Text
            }; 
            
            repository.Update(expense);
            Reload();
        }

        /// <summary>
        /// 選択された支出データを削除する
        /// </summary>
        /// <param name="sender">クリックされた削除ボタン</param>
        /// <param name="e">クリックイベントの情報</param>
        /// <remarks>
        /// DataGridViewからIDを取得し、該当データのみを削除する
        /// 更新後はReload()で画面を最新状態にする
        /// </remarks>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            // 選択した行のデータを削除する
            int rowIndex = kakeiboDataGrid.CurrentRow.Index;
            int id = (int)kakeiboDataGrid.Rows[rowIndex].Cells["Id"].Value;

            repository.Delete(id);
            Reload();
        }
    }
}
