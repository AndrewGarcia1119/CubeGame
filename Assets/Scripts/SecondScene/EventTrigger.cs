using System.Collections;
using TMPro;
using UnityEngine;

public abstract class EventTrigger : MonoBehaviour
{
    [SerializeField]
    protected GameObject eventCanvas;
    [SerializeField]
    protected TextMeshProUGUI canvasText;
    [SerializeField]
    protected Dialogue[] eventDialogue;
    [SerializeField]
    protected bool shouldTriggerEvent = false;

    protected bool eventTriggered = false;

    [System.Serializable]
    protected struct Dialogue
    {
        public string textOutput;
        public float waitTime;
        // [Tooltip("The dialogue trigger value does not matter if shouldTriggerEvent is false")]
        // public int dialogueTrigger;
    }

    protected virtual void ToggleEventCanvas(bool shouldBeActive)
    {
        eventCanvas.SetActive(shouldBeActive);
    }

    protected virtual IEnumerator StartEventSequence()
    {
        ToggleEventCanvas(true);
        for (int i = 0; i < eventDialogue.Length; i++)
        {
            canvasText.text = eventDialogue[i].textOutput;
            yield return new WaitForSeconds(eventDialogue[i].waitTime);
            if (shouldTriggerEvent)
            {
                TriggerDialogueEvent(i);
            }
        }
        ToggleEventCanvas(false);
    }

    protected abstract void TriggerDialogueEvent(int eventTrigger);
}
