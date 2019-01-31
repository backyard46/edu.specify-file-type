using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileTypeSpecify
{
    /// <summary>
    /// ファイル名とタイプ情報を保持するクラス。
    /// </summary>
    class FileInfo
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="fileName"></param>
        public FileInfo(string fileName)
        {
            _fileName = fileName;
        }
        
        private string _fileName;

        /// <summary>
        /// ファイル名。
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        private string _type;

        /// <summary>
        /// ファイル種別名。
        /// </summary>
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// ファイルタイプ含めたファイル名。
        /// </summary>
        public string FullName
        {
            get {
                // タイプが空の場合はFileNameと同じ結果を返す。
                // タイプが入っていれば大括弧で囲んでタイプ名を先頭に入れる。
                if (_type.Trim().Length == 0)
                {
                    return _fileName;
                }
                else
                {
                    return "[" + _type + "]\t" + _fileName;
                }
            }
        }
                
    }
}
