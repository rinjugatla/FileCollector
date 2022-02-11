using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;

namespace WindowsFormsApplication3
{
    public partial class fomr1 : Form
    {

        public fomr1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Button_Click(object sender, EventArgs e)
        {
            Url_TextBox.Text = "";
            Start_NumericUpDown.Text = "0";
            End_NumericUpDown.Text = "0";
        }

        /// <summary>
        /// 生成されるURLを確認
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckGenerateUrl_Button_Click(object sender, EventArgs e)
        {
            var urls = GenerateUrl();

            var header = "\r\n----- URL確認 -----\r\n";
            var sb = new StringBuilder($"{header}{urls.Count}件のURLを生成\r\n");
            sb.AppendLine(string.Join("\r\n", urls));
            Log_TextBox.AppendText(sb.ToString());
        }

        /// <summary>
        /// URLを作成
        /// </summary>
        /// <returns>連番URL</returns>
        private List<string> GenerateUrl()
        {
            if (!IsValidBaseUrl()) { return new List<string>(); }

            int start = int.Parse(Start_NumericUpDown.Text);
            int end = int.Parse(End_NumericUpDown.Text);
            if (start > end) { (start, end) = (end, start); }

            var baseUrl = Url_TextBox.Text;
            var format = Format_TextBox.Text;
            var urls = new List<string>();
            for (int i = start; i < end + 1; i++)
            {
                var url = baseUrl.Replace(":num:", i.ToString(format));
                urls.Add(url);
            }

            return urls;
        }

        /// <summary>
        /// 基本のURLが有効か判定
        /// </summary>
        /// <returns></returns>
        private bool IsValidBaseUrl()
        {
            if (Url_TextBox.Text.Length == 0)
            {
                MessageBox.Show("URLを指定してください。");
                return false;
            }
            else if (!Regex.IsMatch(Url_TextBox.Text, "^https?://"))
            {
                MessageBox.Show("URLはhttp://またはhttps://から指定してください。");
                return false;
            }

            return true;
        }

        /// <summary>
        /// ダウンロードを開始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Download_Button_Click(object sender, EventArgs e)
        {
            
            System.Threading.Thread t =
                new System.Threading.Thread(
                new System.Threading.ThreadStart(LDownload));
            t.Start();

        }

