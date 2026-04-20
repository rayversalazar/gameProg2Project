using UnityEngine;

public class MiniBossStateMachine : MonoBehaviour
{
    public MiniBossBaseState currentState;
    public MiniBossIdleState idle;
    public MiniBossChaseState chase;
    public MiniBossAttackState attack;
    public MiniBossWindUpState windUp;
    public MiniBossLungeState lunge;
    public MiniBossRestState rest;
    public MiniBossDeathState death;
    public bool isActive = false;
    public bool isAlive = true;
    public BossRoomController roomController;
    public float maxHP = 100f;
    public float currentHP;

    public void SetRoomController(BossRoomController controller)
    {
        roomController = controller;
    }
    public void ActivateBoss()
    {
        isActive = true;
    }
    private void Start()
    {
        //default state
        currentState = idle;
        currentState.OnEnter(this);
        currentHP = maxHP;
    }
    private void Update()
    {
        currentState.ProcessAbility(this);
    }

    private void FixedUpdate()
    {
        currentState.FixedProcessAbility(this);
    }

    public void ChangeState(MiniBossBaseState newState)
    {
        currentState.OnExit(this);
        currentState = newState;
        currentState.OnEnter(this);
    } 

}
