using UnityEngine;

public class FourthEventTrigger : EventTrigger
{
    protected override void TriggerDialogueEvent(int eventTrigger)
    {
        if (eventTrigger == eventDialogue.Length - 1)
        {
            FindObjectOfType<CubeSpawner>().SpawnCube();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (eventTriggered) return;
        if (other.gameObject.tag != "Player") return;
        eventTriggered = true;
        StartCoroutine(StartEventSequence());
    }
}
