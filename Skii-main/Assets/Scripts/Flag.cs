using UnityEngine;

public class Flag : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // ใช้ GetComponentInParent เพื่อหา Player แม้ Collider จะอยู่ที่ Child Object
        Player player = other.GetComponentInParent<Player>();

        if (player == null)
            return;

        player.Point += 10;

        UIManager.Instance.ShowNotiText($"+10 points\nPoint: {player.Point}");

        Destroy(gameObject);
    }
}