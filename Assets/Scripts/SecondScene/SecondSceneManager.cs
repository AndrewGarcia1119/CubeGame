using System.Collections.Generic;
using UnityEngine;

public class SecondSceneManager : MonoBehaviour
{
    [SerializeField]
    EventTrigger firstEventTrigger;

    [SerializeField]
    GameObject dotCanvas;

    [SerializeField]
    AudioClip completeObjectiveSound;

    [SerializeField]
    Transform player;

    List<Item> items = new List<Item>();

    private void Start()
    {
        Time.timeScale = 1;
        foreach (Item item in FindObjectsOfType<Item>())
        {
            items.Add(item);
        }
        Item.onItemTaken += HandleItemTaken;
    }


    private void HandleItemTaken(Item item)
    {
        items.Remove(item);
        if (items.Count < 1)
        {
            firstEventTrigger.gameObject.SetActive(false);
            dotCanvas.SetActive(false);
            AudioSource.PlayClipAtPoint(completeObjectiveSound, player.position);
        }
    }

}
