using UnityEngine;

public class InteractionCollider : MonoBehaviour
{
    public InteractionController interactionController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Treasure>() == null) return;
        interactionController.targetInteractable = collision.gameObject;
    }

    private void OnDisable()
    {
        interactionController.targetInteractable = null;
    }
}
