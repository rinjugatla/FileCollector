using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;

namespace WindowsFormsApplication3
{
    public partial class fomr1 : Form
    {

        public fomr1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxURL.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {


            if ((textBoxURL.Text.Length != 0) || (textBox1.Text.Length != 0) || (textBoxURL.Text.Length != 0))
            {

                int n;

                //ファイル作成
                System.IO.StreamWriter sw =
                new System.IO.StreamWriter("URL-list.txt",
                false,
                System.Text.Encoding.GetEncoding(932));

                if (int.Parse(textBox1.Text) < int.Parse(textBox2.Text))
                {

                    for (n = int.Parse(textBox1.Text); n <= int.Parse(textBox2.Text); n++)
                    {

                        //ファイルに書き出し
                        sw.WriteLine(textBoxURL.Text + n + "/");

                    }

                    //sw.Close();
                    sw.Dispose();

                }
                else
                {

                    MessageBox.Show("開始値が終了値よりも大きく設定されています。", "エラー");

                }

            }
            else
            {

                MessageBox.Show("URL, 開始値, 終了値を確認してください。", "エラー");

            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if ((ch < '0' || ch > '9') && (ch != '\b'))
            {

                e.Handled = true;      //入力取消し

            }

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if ((ch < '0' || ch > '9') && (ch != '\b'))
            {

                e.Handled = true;      //入力取消し

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            System.Threading.Thread t =
                new System.Threading.Thread(
                new System.Threading.ThreadStart(LDownload));
            t.Start();

        }

        public void LDownload()
        {

            button1.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;

            string URLlistFile = "";

            if (textBoxURLlistF.Text == "")
            {

                URLlistFile = "URL-list.txt";

            }
            else
            {

                URLlistFile = textBoxURLlistF.Text;

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
                    textBox3.Text = "";
                    textBox3.Text += ("-----読み込んだURL:" + A + "-----\r\n\r\n");
                    if (checkBox2.Checked) System.IO.File.AppendAllText("log.txt", "-----読み込んだURL:" + A + "-----\r\n");

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
                        textBox3.Text += ("URLは「http://」で始まっている必要があります");
                        return;

                    }
                    else
                    {
                        if ((A.ToLower().StartsWith("http://")) && (A.Length == 7))
                        {
                            // 引数が「http://」しかない場合
                            textBox3.Text += ("URLが不正です");
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

                                textBox3.Text += ("Downloading " + val + " ... ");
                                //textBox3.Text += ("Downloading " + baseurl + " ... ");
                                if (checkBox2.Checked) System.IO.File.AppendAllText("log.txt", "Downloading " + val + " ... ");

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

                                if (checkBox1.Checked)
                                {

                                    if (textBoxExport.Text == "")
                                    {

                                        //ディレクトリ作成
                                        System.IO.Directory.CreateDirectory(stArrayData[2] + "\\" + stArrayData[int.Parse(n) - 2] + "\\" + valKAKU);

                                        //ディレクトリパス設定
                                        Dpath = stArrayData[2] + "\\" + stArrayData[int.Parse(n) - 2] + "\\" + valKAKU + "\\";


                                    }
                                    else
                                    {

                                        //ディレクトリ作成
                                        System.IO.Directory.CreateDirectory(textBoxExport.Text + "\\" + stArrayData[2] + "\\" + stArrayData[int.Parse(n) - 2] + "\\" + valKAKU);

                                        //ディレクトリパス設定
                                        Dpath = textBoxExport.Text + "\\" + stArrayData[2] + "\\" + stArrayData[int.Parse(n) - 2] + "\\" + valKAKU + "\\";


                                    }

                                    // ファイルをローカルのカレントディレクトリにダウンロードする
                                    wc.DownloadFile(val, Dpath + lcfile);

                                }
                                else
                                {

                                    if (textBoxExport.Text == "")
                                    {

                                        //ディレクトリ作成
                                        System.IO.Directory.CreateDirectory(stArrayData[2] + "\\" + stArrayData[int.Parse(n) - 2]);

                                        //ディレクトリパス設定
                                        Dpath = stArrayData[2] + "\\" + stArrayData[int.Parse(n) - 2] + "\\";


                                    }
                                    else
                                    {

                                        //ディレクトリ作成
                                        System.IO.Directory.CreateDirectory(textBoxExport.Text + "\\" + stArrayData[2] + "\\" + stArrayData[int.Parse(n) - 2]);

                                        //ディレクトリパス設定
                                        Dpath = textBoxExport.Text + "\\" + stArrayData[2] + "\\" + stArrayData[int.Parse(n) - 2] + "\\";


                                    }

                                    // ファイルをローカルのカレントディレクトリにダウンロードする
                                    wc.DownloadFile(val, Dpath + lcfile);

                                }

                                //textBox3.Text += ("OK\r\n");
                                textBox3.AppendText("OK\r\n");
                                if (checkBox2.Checked) System.IO.File.AppendAllText("log.txt", "OK\r\n");


                            }

                        }

                        textBox3.Text += ("\r\n-----終了-----\r\n");

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
                textBox3.Text = "";
                textBox3.Text += ("URL-list.txtが見つかりません");

            }

            //終了時刻を取得
            //現在の時刻を取得
            DateTime Endtime = DateTime.Now;
            int end = System.Environment.TickCount;
            //経過時間をラベルに表示

            int Totaltime = (end - start);

            int TotaltimeSecond = (Totaltime % 60000) / 1000;
            int TotaltimeMin = Totaltime / 60000;
            if (checkBox2.Checked) System.IO.File.AppendAllText("log.txt", "\r\n-----情報-----\r\n");
            if (checkBox2.Checked) System.IO.File.AppendAllText("log.txt", "開始時刻" + Sterttime.ToLongTimeString() + "\r\n" + "終了時刻" + Endtime.ToLongTimeString() +
                "\r\n" + "DL時間" + TotaltimeMin.ToString() + "分" + TotaltimeSecond.ToString() + "秒");
            if (checkBox2.Checked) System.IO.File.AppendAllText("log.txt", "\r\n-----終了-----\r\n" + "\r\n");

            button1.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;

            return;

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                //保存先
                textBoxExport.Text += (folderBrowserDialog1.SelectedPath);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //URL-list.txtファイルの場所
                textBoxURLlistF.Text += (openFileDialog1.FileName);
            }

        }

        private void fomr1_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (textBoxExport.Text == "")
            {
                string startup = Application.StartupPath;
                System.Diagnostics.Process.Start("Notepad", startup);
            }
            else
            {
                System.Diagnostics.Process.Start("Notepad", textBoxURLlistF.Text);
            }


        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBoxExport.Text == "")
            {
                string startup = Application.StartupPath;
                System.Diagnostics.Process.Start(startup);
            }
            else
            {

                System.Diagnostics.Process.Start(textBoxExport.Text);

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxURL_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxURLlistF_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxExport_TextChanged(object sender, EventArgs e)
        {

        }
    }
}