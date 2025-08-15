using UnityEngine;
using UnityEngine.UI;

public class NoiseOverlayController : MonoBehaviour
{
    // ノイズ画像（Imageコンポーネント）
    public Image noiseImage;

    // フェードアウトの速度（1秒あたりの透明化量）
    public float fadeSpeed = 0.5f;

    // フェード中かどうかのフラグ
    private bool fadingOut = false;

    void Update()
    {
        // フェードアウト中のみ処理を実行
        if (fadingOut && noiseImage != null)
        {
            Color color = noiseImage.color;

            // α値を徐々に減らす（0〜1の範囲に制限）
            color.a -= fadeSpeed * Time.deltaTime;
            color.a = Mathf.Clamp01(color.a);
            noiseImage.color = color;

            // αが0になったらフェード終了＆オブジェクトを非表示
            if (color.a <= 0f)
            {
                fadingOut = false;
                gameObject.SetActive(false);
            }
        }
    }

    // 外部からフェードを開始するための関数
    public void FadeOut()
    {
        fadingOut = true;
    }
}
