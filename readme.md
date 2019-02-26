# 概要
ITSS準拠の研修カリキュラム「プログラミングの基礎（B121）」のうち、「入出力」の実習としてC#によるファイル操作を行うサンプルです。
各課題は別々のプログラム（別プロジェクト）として作成してください。

# 課題

## 事前準備
- 手順の中でファイルタイプの識別用に書き形式のファイルやデータを準備しておいてください。内容は不問です。
  - PNG形式画像
  - JPEG形式画像
  - GIF形式画像
  - PDF形式ファイル
- Visual StudioでC#のWindows Formプロジェクト、またはコンソールアプリケーションプロジェクトを作成してください。



## 課題1 JPEG画像データファイル形式識別

### 新人用課題文
「テキストファイル」ではないファイルの1つ、バイナリーデータファイルの取り扱いを試します。
一部の画像データファイルは、データの形式ごとに先頭の数バイトが決まった形式になっているため、先頭数バイトで画像の形式を識別することが可能です。画像ファイルを指定すると、その先頭2バイトを読み取って下記の形式に該当するかどうかを判定するプログラムを作成してください。

- JPEG画像形式 …… 先頭2バイトのデータが16進数で「FF D8」

#### 参考情報: バイナリーデータファイルの読み込み
文字データではないバイナリーデータの場合、下記のようにFileStream型のオブジェクトを宣言し、そのReadメソッドでbyte型配列としてファイルを読み込むことができます。

```cs
FileStream fileSt = new FileStream(FileName, FileMode.Open)
```

今回、判定に使うのは先頭の一部のみなので、数バイトが入る入れ物となるbyte配列を用意し、Readメソッドに渡すことで配列に生のデータが入ります。FileStreamやReadメソッドの使い方はGoogleなどで検索して調べて見てください。

#### 参考情報: 16進数の表現
C#で16進数を条件文などの中で使う場合、下記のように値の前に「0x」をつけます。下記の場合、「Value1が16進数の8D、かつ、Value2が16進数の23」という条件文になります。

```cs
if (value1 == 0x8D && value2 == 0x23)
```

### 講師用補足
画像データをStream形式のオブジェクトに読み込むと、バイト型配列（byte[]）としてデータを確認できるようになります。その配列の先頭から決まった長さの内容がパターンに一致するかどうかという実装を行ってもらいます。下記の点については自由としますので、各自でルールを決めて作るよう指示してください。

- 画像ファイル名や場所は固定か、それとも選択可能か。
- 結果の表示をどのように行うか。



---

## 課題2 PDFファイルの識別

### 新人用課題文
データファイルの先頭を見ることでデータ形式が判別できるものは他にもあります。課題1と同様の処理で、指定されたファイルが課題1のJPEGファイルに下記3種類を加えた合計4種類のうちいずれの形式か、または、いずれにも該当しないかを表示するように改造してください。

- PNG画像形式 …… 先頭4バイトのデータが16進数で「89 50 4E 47」
- GIF画像形式 …… 先頭4バイトのデータが16進数で「47 49 46 38」
- PDF形式 …… 先頭4バイトのデータが16進数で「25 50 44 46」

### 講師用補足
Streamの先頭2バイト～4バイトを判定する処理を複数個書く必要があります。ここまでの講義でswitch/case文を習っていると、この場合に使えるのではないかという試行錯誤に入る新人がいるかもしれませんが、そのまま様子を見てください。言語仕様を自分で調べて目的に適合するかどうかを判断する練習も兼ねます。



---

## 課題3 複数ファイルの識別（上級編オプション課題）
課題3、課題4は上級者向けの難しい課題です。最終的に用意される正解サンプルは課題4までの対応を行った物になりますので、処理内容については講師から説明を受けてください。

### 新人用課題文
ここまでの課題では1ファイルの識別でしたが、下記の仕様を満たすように機能を拡張してください。

- フォルダを指定すると、そこに含まれるすべてのファイルについて確認を行う。
- 結果を画面上に一覧表示する。

### 講師用補足
複数ファイルの処理には、いくつ選択されるか判らないファイルを入れておく容器にあたるものを用意する必要があります。Listオブジェクトなどが使いやすいですが、そのあたり、どのような物があるかなどはできるだけ自力で調べさせてみてください。基本的な処理の流れは

1. 複数ファイルが指定される。
1. 指定されたファイルをすべてList等に格納する。
1. Listに含まれるすべてのファイルについて課題2までの判定を行う。結果も同様にListのようなものに入れておく。
1. 一覧表に判定結果を一覧表示する。



---

## 課題4 複数ファイルのドラッグ＆ドロップによる識別（上級編オプション課題）

### 新人用課題文
課題3ではフォルダ指定による複数ファイル指定でしたが、ここではさらに改造を加え、Windowsエクスプローラーなどから複数ファイルがドラッグ＆ドロップされると、ドロップされた複数のファイルを判別して結果を一覧表示するようにしてください。

#### 参考情報: ドラッグ開始時のチェック処理
下記の処理をフォームのソースに貼り付けてください。ドラッグが開始された時点で、ドラッグされているものの中にフォルダーなど判定不能なものが紛れていないかをチェックします。

```cs
/// <summary>
/// ドラッグ発生時処理（まだドロップされていない）。
/// </summary>
private void FileTypeSpecify_DragEnter(object sender, DragEventArgs e)
{
    CheckDraggedFiles(e);
}

/// <summary>
/// ドラッグされたものがファイルかどうかを判定する。
/// フォルダなどが混入していた場合は無視する。
/// </summary>
private void CheckDraggedFiles(DragEventArgs e)
{
    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
    if (files != null)
    {
        foreach (string fileName in files)
        {
            if (!File.Exists(fileName))
            {
                return;
            }
        }
        e.Effect = DragDropEffects.Copy;
    }
}
```

#### 参考情報: ドロップ時の処理

```cs
/// <summary>
/// ドラッグ＆ドロップ発生時処理。
/// </summary>
private void FileTypeSpecify_DragDrop(object sender, DragEventArgs e)
{
    ProcessDraggedFiles(e);
}

/// <summary>
/// ドラッグ＆ドロップされたファイル情報を表示する。
/// </summary>
/rivate void ProcessDraggedFiles(DragEventArgs e)
{
    // ドロップされたものがファイルである場合のみ処理実施
    if (e.Data.GetDataPresent(DataFormats.FileDrop))
    {
        // ドロップされたファイル名を文字列配列として取得する
        string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

        // ここに、上記配列の中身についてファイル種別を識別する処理を記載してください
        
    }
}
```

### 講師用補足




---

# サンプルソース概略

## SpecifyFileType