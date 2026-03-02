using System;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public event Action OnChestOpen;

    public void OpenChest()
    {
        OnChestOpen?.Invoke();
    }
}
