using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Kakeibo.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ユーザーから入力された内容をもとに、DataTableにあたらしい行を追加する
        /// </summary>
        /// <param name="sender">クリックされた登録ボタン</param>
        /// <param name="e">クリックイベントの情報</param>
        private void registerButton_Click(object sender, EventArgs e)
        {
            // DataTableにデータを追加する
            kakeiboDataSet.kakeiboDataTable.AddkakeiboDataTableRow(
                dateTimePicker.Value,
                this.category.Text,
                int.Parse(this.price.Text),
                this.memo.Text
            );
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            // 選択された行のデータを編集する
            int rowIndex = this.kakeiboDataGrid.CurrentRow.Index;

            var row = this.kakeiboDataSet.kakeiboDataTable[rowIndex];

            // 入力欄の内容で上書き（＝編集）
            row.日付 = dateTimePicker.Value;
            row.カテゴリ = category.Text; 
            row.金額 = int.Parse(price.Text);
            row.メモ = memo.Text;
        }

        /// <summary>
        /// 選択された行データ行を削除する
        /// </summary>
        /// <param name="sender">クリックされた削除ボタン</param>
        /// <param name="e">クリックイベントの情報</param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            // 選択した行のデータを削除する
            int row = this.kakeiboDataGrid.CurrentRow.Index;
            this.kakeiboDataGrid.Rows.RemoveAt(row);
        }

        /// <summary>
        /// アプリ起動時に実行される初期化処理
        /// SQLiteデータベースへ接続し、
        /// 読み込んだデータをDataTableに反映する
        /// </summary>
        /// <param name="sender">フォーム本体</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// 初回起動時のみテーブルを作成
        /// 読み込んだデータはDataTableに反映され、DataGridViewに表示される
        /// </remarks>
        private void Form1_Load(object sender, EventArgs e)
        {
            // SQLiteに接続
            using (var connection = new SqliteConnection("Data Source = kakeibo.db"))
            {
                connection.Open();

                CreateTableIfNotExists(connection);
                LoadExpensesToDataTable(connection);
            }
        }

        /// <summary>
        /// expensesテーブルが存在しない場合のみテーブルを作成する
        /// </summary>
        /// <param name="connection">SQLiteの接続</param>
        /// <remarks>
        /// 既存テーブルがある場合にエラーが起きることを防ぐため
        /// CREATE TABLEにIF NOT EXISTSを付けている
        private void CreateTableIfNotExists(SqliteConnection connection)
        {
            // 存在しない場合、テーブルを作成。
            string createTableSql = @"
                    CREATE TABLE IF NOT EXISTS expenses (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date TEXT,
                        Category TEXT,
                        Amount INTEGER,
                        Memo TEXT 
                        );
                    ";

            using (var command = new SqliteCommand(createTableSql, connection))
            { 
                command.ExecuteNonQuery();
            }   
        }

        /// <summary>
        /// SQLiteから全件のデータを取得し、
        /// DataTableに反映する
        /// </summary>
        /// <param name="connection">SQLiteの接続</param>
        /// <remarks>
        /// SQLiteから取得したデータをDataTableに入れ直し、
        /// DataGridVie の表示を最新の状態に更新する
        /// </remarks>
        private void LoadExpensesToDataTable(SqliteConnection connection)
        {
            string selectSql = "SELECT Id, Date, Category, Amount, Memo FROM expenses";

            using (var selectCommand = new SqliteCommand(selectSql, connection))
            using (var reader = selectCommand.ExecuteReader())
            {
                // DataTableをクリア
                kakeiboDataSet.kakeiboDataTable.Clear();

                // 1行ずつ読み込みDataTableに追加
                while (reader.Read())
                {
                    // SQLiteのTEXTをDateTimeに変換
                    DateTime date = DateTime.Parse(reader["Date"].ToString());

                    kakeiboDataSet.kakeiboDataTable.AddkakeiboDataTableRow(
                        date,
                        reader["Category"].ToString(),
                        int.Parse(reader["Amount"].ToString()),
                        reader["Memo"].ToString()
                    );
                }
            }
        }
    }
}
