using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;
using SocialConnector;

public class social : MonoBehaviour
{

    public void Share()
    {
        StartCoroutine(ShareScreenShot());
    }


    IEnumerator ShareScreenShot()
    {
        //スクリーンショット画像の保存先を設定。ファイル名が重複しないように実行時間を付与
        string fileName = String.Format("image_{0:yyyyMMdd_Hmmss}.png", DateTime.Now);
        string imagePath = Application.persistentDataPath + "/" + fileName;

        //スクリーンショットを撮影
        ScreenCapture.CaptureScreenshot(fileName);
        yield return new WaitForEndOfFrame();

        // Shareするメッセージを設定
        string text = "MACアドレスのベンダーコードからメーカーを当てるクイズゲーム爆誕\n" +
            "総問題数19880問！10問中何問解けるか試してみてください!" +
            "#MacAddressQuiz #MACアドレス #MAC #Address #Quiz #ベンダーコード #難問";
        string URL = "http://pasokatu.hateblo.jp/";
        yield return new WaitForSeconds(1);

        //Shareする
        SocialConnector.SocialConnector.Share(text, URL, imagePath);
    }
}