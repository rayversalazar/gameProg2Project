using System.ComponentModel;
using UnityEngine;

public class TestWalkAnimation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    PlayerInputControls playerInputControls;
    public Animator animator;
    private string idleParameterName="Idle";
    private int idleParameterID;
    private string walkParameterName = "Walk";
    private int walkParameterID;
    private void Awake()
    {
        playerInputControls = GetComponent<PlayerInputControls>();
        walkParameterID = Animator.StringToHash(walkParameterName);
        idleParameterID = Animator.StringToHash(idleParameterName);
    }
    void Start()
    {
        
        animator.SetBool(idleParameterID, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInputControls.horizontalInput!=0)
        {
            animator.SetBool(walkParameterID, true);
            animator.SetBool(idleParameterID, false);
        } else
        {
            animator.SetBool(idleParameterID, true);
            animator.SetBool(walkParameterID, false);
        }
    }
}
