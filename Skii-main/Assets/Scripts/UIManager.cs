using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text notiText;

    [SerializeField]
    private GameObject restartButton;

    [SerializeField]
    private GameObject mainMenuButton;

    [SerializeField]
    private Player player;

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ShowHideButtons(false);
    }

    public void ShowNotiText(string s)
    {
        if (notiText != null)
        {
            notiText.text = s;
        }
    }

    // แสดงหน้าแพ้
    public void ShowGameOver()
    {
        ShowNotiText("YOU DIE!!");
        ShowHideButtons(true);
    }

    // แสดงหน้าชนะ (เปลี่ยนเฉพาะ Text + เปิดปุ่มชุดเดียวกัน)
    public void ShowWinUI(int score)
    {
        ShowNotiText($"YOU WIN yay <3!\nPoints: {score}");
        ShowHideButtons(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu"); 
    }

    public void ShowHideButtons(bool flag)
    {
        if (restartButton != null)
        {
            restartButton.SetActive(flag);
        }

        if (mainMenuButton != null)
        {
            mainMenuButton.SetActive(flag);
        }
    }
}