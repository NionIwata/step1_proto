using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearManager : MonoBehaviour
{
    public static GameClearManager Instance;

    private int solvedCount = 0;
    public int totalGimmicks = 3;

    public GameObject clearPanel; // クリア演出用のUIパネルをインスペクターから設定

    private void Awake()
    {
        if (Instance == null) Instance = this;

        // パネルが設定されていたら初期状態は非表示に
        if (clearPanel != null)
        {
            clearPanel.SetActive(false);
        }
    }

    // ギミック1つ解決ごとに呼ばれる
    public void GimmickSolved()
    {
        solvedCount++;
        Debug.Log($"ギミック解決数: {solvedCount}/{totalGimmicks}");

        if (solvedCount >= totalGimmicks)
        {
            GateActivator.Instance.ActivateGate();
        }
    }

    // ゲートを調べてゲームクリア時に呼ぶ
    public void GameClear()
    {
        Debug.Log("ゲームクリア！");

        // パネルを表示
        if (clearPanel != null)
        {
            clearPanel.SetActive(true);
        }

        // 必要なら自動でタイトルへ戻るなどの演出も追加可
        // SceneManager.LoadScene("TitleScene");
    }
}
