using System;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    public event Action onLoseTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        onLoseTriggered();
    }

}
