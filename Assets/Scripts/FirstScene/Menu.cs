using UnityEngine;
using Movement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    FirstPersonMovement playerMovement;
    [SerializeField]
    FirstPersonLook playerLook;
    [SerializeField]
    Jump playerJump;


    private void Start()
    {
        TogglePlayer(false);
    }

    public void TogglePlayer(bool shouldBeActive)
    {
        playerMovement.enabled = shouldBeActive;
        playerLook.enabled = shouldBeActive;
        playerJump.enabled = shouldBeActive;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
