using UnityEngine;

public class Merchant : MonoBehaviour, IInteractible
{
    public void Interact()
    {
        Debug.Log("Merchant: Welcome to my shop! What would you like to buy?");
        // Here you could open a shop UI or trigger a dialogue system
    }
    public string GetInteractionPrompt()
    {
        return "Press E to talk to the merchant.";
    }
}
