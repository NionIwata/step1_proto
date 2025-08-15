using UnityEngine;

public class ItemInteractable : MonoBehaviour
{
    public enum ItemType
    {
        VisionDevice,
        HearingDevice,
        MemoryDevice
    }

    public ItemType itemType = ItemType.VisionDevice;

    public string itemName = "���o���u";
    [TextArea] public string itemDescription = "���E���񕜂ł��������B���肵�܂����H";

    public void Interact()
    {
        ItemInteractionManager.Instance.OpenPanel(this);
    }

    public virtual void Collect()
    {
        Debug.Log($"{itemName} ����肵�܂���");

        switch (itemType)
        {
            case ItemType.VisionDevice:
                var noise = FindObjectOfType<NoiseOverlayController>();
                if (noise != null)
                {
                    noise.FadeOut();
                }
                break;

            case ItemType.HearingDevice:
                var bgm = FindObjectOfType<BGMFadeController>();
                if (bgm != null)
                {
                    bgm.StartFadeIn();
                }
                break;

            case ItemType.MemoryDevice:
                // TODO: �������ɋL����ǉ����鏈���i��������j
                break;
        }

        gameObject.SetActive(false);
    }
}
