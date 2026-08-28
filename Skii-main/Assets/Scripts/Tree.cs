using UnityEngine;

public class Tree : MonoBehaviour
{
    private MeshRenderer rd;

    void Start()
    {
        rd = GetComponent<MeshRenderer>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        rd.material.color = Color.red;

        Player player = collision.gameObject.GetComponent<Player>();

        if (player == null)
            return;

        player.HP -= 15;
        UIManager.Instance.ShowNotiText($"Hurt -15\nHP: {player.HP}");

        if (player.HP <= 0)
        {
            player.HP = 0;
            player.Die(); // สั่งแพ้ผ่าน Player.cs (ให้ผลเหมือนตอนตกแผ่นใต้ฉาก)
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        rd.material.color = new Color32(132, 79, 40, 255);
    }
}