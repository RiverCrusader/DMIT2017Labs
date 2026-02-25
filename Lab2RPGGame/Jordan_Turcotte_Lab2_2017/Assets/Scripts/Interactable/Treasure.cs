using UnityEngine;
using UnityEngine.Events;

public class Treasure : MonoBehaviour, IInteractableObject
{
    public UnityEvent OnInteract;
    public void Interact()
    {
        OnInteract?.Invoke();
    }
}
