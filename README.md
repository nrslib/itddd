# ITDDD

『ドメイン駆動設計入門 ボトムアップでわかる!ドメイン駆動設計の基本』第１４章のサンプル集です。
また、書籍刊行後に特別に用意した１～１３章のサンプルコードもダウンロードできます。

# 各ディレクトリ

## Layered

https://github.com/nrslib/itddd/tree/master/Layered

レイヤードアーキテクチャを意識した構成です。  
プレゼンテーション層、ドメイン層、アプリケーション層、インフラストラクチャ層がそれぞれ別プロジェクトになっています。  

## Layered_UsingInternal

https://github.com/nrslib/itddd/tree/master/Layered_UsingInternal

レイヤードアーキテクチャを意識した構成です。  
Layered との違いは、internal 修飾子を活用して、メソッドにアクセス制限を加えることで、意図しないメソッド呼び出しを抑制しています。  

## CleanLike

https://github.com/nrslib/itddd/tree/master/CleanLike

クリーンアーキテクチャを意識した構成です。  
すべてのユースケースは別クラスで実装されているため、疎結合な作りになっています。  
クリーンアーキテクチャのプロジェクト構成に関する詳しい説明は以下の URL を参考にしてください。  
https://nrslib.com/clean-architecture/

## SampleCodes

各章のサンプルコードです。
