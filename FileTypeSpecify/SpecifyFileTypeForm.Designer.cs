namespace FileTypeSpecify
{
    partial class SpecifyFileTypeForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.listInfo = new System.Windows.Forms.ListBox();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.buttonClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 357);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(850, 56);
            this.panelBottom.TabIndex = 0;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(712, 8);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(128, 40);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "閉じる";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // listInfo
            // 
            this.listInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listInfo.FormattingEnabled = true;
            this.listInfo.ItemHeight = 19;
            this.listInfo.Location = new System.Drawing.Point(0, 0);
            this.listInfo.Name = "listInfo";
            this.listInfo.Size = new System.Drawing.Size(850, 357);
            this.listInfo.TabIndex = 1;
            // 
            // FileTypeSpecify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 413);
            this.Controls.Add(this.listInfo);
            this.Controls.Add(this.panelBottom);
            this.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FileTypeSpecify";
            this.Text = "ファイル種別判定（判定したいファイルをドラッグ＆ドロップしてください）";
            this.Load += new System.EventHandler(this.FileTypeSpecify_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileTypeSpecify_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileTypeSpecify_DragEnter);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ListBox listInfo;
    }
}

