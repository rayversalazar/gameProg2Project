using UnityEngine;
using UnityEngine.InputSystem;
public interface IInteractible
{
    void Interact();
    void OnTouchingPlayer();
    void OnNotTouchingPlayer();
}

public class Interactor : MonoBehaviour
{
    public InputAction interactAction;
    private IInteractible currentInteractable;
    void OnEnable()
    {
        interactAction.Enable();
    }

    void OnDisable()
    {
        interactAction.Disable();
    }

    void Update()
    {
        if (interactAction.triggered && currentInteractable != null)
        {
            Debug.Log("Interacting with: " + currentInteractable);
            currentInteractable.Interact();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        IInteractible interactable = collision.GetComponent<IInteractible>();

        if (interactable != null)
        {
            currentInteractable = interactable;
            currentInteractable.OnTouchingPlayer();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractible interactable = collision.GetComponent<IInteractible>();

        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable.OnNotTouchingPlayer();
            currentInteractable = null;
        }
    }
}