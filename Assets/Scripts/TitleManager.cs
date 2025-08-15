using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public GameObject startPanel;     // �^�C�g����ʂ�UI
    public GameObject noiseOverlay;   // �m�C�YCanvas��Image�iNoiseOverlayController�܂ށj

    private bool gameStarted = false;

    void Start()
    {
        startPanel.SetActive(true);

        if (noiseOverlay != null)
            noiseOverlay.SetActive(false); // �ŏ��͔�\��

        Time.timeScale = 0f; // �Q�[���J�n�O�͂��ׂĒ�~
    }

    // UI�{�^������Ăяo���֐�
    public void StartGame()
    {
        if (gameStarted) return;

        startPanel.SetActive(false);

        if (noiseOverlay != null)
            noiseOverlay.SetActive(true); // �m�C�Y��L����

        Time.timeScale = 1f; // �Q�[���J�n
        gameStarted = true;
    }
}
