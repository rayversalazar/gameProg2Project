using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayer;
    private IInteractible currentInteractible;

    private void Update()
    {
        // Check for the "E" key using the New Input System's quick check
        if (currentInteractible != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            currentInteractible.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Bitmask check to see if the layer matches
        if (((1 << collision.gameObject.layer) & interactableLayer) != 0)
        {
            currentInteractible = collision.GetComponent<IInteractible>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<IInteractible>() == currentInteractible)
        {
            currentInteractible = null;
        }
    }
}