using UnityEngine;

public class SecondEventTrigger : EventTrigger
{
    [SerializeField]
    Animator triggeredFootsteps;

    protected override void TriggerDialogueEvent(int eventTrigger)
    {
        return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (eventTriggered) return;
        if (other.tag != "Player") return;
        eventTriggered = true;
        triggeredFootsteps.SetTrigger("Steps");

    }
}
