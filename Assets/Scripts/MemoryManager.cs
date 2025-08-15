using UnityEngine;
using TMPro;
using System.Collections;

public class MemoryManager : MonoBehaviour
{
    public static MemoryManager Instance;

    public GameObject memoryMenu;             // 記憶メニューのUI全体
    public TextMeshProUGUI memoryText;        // 記憶一覧を表示するテキスト欄
    public TextMeshProUGUI memorySlotText;    // 記憶容量の表示
    public TextMeshProUGUI errorMessageText;  // エラーメッセージ表示欄

    public GameObject player;                 // プレイヤー（操作制御対象）

    private PlayerInteract playerInteract;    // 調査操作
    private PlayerMovement playerController; // プレイヤー移動（ある場合）

    private int memorySlots = 0;
    private int currentCount = 0;
    private string allMemory = "";

    private void Awake()
    {
        if (Instance == null) Instance = this;

        memoryMenu.SetActive(false);

        if (errorMessageText != null)
            errorMessageText.gameObject.SetActive(false);

        // プレイヤースクリプト取得
        if (player != null)
        {
            playerInteract = player.GetComponent<PlayerInteract>();
            playerController = player.GetComponent<PlayerMovement>(); // なければ無視される
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isOpening = !memoryMenu.activeSelf;
            memoryMenu.SetActive(isOpening);

            // プレイヤー操作停止・再開
            if (playerInteract != null)
                playerInteract.enabled = !isOpening;

            if (playerController != null)
                playerController.enabled = !isOpening;
        }
    }

    public void AddMemorySlot()
    {
        memorySlots++;
        Debug.Log("記憶スロットが増えました。現在の上限：" + memorySlots);
        UpdateMemorySlotDisplay();
    }

    public bool AddMemory(string memory)
    {
        if (currentCount < memorySlots)
        {
            currentCount++;
            allMemory += $"・{memory}\n";
            memoryText.text = allMemory;
            Debug.Log("記憶を追加しました：" + memory);
            UpdateMemorySlotDisplay();
            return true;
        }
        else
        {
            Debug.Log("記憶スロットが足りません。");
            ShowError("記憶容量が足りません！");
            return false;
        }
    }

    private void UpdateMemorySlotDisplay()
    {
        if (memorySlotText != null)
        {
            memorySlotText.text = $"記憶容量：{currentCount} / {memorySlots}";
        }
    }

    private void ShowError(string message)
    {
        if (errorMessageText != null)
        {
            errorMessageText.text = message;
            StopAllCoroutines();
            StartCoroutine(HideErrorAfterSeconds(2f));
        }
    }

    private IEnumerator HideErrorAfterSeconds(float delay)
    {
        errorMessageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        errorMessageText.gameObject.SetActive(false);
    }
}
