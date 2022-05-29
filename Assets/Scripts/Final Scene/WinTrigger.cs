using System;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public event Action onWinTriggered;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player") return;
        onWinTriggered();
    }
}
