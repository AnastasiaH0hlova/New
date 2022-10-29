using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static InventoryManager;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private int numFound;

    private readonly Collider[] _colliders = new Collider[3];
    private Interactable _interactable;
    private bool _interactableIsNull;
    
    private void Update()
    {
        // player won't be able to interact with objects when the inventory is open
        // basically, block the keybindings
        if (InventoryPanelIsActive) return;
        
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position,
            interactionPointRadius, _colliders, interactableMask);

        _interactableIsNull = _interactable == null;

        // if the player is out of range of all interactable objects, then disable labels
        if (numFound <= 0)
        {
            if (!_interactableIsNull && _interactable.PromptIsActive) _interactable.TogglePrompt();
            return;
        }

        _interactable = _colliders[0].GetComponent<Interactable>();
        if (_interactableIsNull || !_interactable.ItemIsActive) return;

        // if interactable item was found
        if (!_interactable.PromptIsActive) _interactable.TogglePrompt();

        // if the E key was pressed
        if (!Keyboard.current.eKey.wasPressedThisFrame) return;
        _interactable.Interact(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}