using UnityEngine;
using TMPro;
using System.Collections;

public class MemoryManager : MonoBehaviour
{
    public static MemoryManager Instance;

    public GameObject memoryMenu;             // �L�����j���[��UI�S��
    public TextMeshProUGUI memoryText;        // �L���ꗗ��\������e�L�X�g��
    public TextMeshProUGUI memorySlotText;    // �L���e�ʂ̕\��
    public TextMeshProUGUI errorMessageText;  // �G���[���b�Z�[�W�\����

    public GameObject player;                 // �v���C���[�i���쐧��Ώہj

    private PlayerInteract playerInteract;    // ��������
    private PlayerMovement playerController; // �v���C���[�ړ��i����ꍇ�j

    private int memorySlots = 0;
    private int currentCount = 0;
    private string allMemory = "";

    private void Awake()
    {
        if (Instance == null) Instance = this;

        memoryMenu.SetActive(false);

        if (errorMessageText != null)
            errorMessageText.gameObject.SetActive(false);

        // �v���C���[�X�N���v�g�擾
        if (player != null)
        {
            playerInteract = player.GetComponent<PlayerInteract>();
            playerController = player.GetComponent<PlayerMovement>(); // �Ȃ���Ζ��������
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isOpening = !memoryMenu.activeSelf;
            memoryMenu.SetActive(isOpening);

            // �v���C���[�����~�E�ĊJ
            if (playerInteract != null)
                playerInteract.enabled = !isOpening;

            if (playerController != null)
                playerController.enabled = !isOpening;
        }
    }

    public void AddMemorySlot()
    {
        memorySlots++;
        Debug.Log("�L���X���b�g�������܂����B���݂̏���F" + memorySlots);
        UpdateMemorySlotDisplay();
    }

    public bool AddMemory(string memory)
    {
        if (currentCount < memorySlots)
        {
            currentCount++;
            allMemory += $"�E{memory}\n";
            memoryText.text = allMemory;
            Debug.Log("�L����ǉ����܂����F" + memory);
            UpdateMemorySlotDisplay();
            return true;
        }
        else
        {
            Debug.Log("�L���X���b�g������܂���B");
            ShowError("�L���e�ʂ�����܂���I");
            return false;
        }
    }

    private void UpdateMemorySlotDisplay()
    {
        if (memorySlotText != null)
        {
            memorySlotText.text = $"�L���e�ʁF{currentCount} / {memorySlots}";
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
