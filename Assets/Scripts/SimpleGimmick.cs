// SimpleGimmick.cs�i���ǔŁj
using UnityEngine;

public class SimpleGimmick : MonoBehaviour
{
    private bool playerInRange = false;
    private bool solved = false;

    void Update()
    {
        if (playerInRange && !solved && Input.GetKeyDown(KeyCode.E))
        {
            solved = true;
            GameClearManager.Instance.GimmickSolved();
            gameObject.SetActive(false);  // �M�~�b�N�������i���o�����Ă�OK�j
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
