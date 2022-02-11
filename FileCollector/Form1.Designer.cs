using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    partial class fomr1
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Url_TextBox = new System.Windows.Forms.TextBox();
            this.Clear_Button = new System.Windows.Forms.Button();
            this.GenerateUrl_Button = new System.Windows.Forms.Button();
            this.Download_Button = new System.Windows.Forms.Button();
            this.Log_TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SaveDirectory_TextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SaveDirectoryBrowse_Button = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.UrlFilePath_TextBox = new System.Windows.Forms.TextBox();
            this.UrlFileBrowse_Button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SaveByExtension_CheckBox = new System.Windows.Forms.CheckBox();
            this.OpenSaveDirectory_Button = new System.Windows.Forms.Button();
            this.OpenUrlFile_Button = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SaveLog_CheckBox = new System.Windows.Forms.CheckBox();
            this.Extension_ComboBox = new System.Windows.Forms.ComboBox();
            this.Start_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.End_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Start_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.End_NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "開始値";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "終了値";
            // 
            // Url_TextBox
            // 
            this.Url_TextBox.AllowDrop = true;
            this.Url_TextBox.Location = new System.Drawing.Point(61, 12);
            this.Url_TextBox.Name = "Url_TextBox";
            this.Url_TextBox.Size = new System.Drawing.Size(185, 19);
            this.Url_TextBox.TabIndex = 1;
            // 
            // Clear_Button
            // 
            this.Clear_Button.Location = new System.Drawing.Point(179, 87);
            this.Clear_Button.Name = "Clear_Button";
            this.Clear_Button.Size = new System.Drawing.Size(67, 31);
            this.Clear_Button.TabIndex = 4;
            this.Clear_Button.Text = "クリア";
            this.Clear_Button.UseVisualStyleBackColor = true;
            this.Clear_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // GenerateUrl_Button
            // 
            this.GenerateUrl_Button.Location = new System.Drawing.Point(33, 124);
            this.GenerateUrl_Button.Name = "GenerateUrl_Button";
            this.GenerateUrl_Button.Size = new System.Drawing.Size(213, 43);
            this.GenerateUrl_Button.TabIndex = 6;
            this.GenerateUrl_Button.Text = "URLlist.txt生成";
            this.GenerateUrl_Button.UseVisualStyleBackColor = true;
            this.GenerateUrl_Button.Click += new System.EventHandler(this.button4_Click);
            // 
            // Download_Button
            // 
            this.Download_Button.Location = new System.Drawing.Point(33, 173);
            this.Download_Button.Name = "Download_Button";
            this.Download_Button.Size = new System.Drawing.Size(105, 37);
            this.Download_Button.TabIndex = 7;
            this.Download_Button.Text = "DL";
            this.Download_Button.UseVisualStyleBackColor = true;
            this.Download_Button.Click += new System.EventHandler(this.button5_Click);
            // 
            // Log_TextBox
            // 
            this.Log_TextBox.Location = new System.Drawing.Point(252, 12);
            this.Log_TextBox.Multiline = true;
            this.Log_TextBox.Name = "Log_TextBox";
            this.Log_TextBox.ReadOnly = true;
            this.Log_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log_TextBox.Size = new System.Drawing.Size(291, 198);
            this.Log_TextBox.TabIndex = 9;
            this.Log_TextBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(510, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "-------------------------------------option--------------------------------------" +
    "----";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "保存先";
            // 
            // SaveDirectory_TextBox
            // 
            this.SaveDirectory_TextBox.Location = new System.Drawing.Point(126, 283);
            this.SaveDirectory_TextBox.Name = "SaveDirectory_TextBox";
            this.SaveDirectory_TextBox.Size = new System.Drawing.Size(300, 19);
            this.SaveDirectory_TextBox.TabIndex = 14;
            // 
            // SaveDirectoryBrowse_Button
            // 
            this.SaveDirectoryBrowse_Button.Location = new System.Drawing.Point(432, 281);
            this.SaveDirectoryBrowse_Button.Name = "SaveDirectoryBrowse_Button";
            this.SaveDirectoryBrowse_Button.Size = new System.Drawing.Size(53, 21);
            this.SaveDirectoryBrowse_Button.TabIndex = 15;
            this.SaveDirectoryBrowse_Button.Text = "参照";
            this.SaveDirectoryBrowse_Button.UseVisualStyleBackColor = true;
            this.SaveDirectoryBrowse_Button.Click += new System.EventHandler(this.button7_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "URLファイル場所";
            // 
            // UrlFilePath_TextBox
            // 
            this.UrlFilePath_TextBox.Location = new System.Drawing.Point(126, 254);
            this.UrlFilePath_TextBox.Name = "UrlFilePath_TextBox";
            this.UrlFilePath_TextBox.Size = new System.Drawing.Size(300, 19);
            this.UrlFilePath_TextBox.TabIndex = 11;
            // 
            // UrlFileBrowse_Button
            // 
            this.UrlFileBrowse_Button.Location = new System.Drawing.Point(432, 253);
            this.UrlFileBrowse_Button.Name = "UrlFileBrowse_Button";
            this.UrlFileBrowse_Button.Size = new System.Drawing.Size(53, 21);
            this.UrlFileBrowse_Button.TabIndex = 12;
            this.UrlFileBrowse_Button.Text = "参照";
            this.UrlFileBrowse_Button.UseVisualStyleBackColor = true;
            this.UrlFileBrowse_Button.Click += new System.EventHandler(this.button8_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "URL-listファイル|URL-list.txt";
            // 
            // SaveByExtension_CheckBox
            // 
            this.SaveByExtension_CheckBox.AutoSize = true;
            this.SaveByExtension_CheckBox.Location = new System.Drawing.Point(33, 228);
            this.SaveByExtension_CheckBox.Name = "SaveByExtension_CheckBox";
            this.SaveByExtension_CheckBox.Size = new System.Drawing.Size(105, 16);
            this.SaveByExtension_CheckBox.TabIndex = 9;
            this.SaveByExtension_CheckBox.Text = "拡張子別に保存";
            this.SaveByExtension_CheckBox.UseVisualStyleBackColor = true;
            // 
            // OpenSaveDirectory_Button
            // 
            this.OpenSaveDirectory_Button.Location = new System.Drawing.Point(491, 281);
            this.OpenSaveDirectory_Button.Name = "OpenSaveDirectory_Button";
            this.OpenSaveDirectory_Button.Size = new System.Drawing.Size(52, 21);
            this.OpenSaveDirectory_Button.TabIndex = 16;
            this.OpenSaveDirectory_Button.Text = "開く";
            this.OpenSaveDirectory_Button.UseVisualStyleBackColor = true;
            this.OpenSaveDirectory_Button.Click += new System.EventHandler(this.button10_Click);
            // 
            // OpenUrlFile_Button
            // 
            this.OpenUrlFile_Button.Location = new System.Drawing.Point(491, 253);
            this.OpenUrlFile_Button.Name = "OpenUrlFile_Button";
            this.OpenUrlFile_Button.Size = new System.Drawing.Size(52, 20);
            this.OpenUrlFile_Button.TabIndex = 13;
            this.OpenUrlFile_Button.Text = "開く";
            this.OpenUrlFile_Button.UseVisualStyleBackColor = true;
            this.OpenUrlFile_Button.Click += new System.EventHandler(this.button9_Click);
            // 
            // SaveLog_CheckBox
            // 
            this.SaveLog_CheckBox.AutoSize = true;
            this.SaveLog_CheckBox.Checked = true;
            this.SaveLog_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SaveLog_CheckBox.Location = new System.Drawing.Point(144, 228);
            this.SaveLog_CheckBox.Name = "SaveLog_CheckBox";
            this.SaveLog_CheckBox.Size = new System.Drawing.Size(63, 16);
            this.SaveLog_CheckBox.TabIndex = 10;
            this.SaveLog_CheckBox.Text = "log保存";
            this.SaveLog_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Extension_ComboBox
            // 
            this.Extension_ComboBox.FormattingEnabled = true;
            this.Extension_ComboBox.Items.AddRange(new object[] {
            "jpeg,jpg,gif,png",
            "wma,mp3,acc",
            "avi,wmv,mp4,divx"});
            this.Extension_ComboBox.Location = new System.Drawing.Point(213, 226);
            this.Extension_ComboBox.Name = "Extension_ComboBox";
            this.Extension_ComboBox.Size = new System.Drawing.Size(330, 20);
            this.Extension_ComboBox.TabIndex = 100;
            this.Extension_ComboBox.TabStop = false;
            this.Extension_ComboBox.Text = "保存拡張子(実装予定)";
            // 
            // Start_NumericUpDown
            // 
            this.Start_NumericUpDown.Location = new System.Drawing.Point(61, 37);
            this.Start_NumericUpDown.Name = "Start_NumericUpDown";
            this.Start_NumericUpDown.Size = new System.Drawing.Size(185, 19);
            this.Start_NumericUpDown.TabIndex = 101;
            // 
            // End_NumericUpDown
            // 
            this.End_NumericUpDown.Location = new System.Drawing.Point(61, 62);
            this.End_NumericUpDown.Name = "End_NumericUpDown";
            this.End_NumericUpDown.Size = new System.Drawing.Size(185, 19);
            this.End_NumericUpDown.TabIndex = 101;
            // 
            // fomr1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 314);
            this.Controls.Add(this.End_NumericUpDown);
            this.Controls.Add(this.Start_NumericUpDown);
            this.Controls.Add(this.Extension_ComboBox);
            this.Controls.Add(this.SaveLog_CheckBox);
            this.Controls.Add(this.OpenUrlFile_Button);
            this.Controls.Add(this.OpenSaveDirectory_Button);
            this.Controls.Add(this.SaveByExtension_CheckBox);
            this.Controls.Add(this.UrlFileBrowse_Button);
            this.Controls.Add(this.UrlFilePath_TextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SaveDirectoryBrowse_Button);
            this.Controls.Add(this.SaveDirectory_TextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Log_TextBox);
            this.Controls.Add(this.Download_Button);
            this.Controls.Add(this.GenerateUrl_Button);
            this.Controls.Add(this.Clear_Button);
            this.Controls.Add(this.Url_TextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "fomr1";
            this.Text = "役立たずの画像収集機 ver.1.10";
            ((System.ComponentModel.ISupportInitialize)(this.Start_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.End_NumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Url_TextBox;
        private System.Windows.Forms.Button Clear_Button;
        private System.Windows.Forms.Button GenerateUrl_Button;
        private System.Windows.Forms.Button Download_Button;
        private TextBox Log_TextBox;
        private Label label4;
        private Label label6;
        private TextBox SaveDirectory_TextBox;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button SaveDirectoryBrowse_Button;
        private Label label7;
        private TextBox UrlFilePath_TextBox;
        private Button UrlFileBrowse_Button;
        private OpenFileDialog openFileDialog1;
        private CheckBox SaveByExtension_CheckBox;
        private Button OpenSaveDirectory_Button;
        private Button OpenUrlFile_Button;
        private Timer timer1;
        private CheckBox SaveLog_CheckBox;
        private ComboBox Extension_ComboBox;
        private NumericUpDown Start_NumericUpDown;
        private NumericUpDown End_NumericUpDown;
    }
}

