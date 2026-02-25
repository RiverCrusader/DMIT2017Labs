using System;
using UnityEngine;

public class Heal : MonoBehaviour
{
   public event Action OnHeal;

    public void HealPlayer()
    {
        OnHeal?.Invoke();
    }
}
