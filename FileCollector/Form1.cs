using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace FileCollector
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
        private async void Download_Button_Click(object sender, EventArgs e)
        {
            if(SaveDirectory_TextBox.Text.Length == 0)
            {
                MessageBox.Show("保存先フォルダを指定してください。");
                return;
            }

            await DownloadFilesAsync();
        }

        /// <summary>
        /// 連番ファイルをダウンロード
        /// </summary>
        private async Task<bool> DownloadFilesAsync()
        {
            SwitchEnabledControls(false);

            var urls = GenerateUrl();
            if (urls.Count == 0) { return false; }

            var startTime = DateTime.Now;

            Log_TextBox.AppendText("\r\n----- ダウンロード開始 -----\r\n");
            int successCount = 0;
            bool isSaveByExtension = SaveByExtension_CheckBox.Checked;
            int delayTime = int.Parse(DownloadDelay_NumericUpDown.Text);
            foreach (var url in urls)
            {
                var result = await DownloadAsync(url, SaveDirectory_TextBox.Text, isSaveByExtension);
                if (result) { successCount += 1; }

                var result_text = result ? "成功" : "失敗";
                var text = $"{url} -> {result_text}";
                Log_TextBox.AppendText($"{text}\r\n");
                await Task.Delay(delayTime);
            }

            // 処理時間
            var endTime = DateTime.Now;
            var totalTime = (endTime - startTime).TotalMinutes;
            Log_TextBox.AppendText("\r\n----- 統計 -----\r\n");

            Log_TextBox.AppendText($"時間: {totalTime:0.00}分\r\n");
            Log_TextBox.AppendText($"対象: {urls.Count}件\r\n");
            Log_TextBox.AppendText($"成功: {successCount}件\r\n");

            SwitchEnabledControls(true);

            return true;
        }

        /// <summary>
        /// コントロールの有効状態を切替
        /// </summary>
        /// <param name="isEnabled"></param>
        private void SwitchEnabledControls(bool isEnabled) 
        {
            Clear_Button.Enabled = isEnabled;
            CheckGenerateUrl_Button.Enabled = isEnabled;
            Download_Button.Enabled = isEnabled;
            SaveDirectoryBrowse_Button.Enabled = isEnabled;
            OpenSaveDirectory_Button.Enabled = isEnabled;
        }

        private static readonly HttpClient httpClient = new HttpClient();
        /// <summary>
        /// 非同期でファイルをダウンロード
        /// </summary>
        /// <remarks>
        /// .NETのHttpClientでメモリに優しく、でかいファイルをダウンロードする
        /// https://qiita.com/thrzn41/items/2754bec8ebad97ecd7fd
        /// </remarks>
        /// <param name="url">ダウンロード対象</param>
        /// <param name="saveDirectory">保存先フォルダ</param>
        /// <param name="isSaveByExtension">拡張子毎にフォルダを分けるか</param>
        /// <returns></returns>
        private async Task<bool> DownloadAsync(string url, string saveDirectory, bool isSaveByExtension)
        {
            if(url == null || url.Length == 0) { return false; }
            if (saveDirectory == null || saveDirectory.Length == 0) { return false; }

            // 保存先ファイル
            string savePath = CreateSavePath(url, saveDirectory, isSaveByExtension);

            using (var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url)))
            using (var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                if (response.StatusCode != HttpStatusCode.OK) { return false; }
                
                
                using (var content = response.Content)
                using (var stream = await content.ReadAsStreamAsync())
                using (var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    stream.CopyTo(fileStream);
                }
            }

            return true;
        }

        /// <summary>
        /// ファイルの保存先パスを作成
        /// </summary>
        /// <param name="url">ダウンロード対象</param>
        /// <param name="saveDirectory">保存先フォルダ</param>
        /// <param name="isSaveByExtension">拡張子毎にフォルダを分けるか</param>
        /// <returns></returns>
        private string CreateSavePath(string url, string saveDirectory, bool isSaveByExtension)
        {
            string filename = Path.GetFileName(url);
            // ピリオドを抜いた拡張子を取得
            string extension = Path.GetExtension(url).Remove(0, 1);
            string fixedSaveDirectory = saveDirectory;
            if (!saveDirectory.EndsWith("\\")) { fixedSaveDirectory = $"{saveDirectory}\\"; }
            if (isSaveByExtension) { fixedSaveDirectory += $"{extension}\\"; }

            if (!Directory.Exists(fixedSaveDirectory)) { Directory.CreateDirectory(fixedSaveDirectory); }

            string result = $"{fixedSaveDirectory}{filename}";
            return result;
        }

        /// <summary>
        /// ファイル保存先フォルダを指定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveDirectoryBrowse_Button_Click(object sender, EventArgs e)
        {
            using(var fbd = new FolderBrowserDialog() { 
                SelectedPath = SaveDirectory_TextBox.Text
            })
            {
                if (fbd.ShowDialog() != DialogResult.OK) { return; }
                SaveDirectory_TextBox.Text += (fbd.SelectedPath);
            }
        }

        /// <summary>
        /// 保存先フォルダを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSaveDirectory_Button_Click(object sender, EventArgs e)
        {
            var directory = SaveDirectory_TextBox.Text == "" ? Application.StartupPath : SaveDirectory_TextBox.Text;
            System.Diagnostics.Process.Start(directory);
        }
    }
}