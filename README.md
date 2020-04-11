# micro:bitの加速度センサの値をUnityで取得
micro:bitの「bluetooth」という拡張機能にある
- Bluetooth 加速度計サービス
- Bluetooth ボタンサービス
- Bluetooth 磁力計サービス

のブロックを使用した時に、micro:bitから送られてくる値を、Unityで利用するための、MacOSX用のネイティブプラグインと、これを使用したプログラムを作成しました。

## 動作環境
### MacOS
- MacOS Catalina 10.15.3
- Unity 2019.3.6f1

でのみ動作の確認をおこないました。  
BluetoothをONにしてください。micro:bitとペアリングする必要はありません。

### micro:bit
microbitフォルダにあるhexファイルを、micro:bitに書き込みます。

プログラムを開始すると、Bluetoothをスキャンして、最初に見つかったmicro:bitと接続します。
Mac上のUnityのエディタ環境では、そのまま動作するようです。
