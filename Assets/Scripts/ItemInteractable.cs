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

    public string itemName = "視覚装置";
    [TextArea] public string itemDescription = "視界を回復できそうだ。入手しますか？";

    public void Interact()
    {
        ItemInteractionManager.Instance.OpenPanel(this);
    }

    public virtual void Collect()
    {
        Debug.Log($"{itemName} を入手しました");

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
                // TODO: メモ帳に記憶を追加する処理（今後実装）
                break;
        }

        gameObject.SetActive(false);
    }
}
