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
    public InputActionReference attackActionRef;
    public InputActionReference dashActionRef;

    public float horizontalInput;
    public float jumpInput;

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
        jumpInput = jumpActionRef.action.ReadValue<float>();
    }
    private void FixedUpdate()
    {
    }
}
