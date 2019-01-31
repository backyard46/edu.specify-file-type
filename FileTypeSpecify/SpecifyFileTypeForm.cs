using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileTypeSpecify
{
    public partial class SpecifyFileTypeForm : Form
    {

        // 処理対象ファイル情報
        List<FileInfo> files = new List<FileInfo>();


        public SpecifyFileTypeForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// ドラッグ発生時処理（まだドロップされていない）。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileTypeSpecify_DragEnter(object sender, DragEventArgs e)
        {
            CheckDraggedFiles(e);
        }


        /// <summary>
        /// ドラッグされたものがファイルかどうかを判定する。
        /// フォルダなどが混入していた場合は無視する。
        /// </summary>
        /// <param name="e"></param>
        private void CheckDraggedFiles(DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files != null)
            {
                foreach (string fileName in files)
                {
                    if (!File.Exists(fileName))
                    {
                        //e.Effect = DragDropEffects.None;
                        return;
                    }
                }
                e.Effect = DragDropEffects.Copy;
            }
        }


        /// <summary>
        /// ドラッグ＆ドロップされたファイル情報を表示する。
        /// </summary>
        /// <param name="e"></param>
        private void ProcessDraggedFiles(DragEventArgs e)
        {
            // ドロップされたものがファイルである場合のみ処理実施
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // FileInfoリスト初期化、ListBoxのデータソース初期化。
                files.Clear();
                listInfo.DataSource = null;

                // ドロップされたファイル情報を、FileInfo型のListに格納する（まずはファイル名のみ）。
                string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string name in droppedFiles)
                {
                    files.Add(new FileInfo(name));
                }

                // FileInfoリストの内容全部についてGetFileType処理を行い、タイプ情報を設定する。
                files.ForEach(file => file.Type = GetFileType(file.FileName));

                // リストボックスに表示。
                listInfo.DataSource = files;
                listInfo.DisplayMember = "FullName";
            }
        }

        /// <summary>
        /// フォームロード時処理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileTypeSpecify_Load(object sender, EventArgs e)
        {
            // フォームをドラッグ＆ドロップ可能に設定する。
            this.AllowDrop = true;
        }


        /// <summary>
        /// ドラッグ＆ドロップ発生時処理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileTypeSpecify_DragDrop(object sender, DragEventArgs e)
        {
            ProcessDraggedFiles(e);
        }


        /// <summary>
        /// ファイル名を指定すると、実際に先頭を読み取ってファイル形式を判定する。
        /// </summary>
        /// <param name="FileName">判定対象ファイル（アクセス可能なパスを含んだ名称）。</param>
        /// <returns>ファイル形式を表す文字列。</returns>
        private string GetFileType(string FileName)
        {
            string result = string.Empty;

            // 読み込んだバイナリーデータを格納するByte配列。先頭だけ読めればいいのでとりあえず20バイト分だけ用意しておく。
            byte[] data = new byte[20];

            try
            {
                using (FileStream fileSt = new FileStream(FileName, FileMode.Open))
                {
                    fileSt.Read(data, 0, data.Length);

                    if (data[0] == 0x89 && data[1] == 0x50 && data[2] == 0x4E && data[3] == 0x47)
                    {
                        // 89 50 4E 47 で始まるのはPNG形式
                        result = "PNG Format";
                    }
                    else if (data[0] == 0xFF && data[1] == 0xD8)
                    {
                        // FF D8 で始まるのはJPEG形式
                        result = "JPG Format";
                    }
                    else if (data[0] == 0x47 && data[1] == 0x49 && data[2] == 0x46 && data[3] == 0x38)
                    {
                        // 47 49 46 38 で始まるのはGIF形式
                        result = "GIF Format";
                    }
                    else if (data[0] == 0x25 && data[1] == 0x50 && data[2] == 0x44 && data[3] == 0x46)
                    {
                        // 25 50 44 46 で始まるのはPDF形式
                        result = "PDF Format";
                    }
                    else
                    {
                        // その他の場合
                        result = "Unknown";
                    }
                }
            }
            catch (IOException ex)
            {
                // ファイルアクセスエラーの場合
                result = "Error";
            }
            return result;
        }




        /// <summary>
        /// 閉じるボタン押下時処理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
