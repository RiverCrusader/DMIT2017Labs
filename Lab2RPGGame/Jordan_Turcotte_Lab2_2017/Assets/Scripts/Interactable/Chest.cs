using System;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public event Action OnChestOpen;
    public bool hasBeenOpened = false;

    public void OpenChest()
    {
        if(!hasBeenOpened) OnChestOpen?.Invoke();
        hasBeenOpened = true;
    }
}
