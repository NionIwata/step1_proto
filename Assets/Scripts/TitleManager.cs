using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public GameObject startPanel;     // タイトル画面のUI
    public GameObject noiseOverlay;   // ノイズCanvasやImage（NoiseOverlayController含む）

    private bool gameStarted = false;

    void Start()
    {
        startPanel.SetActive(true);

        if (noiseOverlay != null)
            noiseOverlay.SetActive(false); // 最初は非表示

        Time.timeScale = 0f; // ゲーム開始前はすべて停止
    }

    // UIボタンから呼び出す関数
    public void StartGame()
    {
        if (gameStarted) return;

        startPanel.SetActive(false);

        if (noiseOverlay != null)
            noiseOverlay.SetActive(true); // ノイズを有効化

        Time.timeScale = 1f; // ゲーム開始
        gameStarted = true;
    }
}
