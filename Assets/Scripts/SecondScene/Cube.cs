using UnityEngine;
using UnityEngine.SceneManagement;

public class Cube : EventTrigger
{
    private void Start()
    {
        eventCanvas = GetComponentInParent<CubeSpawner>().eventCanvas;
        canvasText = GetComponentInParent<CubeSpawner>().canvasText;
    }

    protected override void TriggerDialogueEvent(int eventTrigger)
    {
        if (eventTrigger == eventDialogue.Length - 1)
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index + 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (eventTriggered) return;
        if (other.tag != "Player") return;
        eventTriggered = true;
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(StartEventSequence());
    }

}
