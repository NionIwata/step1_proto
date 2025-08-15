using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInteractionManager : MonoBehaviour
{
    public static ItemInteractionManager Instance;

    public GameObject interactionPanel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public Button yesButton;
    public Button noButton;

    private ItemInteractable currentItem;

    private void Awake()
    {
        Instance = this;

        // パネルを起動時は非表示にしておく
        interactionPanel.SetActive(false);
    }

    public void OpenPanel(ItemInteractable item)
    {
        currentItem = item;
        nameText.text = item.itemName;
        descriptionText.text = item.itemDescription;

        interactionPanel.SetActive(true);
    }

    public void OnYesClicked()
    {
        if (currentItem != null)
        {
            currentItem.Collect();
            currentItem = null;
        }

        interactionPanel.SetActive(false);
    }

    public void OnNoClicked()
    {
        currentItem = null;
        interactionPanel.SetActive(false);
    }
}
