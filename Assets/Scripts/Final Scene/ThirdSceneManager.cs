using UnityEngine;
using Movement;
using TMPro;
using UnityEngine.SceneManagement;

public class ThirdSceneManager : MonoBehaviour
{
    [SerializeField]
    WinTrigger winTrigger;
    [SerializeField]
    LoseTrigger loseTrigger;

    [SerializeField]
    FirstPersonMovement playerMovement;
    [SerializeField]
    FirstPersonLook playerLook;

    [SerializeField]
    GameObject winLoseCanvas;
    [SerializeField]
    TextMeshProUGUI canvasText;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        winTrigger.onWinTriggered += HandleWin;
        loseTrigger.onLoseTriggered += HandleLose;
    }

    public void RestartScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void HandleLose()
    {
        winLoseCanvas.SetActive(true);
        canvasText.text = "You Died!";
        ToggleCursor(true);
        playerLook.enabled = false;
        playerMovement.enabled = false;
        Time.timeScale = 0;
    }

    private void HandleWin()
    {
        winLoseCanvas.SetActive(true);
        canvasText.text = "You Win!";
        ToggleCursor(true);
        playerLook.enabled = false;
        playerMovement.enabled = false;
        Time.timeScale = 0;
    }
    private void ToggleCursor(bool shouldBeActive)
    {
        if (shouldBeActive)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        Cursor.visible = shouldBeActive;
    }

}
