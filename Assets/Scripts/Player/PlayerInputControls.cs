using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

 //handles the input of the player
public class PlayerInputControls : MonoBehaviour
{
    Rigidbody2D rb;
    public PlayerInput playerInput;

    public InputActionMap playerActionMap;

    public InputActionReference movementActionRef;

    public float horizontalInput;
    public float movementSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerActionMap = playerInput.actions.FindActionMap("Player");
        playerActionMap.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = movementActionRef.action.ReadValue<float>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movementSpeed * horizontalInput, rb.linearVelocityY);
    }
   
}
