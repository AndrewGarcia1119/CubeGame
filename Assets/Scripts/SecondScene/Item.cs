using System;
using UnityEngine;

public class Item : MonoBehaviour
{

    public static event Action<Item> onItemTaken;

    public void Take()
    {
        onItemTaken?.Invoke(this);
        Destroy(gameObject);
    }
}
