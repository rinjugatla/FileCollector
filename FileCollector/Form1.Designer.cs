using System.Windows.Forms;

namespace FileCollector
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Url_TextBox = new System.Windows.Forms.TextBox();
            this.Clear_Button = new System.Windows.Forms.Button();
            this.CheckGenerateUrl_Button = new System.Windows.Forms.Button();
            this.Download_Button = new System.Windows.Forms.Button();
            this.Log_TextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SaveDirectory_TextBox = new System.Windows.Forms.TextBox();
            this.SaveDirectoryBrowse_Button = new System.Windows.Forms.Button();
            this.SaveByExtension_CheckBox = new System.Windows.Forms.CheckBox();
            this.OpenSaveDirectory_Button = new System.Windows.Forms.Button();
            this.Start_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.End_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Format_TextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DownloadDelay_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Start_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.End_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadDelay_NumericUpDown)).BeginInit();
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
            this.Url_TextBox.Location = new System.Drawing.Point(72, 12);
            this.Url_TextBox.Name = "Url_TextBox";
            this.Url_TextBox.Size = new System.Drawing.Size(174, 19);
            this.Url_TextBox.TabIndex = 1;
            // 
            // Clear_Button
            // 
            this.Clear_Button.Location = new System.Drawing.Point(165, 180);
            this.Clear_Button.Name = "Clear_Button";
            this.Clear_Button.Size = new System.Drawing.Size(81, 37);
            this.Clear_Button.TabIndex = 4;
            this.Clear_Button.Text = "クリア";
            this.Clear_Button.UseVisualStyleBackColor = true;
            this.Clear_Button.Click += new System.EventHandler(this.Clear_Button_Click);
            // 
            // CheckGenerateUrl_Button
            // 
            this.CheckGenerateUrl_Button.Location = new System.Drawing.Point(13, 137);
            this.CheckGenerateUrl_Button.Name = "CheckGenerateUrl_Button";
            this.CheckGenerateUrl_Button.Size = new System.Drawing.Size(233, 37);
            this.CheckGenerateUrl_Button.TabIndex = 6;
            this.CheckGenerateUrl_Button.Text = "連番URLを確認";
            this.CheckGenerateUrl_Button.UseVisualStyleBackColor = true;
            this.CheckGenerateUrl_Button.Click += new System.EventHandler(this.CheckGenerateUrl_Button_Click);
            // 
            // Download_Button
            // 
            this.Download_Button.Location = new System.Drawing.Point(13, 180);
            this.Download_Button.Name = "Download_Button";
            this.Download_Button.Size = new System.Drawing.Size(146, 37);
            this.Download_Button.TabIndex = 7;
            this.Download_Button.Text = "DL";
            this.Download_Button.UseVisualStyleBackColor = true;
            this.Download_Button.Click += new System.EventHandler(this.Download_Button_Click);
            // 
            // Log_TextBox
            // 
            this.Log_TextBox.Location = new System.Drawing.Point(252, 12);
            this.Log_TextBox.Multiline = true;
            this.Log_TextBox.Name = "Log_TextBox";
            this.Log_TextBox.ReadOnly = true;
            this.Log_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Log_TextBox.Size = new System.Drawing.Size(400, 207);
            this.Log_TextBox.TabIndex = 9;
            this.Log_TextBox.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "保存先";
            // 
            // SaveDirectory_TextBox
            // 
            this.SaveDirectory_TextBox.Location = new System.Drawing.Point(58, 227);
            this.SaveDirectory_TextBox.Name = "SaveDirectory_TextBox";
            this.SaveDirectory_TextBox.Size = new System.Drawing.Size(365, 19);
            this.SaveDirectory_TextBox.TabIndex = 14;
            // 
            // SaveDirectoryBrowse_Button
            // 
            this.SaveDirectoryBrowse_Button.Location = new System.Drawing.Point(429, 226);
            this.SaveDirectoryBrowse_Button.Name = "SaveDirectoryBrowse_Button";
            this.SaveDirectoryBrowse_Button.Size = new System.Drawing.Size(53, 21);
            this.SaveDirectoryBrowse_Button.TabIndex = 15;
            this.SaveDirectoryBrowse_Button.Text = "参照";
            this.SaveDirectoryBrowse_Button.UseVisualStyleBackColor = true;
            this.SaveDirectoryBrowse_Button.Click += new System.EventHandler(this.SaveDirectoryBrowse_Button_Click);
            // 
            // SaveByExtension_CheckBox
            // 
            this.SaveByExtension_CheckBox.AutoSize = true;
            this.SaveByExtension_CheckBox.Location = new System.Drawing.Point(546, 229);
            this.SaveByExtension_CheckBox.Name = "SaveByExtension_CheckBox";
            this.SaveByExtension_CheckBox.Size = new System.Drawing.Size(105, 16);
            this.SaveByExtension_CheckBox.TabIndex = 9;
            this.SaveByExtension_CheckBox.Text = "拡張子別に保存";
            this.SaveByExtension_CheckBox.UseVisualStyleBackColor = true;
            // 
            // OpenSaveDirectory_Button
            // 
            this.OpenSaveDirectory_Button.Location = new System.Drawing.Point(488, 226);
            this.OpenSaveDirectory_Button.Name = "OpenSaveDirectory_Button";
            this.OpenSaveDirectory_Button.Size = new System.Drawing.Size(52, 21);
            this.OpenSaveDirectory_Button.TabIndex = 16;
            this.OpenSaveDirectory_Button.Text = "開く";
            this.OpenSaveDirectory_Button.UseVisualStyleBackColor = true;
            this.OpenSaveDirectory_Button.Click += new System.EventHandler(this.OpenSaveDirectory_Button_Click);
            // 
            // Start_NumericUpDown
            // 
            this.Start_NumericUpDown.Location = new System.Drawing.Point(72, 37);
            this.Start_NumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.Start_NumericUpDown.Name = "Start_NumericUpDown";
            this.Start_NumericUpDown.Size = new System.Drawing.Size(174, 19);
            this.Start_NumericUpDown.TabIndex = 101;
            this.Start_NumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // End_NumericUpDown
            // 
            this.End_NumericUpDown.Location = new System.Drawing.Point(72, 62);
            this.End_NumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.End_NumericUpDown.Name = "End_NumericUpDown";
            this.End_NumericUpDown.Size = new System.Drawing.Size(174, 19);
            this.End_NumericUpDown.TabIndex = 101;
            this.End_NumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Format_TextBox
            // 
            this.Format_TextBox.Location = new System.Drawing.Point(72, 87);
            this.Format_TextBox.Name = "Format_TextBox";
            this.Format_TextBox.Size = new System.Drawing.Size(174, 19);
            this.Format_TextBox.TabIndex = 102;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "フォーマット";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "待機時間";
            // 
            // DownloadDelay_NumericUpDown
            // 
            this.DownloadDelay_NumericUpDown.Location = new System.Drawing.Point(72, 112);
            this.DownloadDelay_NumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.DownloadDelay_NumericUpDown.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.DownloadDelay_NumericUpDown.Name = "DownloadDelay_NumericUpDown";
            this.DownloadDelay_NumericUpDown.Size = new System.Drawing.Size(174, 19);
            this.DownloadDelay_NumericUpDown.TabIndex = 101;
            this.DownloadDelay_NumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DownloadDelay_NumericUpDown.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // fomr1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 258);
            this.Controls.Add(this.Format_TextBox);
            this.Controls.Add(this.DownloadDelay_NumericUpDown);
            this.Controls.Add(this.End_NumericUpDown);
            this.Controls.Add(this.Start_NumericUpDown);
            this.Controls.Add(this.OpenSaveDirectory_Button);
            this.Controls.Add(this.SaveByExtension_CheckBox);
            this.Controls.Add(this.SaveDirectoryBrowse_Button);
            this.Controls.Add(this.SaveDirectory_TextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Log_TextBox);
            this.Controls.Add(this.Download_Button);
            this.Controls.Add(this.CheckGenerateUrl_Button);
            this.Controls.Add(this.Clear_Button);
            this.Controls.Add(this.Url_TextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fomr1";
            this.Text = "連番ファイルダウンロード ver.1.2.0";
            ((System.ComponentModel.ISupportInitialize)(this.Start_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.End_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadDelay_NumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Url_TextBox;
        private System.Windows.Forms.Button Clear_Button;
        private System.Windows.Forms.Button CheckGenerateUrl_Button;
        private System.Windows.Forms.Button Download_Button;
        private TextBox Log_TextBox;
        private Label label6;
        private TextBox SaveDirectory_TextBox;
        private Button SaveDirectoryBrowse_Button;
        private CheckBox SaveByExtension_CheckBox;
        private Button OpenSaveDirectory_Button;
        private NumericUpDown Start_NumericUpDown;
        private NumericUpDown End_NumericUpDown;
        private TextBox Format_TextBox;
        private Label label5;
        private Label label4;
        private NumericUpDown DownloadDelay_NumericUpDown;
    }
}

