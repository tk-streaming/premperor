# PREmperor

[わんコメ](https://onecomme.com/)の出力するリスナー情報を読み取って，コメントのメタ情報を配信画面に出力できるようにするツールです．
RTA走者の[しげるさん](https://www.youtube.com/channel/UCP8YrccvDK2e3chW-Kl2tow)の要望により開発をしました．

## 使い方

### 入手方法
[Releases](https://github.com/tk-streaming/premperor/releases) より最新版をダウンロードし，解凍してください．

### 実行
`premperor.exe` が本体です．管理者権限で実行する必要があります．

初回実行時に，わんコメのデータが保管されているフォルダを選択するためのダイアログが起動しますので，適切に選択してください．
通常，わんコメのデータフォルダのパスは `C:\Users\ユーザー名\AppData\Roaming\live-comment-viewer` のようになっています．

### 設定
メニューの「設定」から，アプリケーションの設定を確認し，必要であれば変更してください．
デフォルトでおそらく問題はありませんが，特にHttpおよびWebSocketの両ポート番号は，他に使用されていないポート番号を選択してください．
「コメントポイント表示HTMLファイル」は，ZIPファイルに同梱の `display.html` か，自分で作成したものを選択してください．

「リスナーデータの監視タイプ」は，過疎配信者であっても「定期的にチェック」が安定します．
ただし，無用な負荷がかかるので，過疎配信者は「データファイルの変更時にチェック」で十分ですよ．僕はそれを使います．

設定を変更した場合，それを反映させるためには，「保存してアプリを終了」を押して一度アプリケーションを閉じる必要があります．
改めて実行し直してください．

### OBSとの連携
メニューの「表示UIRLのコピー」を押すと，コメントポイントが表示されるURLをコピーすることができます．
そのURLをOBS側の「ブラウザ」で表示させるようにしてください．

### コメントポイント表示のカスタマイズ
`display.html` を編集することで自由にカスタマイズできます．
