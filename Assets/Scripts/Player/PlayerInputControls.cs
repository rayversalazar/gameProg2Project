using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

 //handles the input of the player
public class PlayerInputControls : MonoBehaviour
{
    public PlayerControls inputs;

    public InputActionMap debug;
    public InputActionMap player;

    public InputAction movement;
    public InputAction attack;
    public InputAction jump;
    public InputAction dash;
    public InputAction pause;
    public InputAction heal;
    public InputAction wakeUp;

    public float horizontalInput;
    public float jumpInput;
    public float healInput;

    private void Awake()
    {
        inputs = new PlayerControls();
        debug = inputs.Debug;
        player = inputs.Player;
        movement = inputs.Player.Movement;
        attack = inputs.Player.Attack;
        jump = inputs.Player.Jump;
        dash = inputs.Player.Dash;
        pause = inputs.Player.PauseGame;
        heal = inputs.Player.Heal;
        wakeUp = inputs.Debug.WakeUp;
    }
    void Start()
    {
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
        healInput = heal.ReadValue<float>();
    }
    private void FixedUpdate()
    {
    }
}
