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
        Debug.Log("�Q�[�g���N�����܂����I");
        // �Q�[�g�̌����ڂ�ς��鏈���i�C�ӂŁj
    }

    private void Update()
    {
        // �v���C���[�����ɂ��āAE�L�[����������N���A����
        if (isActive && canClear && Input.GetKeyDown(KeyCode.E))
        {
            GameClearManager.Instance.GameClear();
            canClear = false; // ���d���͖h�~
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
