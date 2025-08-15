using UnityEngine;

public class GateActivator : MonoBehaviour
{
    public static GateActivator Instance;

    private bool isActive = false;
    private bool canClear = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void ActivateGate()
    {
        isActive = true;
        Debug.Log("ゲートが起動しました！");
        // ゲートの見た目を変える処理（任意で）
    }

    private void Update()
    {
        // プレイヤーが中にいて、Eキーを押したらクリア処理
        if (isActive && canClear && Input.GetKeyDown(KeyCode.E))
        {
            GameClearManager.Instance.GameClear();
            canClear = false; // 多重入力防止
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isActive && other.CompareTag("Player"))
        {
            canClear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canClear = false;
        }
    }
}
