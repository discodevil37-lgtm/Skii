using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float forcePower;

    [SerializeField]
    private Rigidbody rb;

    private InputAction moveAction;
    private Vector2 moveValue;

    [SerializeField]
    private int point;
    public int Point { get { return point; } set { point = value; } }

    [SerializeField]
    private int hp;
    public int HP { get { return hp; } set { hp = value; } }

    private bool isDead = false;
    public bool IsDead { get { return isDead; } set { isDead = value; } }

    private bool isFinished = false; // ตัวแปรเช็กว่าถึงเส้นชัยหรือยัง

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isDead || isFinished) return;

        MoveLeftOrRight();
    }

    private void MoveLeftOrRight()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        rb.AddForce(moveValue.x * Vector3.right * forcePower);
    }

    public void Die()
    {
        if (isDead || isFinished) return;

        isDead = true;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowGameOver();
        }
    }

    // ฟังก์ชัน Win ที่ขาดหายไป (เพิ่มฟังก์ชันนี้เพื่อแก้ Error)
    public void Win()
    {
        if (isDead || isFinished) return;

        isFinished = true;

        // สั่งหยุดความเร็วฟิสิกส์ตัวละคร
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowWinUI(point);
        }
    }
}