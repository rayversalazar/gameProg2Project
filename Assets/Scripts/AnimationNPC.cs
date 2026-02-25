using UnityEngine;

public class AnimationNPC : MonoBehaviour
{
    Animator animator;
    int animParameterId;
    int animParameterId2;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        
    }
    private void Start()
    {
        animParameterId = Animator.StringToHash("Interact");
        animParameterId2 = Animator.StringToHash("Idle");
        animator.SetBool(animParameterId2, true);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool(animParameterId, true);
        animator.SetBool(animParameterId2, false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool(animParameterId, false);
        animator.SetBool(animParameterId2, true);

    }
}
