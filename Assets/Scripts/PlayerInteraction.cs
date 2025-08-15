using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 2f;

    void Update()
    {
        // タイトル画面が表示されている間は入力を無効にする
        if (Time.timeScale == 0f) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactRange);
            foreach (var hit in hits)
            {
                ItemInteractable interactable = hit.GetComponent<ItemInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
                    break;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
