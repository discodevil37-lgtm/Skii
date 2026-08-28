using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Startgame()
    {
        SceneManager.LoadScene("Scene01");
    }

    // เติม public ด้านหน้าเพื่อให้ Unity มองเห็นฟังก์ชันนี้
    public void Exit()
    {
        Application.Quit();
    }
}