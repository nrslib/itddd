# ITDDD

『ドメイン駆動設計入門 ボトムアップでわかる!ドメイン駆動設計の基本』第１４章のサンプルです。  
ASP.NET Core で構築された Web サイトシステムです。  
レイヤードアーキテクチャを意識した構成になっています。  

# Environment

.NET Core 3.1  
Node.js 12.14.1

# プロジェクトの実行

## 実行環境の準備

プロジェクトを実行する場合に Microsoft が提供している IDE である Visual Studio を利用する方法がもっとも手軽です。  
下記 URL に従って、任意のバージョンの Visual Studio Community をインストールしてください。

https://docs.microsoft.com/ja-jp/visualstudio/install/install-visual-studio

なお、インストール時、ワークロードの選択が要求されます。  
次の画像のように「ASP.NET と Web 開発」を選択してください。

![vsinstaller](https://github.com/nrslib/itddd/blob/images/vs_installer.png)

### Node.jsの準備

プロジェクトはNode.jsが利用されています。  
下記URLよりインストーラーを入手して、インストーラーの指示に従いNode.jsをインストールしてください。  
※バージョン12.14.1で動作確認をしています。  
https://nodejs.org/ja/

## ソリューションを読み込む

プロジェクトを読み込むには Visual Studio を起動して .sln ファイルを指定してソリューションを開きます。  
次の画像は Visual Studio 2019 起動時のスタートメニューです。  

![LoadingProject](https://github.com/nrslib/itddd/blob/images/load_project_1.png)

「プロジェクトやソリューションを開く」を選択し、.sln ファイルを選択すると関連するプロジェクトが IDE 上に読み込まれます。  

![LoadingProject](https://github.com/nrslib/itddd/blob/images/load_project_2.png)

## 実行

システムを実行する際には Visual Studio 上でデバッグ実行します。  
WebApplication にターゲットを合わせて、デバッグ実行（F5 もしくは画像の IIS Express ボタンを押下）するとサンプルの Web サイトが立ち上がります。  

![LoadingProject](https://github.com/nrslib/itddd/blob/images/load_project_3.png)

# システムの設定

システムにはデータベースを使用するか否かの設定を行う手段が準備されています。  

## Dependency Injection

IoC Containerに対するインジェクションモジュールの選択肢は次の３種類用意してあります。  

 - インメモリで動作するモジュール
 - SQL 文を利用したモジュール
 - Entity Framework を用いたモジュール
 
どのモジュールを利用するかの設定はプロダクション用設定の appsettings.json とデバッグ用設定の appsetting.Development.json によって制御できます。  

### インメモリで動作するモジュール

次のように appsettings.json / asppsetting.Development.json で InMemoryModuleDependencySetup を指定してください。  
※デフォルトはこの設定がされています。  

```
"Dependency": {
  "setup": "InMemoryModuleDependencySetup"
}
```

### SQL 文を利用したモジュール

次のように appsettings.json / asppsetting.Development.json で SqlConnectionDependencySetup を指定してください。  
この設定はデータベースを利用するためデータベースとテーブルを準備する（後述）必要があります。  

```
"Dependency": {
  "setup": "SqlConnectionDependencySetup"
}
```

### Entity Framework を用いたモジュール

次のように appsettings.json / asppsetting.Development.json で EFDependencySetup を指定してください。  
この設定はデータベースを利用するためデータベースとテーブルを準備する（後述）必要があります。  

```
"Dependency": {
  "setup": "EFDependencySetup"
}
```

Entity Framework を用いながらインメモリで動作させる選択肢もあります。
次のように追加設定を行ってください。

```
"Dependency": {
  "SetupName": "EFDependencySetup",
  "Extra": {
    "EF" : {
      "InMemory": true 
    } 
  }
}
```

## Database

Entity Framework 及び SQL を用いた処理が利用するデータベースは SQL Server Express を想定しています。  
データベースを利用したときの処理を確認したい場合は Entity Framework のコードファースト機能によりデータベースを準備します。  

コードファーストでデータベースを準備する際にはまず appsetting.json / appsettings.Development.json を次のように EFDependencySetup を使用するように変更します。  

```
"Dependency": {
  "setup": "EFDependencySetup"
}
```

次に、パッケージマネージャコンソールで EFInfrastructure を対象にして、次のようにマイグレーションを生成してください。  

```
Add-Migration Initial
```

その後、パッケージマネージャコンソールでデータベースの更新を行う（Update-Database コマンドを実行する）と itdddContext1 というデータベースが作成されます。  

```
Update-Database
```
