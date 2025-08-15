using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearManager : MonoBehaviour
{
    public static GameClearManager Instance;

    private int solvedCount = 0;
    public int totalGimmicks = 3;

    public GameObject clearPanel; // �N���A���o�p��UI�p�l�����C���X�y�N�^�[����ݒ�

    private void Awake()
    {
        if (Instance == null) Instance = this;

        // �p�l�����ݒ肳��Ă����珉����Ԃ͔�\����
        if (clearPanel != null)
        {
            clearPanel.SetActive(false);
        }
    }

    // �M�~�b�N1�������ƂɌĂ΂��
    public void GimmickSolved()
    {
        solvedCount++;
        Debug.Log($"�M�~�b�N������: {solvedCount}/{totalGimmicks}");

        if (solvedCount >= totalGimmicks)
        {
            GateActivator.Instance.ActivateGate();
        }
    }

    // �Q�[�g�𒲂ׂăQ�[���N���A���ɌĂ�
    public void GameClear()
    {
        Debug.Log("�Q�[���N���A�I");

        // �p�l����\��
        if (clearPanel != null)
        {
            clearPanel.SetActive(true);
        }

        // �K�v�Ȃ玩���Ń^�C�g���֖߂�Ȃǂ̉��o���ǉ���
        // SceneManager.LoadScene("TitleScene");
    }
}
