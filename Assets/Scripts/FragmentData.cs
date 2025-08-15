using UnityEngine;

public class FragmentData : ItemInteractable
{
    public string memoryText = "����͉ߋ��̒f�ГI�ȋL�����c";

    public override void Collect()
    {
        Debug.Log($"�f�Ѓf�[�^�����: {memoryText}");

        // �������ɋL����ǉ����āA���������Ƃ���������
        bool success = MemoryManager.Instance.AddMemory(memoryText);
        if (success)
        {
            gameObject.SetActive(false); // �ǉ��ɐ��������Ƃ�������\��
        }
    }
}
