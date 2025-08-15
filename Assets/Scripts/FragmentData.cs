using UnityEngine;

public class FragmentData : ItemInteractable
{
    public string memoryText = "これは過去の断片的な記憶だ…";

    public override void Collect()
    {
        Debug.Log($"断片データを入手: {memoryText}");

        // メモ帳に記憶を追加して、成功したときだけ消す
        bool success = MemoryManager.Instance.AddMemory(memoryText);
        if (success)
        {
            gameObject.SetActive(false); // 追加に成功したときだけ非表示
        }
    }
}
