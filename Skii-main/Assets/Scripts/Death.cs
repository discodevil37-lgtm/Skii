using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // ตรวจว่าวัตถุที่มาชนแผ่นนี้คือ Player หรือไม่
        Player player = other.GetComponentInParent<Player>();

        if (player != null)
        {
            // เรียกฟังก์ชันแสดงหน้าแพ้ทันทีที่ตัวละครหลุดมาชนแผ่น
            if (UIManager.Instance != null)
            {
                UIManager.Instance.ShowGameOver();
            }
        }
    }
}