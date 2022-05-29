using System.Collections;
using Movement;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneManager : MonoBehaviour
{
    [SerializeField]
    GameObject fakeLoseCanvas;
    [SerializeField]
    TextMeshProUGUI fakeLoseCanvasMainText;
    [SerializeField]
    float[] waitTimes;
    [SerializeField]
    [Tooltip("First Item in the array is the default, should be same size as wait Times")]
    string[] textOutputs;
    [SerializeField]
    Menu menu;

    private bool hasStartedSequence;

    private void Awake()
    {
        fakeLoseCanvas.SetActive(false);
        menu.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fakeLoseCanvas.SetActive(true);
        fakeLoseCanvasMainText.text = textOutputs[0];
        Time.timeScale = 0;
        other.gameObject.GetComponentInChildren<FirstPersonLook>().ToggleLook(false);
    }

    public void PlaySequence()
    {
        if (hasStartedSequence) return;
        StartCoroutine(StartSequence());
    }

    private IEnumerator StartSequence()
    {
        hasStartedSequence = true;
        for (int i = 0; i < waitTimes.Length; i++)
        {
            fakeLoseCanvasMainText.text = textOutputs[i];
            yield return new WaitForSecondsRealtime(waitTimes[i]);
        }
        LoadNextScene();
    }
    private void LoadNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }
}
