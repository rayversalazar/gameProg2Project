using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

 //handles the input of the player
public class PlayerInputControls : MonoBehaviour
{
    public InputActionMap playerActionMap;

    public InputActionReference movementActionRef;

    public float horizontalInput;

    void Start()
    {
        playerActionMap.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = movementActionRef.action.ReadValue<float>(); 
    }
    private void FixedUpdate()
    {
    }
}
