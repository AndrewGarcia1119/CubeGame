using System.Collections;
using UnityEngine;
using Movement;

public class ThirdEventTrigger : EventTrigger
{
    [SerializeField]
    GameObject scareCanvas;
    [SerializeField]
    AudioClip scareSound;
    [SerializeField]
    float scareTime = 0.3f;

    private void OnTriggerEnter(Collider other)
    {
        if (eventTriggered) return;
        if (other.tag != "Player") return;
        eventTriggered = true;
        StartCoroutine(StartEventSequence());
    }

    protected override void TriggerDialogueEvent(int eventTrigger)
    {
        if (eventTrigger == eventDialogue.Length - 1)
        {
            StartCoroutine(TriggerEventSequence());
        }
    }
    protected override IEnumerator StartEventSequence()
    {
        var playerMovement = FindObjectOfType<FirstPersonMovement>();
        playerMovement.enabled = false;
        var playerLook = playerMovement.GetComponentInChildren<FirstPersonLook>();
        playerLook.enabled = false;
        yield return base.StartEventSequence();
        playerMovement.enabled = true;
        playerLook.enabled = true;
    }
    private IEnumerator TriggerEventSequence()
    {
        AudioSource.PlayClipAtPoint(scareSound, transform.position);
        scareCanvas.SetActive(true);
        yield return new WaitForSeconds(scareTime);
        scareCanvas.SetActive(false);
    }
}