        /// <summary>
        /// 連番ファイルをダウンロード
        /// </summary>
        public void LDownload()
        {

            Clear_Button.Enabled = false;
            CheckGenerateUrl_Button.Enabled = false;
            Download_Button.Enabled = false;
            SaveDirectoryBrowse_Button.Enabled = false;
            UrlFileBrowse_Button.Enabled = false;
            OpenUrlFile_Button.Enabled = false;
            OpenSaveDirectory_Button.Enabled = false;

            string URLlistFile = "";

            if (UrlFilePath_TextBox.Text == "")
            {

                URLlistFile = "URL-list.txt";

            }
            else
            {

                URLlistFile = UrlFilePath_TextBox.Text;

            }

            //開始時刻を取得
            //現在の時刻を取得
            DateTime Sterttime = DateTime.Now;

            int start = System.Environment.TickCount;

            if (File.Exists(URLlistFile))
            {
                //ファイルが存在する場合の処理

                StreamReader reader = new StreamReader(URLlistFile, Encoding.GetEncoding("Shift_JIS"));
                string A;
                while ((A = reader.ReadLine()) != null)
                {

                    //textBox3.Textの初期化+logの書き出し
                    Log_TextBox.Text = "";
                    Log_TextBox.Text += ("-----読み込んだURL:" + A + "-----\r\n\r\n");
                    if (SaveLog_CheckBox.Checked) System.IO.File.AppendAllText("log.txt", "-----読み込んだURL:" + A + "-----\r\n");

                    // 相対アドレス指定で使うベースアドレス
                    string baseurl = "";

                    // 引数をチェック

                    /*
                    if (A.Length != 1)
                    {
                        // 引数の数が不正な場合
                        Console.WriteLine("引数にURLを指定してください");
                        return;

                    }
                    */

                    //else if (!A.ToLower().StartsWith("http://"))
                    if (!A.ToLower().StartsWith("http://"))
                    {
                        // 引数が「http://」で始まっていない場合
                        Log_TextBox.Text += ("URLは「http://」で始まっている必要があります");
                        return;

                    }
                    else
                    {
                        if ((A.ToLower().StartsWith("http://")) && (A.Length == 7))
                        {
                            // 引数が「http://」しかない場合
                            Log_TextBox.Text += ("URLが不正です");
                            return;
                        }
                    }



                    // 相対アドレス指定で使うベースアドレスを作成
                    int pos = A.LastIndexOf("/");
                    if ((A.ToLower().StartsWith("http://")) && (pos == 6))
                    {
                        // 「http://」以降に「/」が１つも見つからない場合は最後に「/」を付け足す
                        baseurl = A + "/";
                    }
                    else
                    {
                        // 最後に見つかった「/」まででURLをちぎる
                        baseurl = A.Substring(0, pos + 1);
                    }

                    try
                    {
                        // WebClient，Stream，StreamReaderを作成 proxyの有無は大して差はなし
                        WebClient wc = new WebClient();
                        wc.Proxy = null;
                        Stream st = wc.OpenRead(A);
                        StreamReader sr = new StreamReader(st);

                        // ストリームをすべて読み取る
                        String strHtml = sr.ReadToEnd();

                        // Stream，StreamReaderを閉じる Closeで閉じると解放しない
                        sr.Dispose();
                        st.Dispose();

                        // 「src」を探し出す正規表現を作成
                        Regex rHREF = new Regex("href\\s*=\\s*(?:\"(?<1>[^\"]*)\"|(?<1>\\S+))",
                        RegexOptions.IgnoreCase | RegexOptions.Compiled);

                        // Matchを作成
                        Match mHREF;

                        // 「src」を探して、それが .jpg .gif .png で終わる場合はファイルを取得
                        for (mHREF = rHREF.Match(strHtml); mHREF.Success; mHREF = mHREF.NextMatch())
                        {
                            // 「src=""」の「""」の中身を取得
                            string val = mHREF.Groups[1].Value;

                            // 拡張子をチェック
                            if (val.ToLower().EndsWith(".jpg") || val.ToLower().EndsWith(".jpeg") || val.ToLower().EndsWith(".gif") || val.ToLower().EndsWith(".png")
                                || val.ToLower().EndsWith(".zip") || val.ToLower().EndsWith(".rar") || val.ToLower().EndsWith(".lzh")
                                || val.ToLower().EndsWith(".avi") || val.ToLower().EndsWith(".wmv") || val.ToLower().EndsWith(".mp4") || val.ToLower().EndsWith(".flv") || val.ToLower().EndsWith(".divx")
                                || val.ToLower().EndsWith(".mp3") || val.ToLower().EndsWith(".acc"))
                            {

                                Log_TextBox.Text += ("Downloading " + val + " ... ");
                                //textBox3.Text += ("Downloading " + baseurl + " ... ");
                                if (SaveLog_CheckBox.Checked) System.IO.File.AppendAllText("log.txt", "Downloading " + val + " ... ");

                                // ローカルディスクに保存するときの名前を作成
                                string lcfile = val;
                                if (val.IndexOf("/") != -1)
                                {
                                    // ファイル名にパスが含まれている場合は取り除く
                                    lcfile = val.Substring(val.LastIndexOf("/") + 1);
                                }

                                // リモートファイルが相対アドレス指定の場合はBaseAddressを設定する
                                if (!val.ToLower().StartsWith("http://"))
                                {
                                    wc.BaseAddress = baseurl;
                                }
                                else
                                {
                                    wc.BaseAddress = "";
                                }

                                // 必要な変数を宣言する
                                string stURLData = A;

                                // スラッシュ区切りで分割して配列に格納する
                                string[] stArrayData = stURLData.Split('/');

                                //nにstArrayDataの配列数を取得
                                string n = stArrayData.Length.ToString();

                                //先頭から.の位置を取得
                                int find1 = val.LastIndexOf('.');

                                //valの拡張子部分のみ取り出し
                                string valKAKU = val.Substring(find1 + 1);

                                string Dpath = "";

                                if (SaveByExtension_CheckBox.Checked)
                                {

                                    if (SaveDirectory_TextBox.Text == "")
                                    {

                                        //ディレクトリ作成
                                        System.IO.Directory.CreateDirectory(stArrayData[2] + "\\" + stArrayData[int.Parse(n) - 2] + "\\" + valKAKU);

                                        //ディレクトリパス設定
                                        Dpath = stArrayData[2] + "\\" + stArrayData[int.Parse(n) - 2] + "\\" + valKAKU + "\\";


                                    }
                                    else
                                    {

                                        //ディレクトリ作成
                                        System.IO.Directory.CreateDirectory(SaveDirectory_TextBox.Text + "\\" + stArrayData[2] + "\\" + stArrayData[int.Parse(n) - 2] + "\\" + valKAKU);

                                        //ディレクトリパス設定
                                        Dpath = SaveDirectory_TextBox.Text + "\\" + stArrayData[2] + "\\" + stArrayData[int.Parse(n) - 2] + "\\" + valKAKU + "\\";


                                    }

                                    // ファイルをローカルのカレントディレクトリにダウンロードする
                                    wc.DownloadFile(val, Dpath + lcfile);

                                }
                                else
                                {

                                    if (SaveDirectory_TextBox.Text == "")
                                    {

                                        //ディレクトリ作成
                                        System.IO.Directory.CreateDirectory(stArrayData[2] + "\\" + stArrayData[int.Parse(n) - 2]);

                                        //ディレクトリパス設定
                                        Dpath = stArrayData[2] + "\\" + stArrayData[int.Parse(n) - 2] + "\\";


                                    }
                                    else
                                    {

                                        //ディレクトリ作成
                                        System.IO.Directory.CreateDirectory(SaveDirectory_TextBox.Text + "\\" + stArrayData[2] + "\\" + stArrayData[int.Parse(n) - 2]);

                                        //ディレクトリパス設定
                                        Dpath = SaveDirectory_TextBox.Text + "\\" + stArrayData[2] + "\\" + stArrayData[int.Parse(n) - 2] + "\\";


                                    }

                                    // ファイルをローカルのカレントディレクトリにダウンロードする
                                    wc.DownloadFile(val, Dpath + lcfile);

                                }

                                //textBox3.Text += ("OK\r\n");
                                Log_TextBox.AppendText("OK\r\n");
                                if (SaveLog_CheckBox.Checked) System.IO.File.AppendAllText("log.txt", "OK\r\n");


                            }

                        }

                        Log_TextBox.Text += ("\r\n-----終了-----\r\n");

                    }
                    catch (Exception c)
                    {
                        // URLのファイルが見つからない等のエラーが発生
                        //MessageBox.Show("エラーが発生しました\r\n\r\n" + c.ToString(),"エラー");
                    }

                }

            }
            else
            {
                //ファイルが存在しない場合の処理
                Log_TextBox.Text = "";
                Log_TextBox.Text += ("URL-list.txtが見つかりません");

            }

            //終了時刻を取得
            //現在の時刻を取得
            DateTime Endtime = DateTime.Now;
            int end = System.Environment.TickCount;
            //経過時間をラベルに表示

            int Totaltime = (end - start);

            int TotaltimeSecond = (Totaltime % 60000) / 1000;
            int TotaltimeMin = Totaltime / 60000;
            if (SaveLog_CheckBox.Checked) System.IO.File.AppendAllText("log.txt", "\r\n-----情報-----\r\n");
            if (SaveLog_CheckBox.Checked) System.IO.File.AppendAllText("log.txt", "開始時刻" + Sterttime.ToLongTimeString() + "\r\n" + "終了時刻" + Endtime.ToLongTimeString() +
                "\r\n" + "DL時間" + TotaltimeMin.ToString() + "分" + TotaltimeSecond.ToString() + "秒");
            if (SaveLog_CheckBox.Checked) System.IO.File.AppendAllText("log.txt", "\r\n-----終了-----\r\n" + "\r\n");

            Clear_Button.Enabled = true;
            CheckGenerateUrl_Button.Enabled = true;
            Download_Button.Enabled = true;
            SaveDirectoryBrowse_Button.Enabled = true;
            UrlFileBrowse_Button.Enabled = true;
            OpenUrlFile_Button.Enabled = true;
            OpenSaveDirectory_Button.Enabled = true;

            return;

        }

        /// <summary>
        /// ファイル保存先フォルダを指定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveDirectoryBrowse_Button_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                //保存先
                SaveDirectory_TextBox.Text += (folderBrowserDialog1.SelectedPath);
            }

        }

        /// <summary>
        /// URLファイルの場所を指定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UrlFileBrowse_Button_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //URL-list.txtファイルの場所
                UrlFilePath_TextBox.Text += (openFileDialog1.FileName);
            }

        }

        /// <summary>
        /// URLファイルを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenUrlFile_Button_Click(object sender, EventArgs e)
        {

            if (SaveDirectory_TextBox.Text == "")
            {
                string startup = Application.StartupPath;
                System.Diagnostics.Process.Start("Notepad", startup);
            }
            else
            {
                System.Diagnostics.Process.Start("Notepad", UrlFilePath_TextBox.Text);
            }


        }

        /// <summary>
        /// 保存先フォルダを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSaveDirectory_Button_Click(object sender, EventArgs e)
        {
            if (SaveDirectory_TextBox.Text == "")
            {
                string startup = Application.StartupPath;
                System.Diagnostics.Process.Start(startup);
            }
            else
            {

                System.Diagnostics.Process.Start(SaveDirectory_TextBox.Text);

            }
        }
    }
}