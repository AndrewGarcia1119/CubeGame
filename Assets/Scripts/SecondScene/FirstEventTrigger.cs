using System.Collections;
using UnityEngine;

public class FirstEventTrigger : EventTrigger
{
    [SerializeField]
    GameObject dotCanvas;
    protected override void TriggerDialogueEvent(int eventTrigger)
    {
        return;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player") return;
        if (eventTriggered) return;
        eventTriggered = true;
        StartCoroutine(StartEventSequence());
    }
    protected override IEnumerator StartEventSequence()
    {
        yield return base.StartEventSequence();
        GameObject.FindWithTag("Player").GetComponent<InteractionController>().enabled = true;
        dotCanvas.SetActive(true);
    }
}
