using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    public List<InteractionColliderState> interactionColliderStates = new List<InteractionColliderState>();
    private Dictionary<PlayerAnimationState, GameObject> colliderDictionary = new Dictionary<PlayerAnimationState, GameObject>();
    private PlayerAnimation animationController;
    public GameObject targetInteractable;
    public InputAction interact;
    private void Start()
    {
        InitializeDictionary();
        animationController = GetComponent<PlayerAnimation>();
        
        animationController.OnAnimationStateUpdate += UpdateInteractionCollider;

        interact.Enable();
        interact.performed += Interact;
    }

    public void Interact(InputAction.CallbackContext c)
    {
        if (targetInteractable == null) return;
        targetInteractable.GetComponent<Treasure>().Interact();
    }
    public void InitializeDictionary()
    {
        colliderDictionary = new Dictionary<PlayerAnimationState, GameObject>();
        foreach (var state in interactionColliderStates)
        {

            colliderDictionary.Add(state.animationState, state.collider);
        }
    }

    public void UpdateInteractionCollider(PlayerAnimationState state)
    {
        foreach (KeyValuePair<PlayerAnimationState, GameObject> kvp in colliderDictionary)
        {
            kvp.Value.SetActive(false);
        }

        colliderDictionary[state].SetActive(true);
    }
}

[Serializable]
public class InteractionColliderState
{
    public PlayerAnimationState animationState;
    public GameObject collider;

    
}
