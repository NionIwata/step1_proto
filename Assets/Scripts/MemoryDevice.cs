using UnityEngine;

public class MemoryDevice : ItemInteractable
{
    public override void Collect()
    {
        MemoryManager.Instance.AddMemorySlot();
        base.Collect();
    }
}
