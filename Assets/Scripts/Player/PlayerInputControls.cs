using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

 //handles the input of the player
public class PlayerInputControls : MonoBehaviour
{
    public InputActionMap playerActionMap;

    public InputActionReference movementActionRef;
    public InputActionReference jumpActionRef;

    public float horizontalInput;

    void Start()
    {
       
    }
    private void OnEnable()
    {
        playerActionMap.Enable();
    }
    private void OnDisable()
    {
        playerActionMap.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = movementActionRef.action.ReadValue<float>(); 
    }
    public bool JumpTriggered()
    {
        return jumpActionRef.action.WasPerformedThisFrame();
    }
    private void FixedUpdate()
    {
    }
}
