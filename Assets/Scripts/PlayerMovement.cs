using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 3f;       // �ʏ�̃X�s�[�h
    public float runSpeed = 6f;        // Shift�L�[�������Ă���Ƃ��̃X�s�[�h

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �L�[���͂��擾
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Shift��������Ă���Α�������
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        // ���͕����Ɉړ�
        rb.MovePosition(rb.position + movement.normalized * currentSpeed * Time.fixedDeltaTime);
    }
}
