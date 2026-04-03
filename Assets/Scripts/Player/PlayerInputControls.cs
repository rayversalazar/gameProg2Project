using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

 //handles the input of the player
public class PlayerInputControls : MonoBehaviour
{
    public PlayerControls inputs;
    public InputAction movement;
    public InputAction attack;
    public InputAction jump;
    public InputAction dash;

    public float horizontalInput;
    public float jumpInput;

    private void Awake()
    {
        inputs = new PlayerControls();
    }
    void Start()
    {
        movement = inputs.Player.Movement;
        attack = inputs.Player.Attack;
        jump = inputs.Player.Jump;
        dash = inputs.Player.Dash;
    }
    private void OnEnable()
    {
        inputs.Enable();
    }
    private void OnDisable()
    {
        inputs.Disable();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = movement.ReadValue<float>();
        jumpInput = jump.ReadValue<float>();
    }
    private void FixedUpdate()
    {
    }
}
