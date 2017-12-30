using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Patrol : StateMachineBehaviour
{
    public float patrolRange = 5.0f;

    [SerializeField]
    Vector3 destPos = new Vector3();
    [SerializeField]
    Vector3 dirVector = new Vector3();
    bool isFollowing = false;
    float aproxTreshold = 1.0f;
    private Enemy enemyScipt;
    Animator animsAnimator = null;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        enemyScipt = animator.gameObject.GetComponent<Enemy>();
        animsAnimator = enemyScipt.animator;
        animsAnimator.SetBool("isWalking", true);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (!isFollowing)
        {
            destPos = new Vector3(Random.Range(-patrolRange, patrolRange), 0, Random.Range(-patrolRange, patrolRange));
            destPos += animator.gameObject.transform.position;
            isFollowing = true;
        }
        else
        {
            if (Mathf.Abs((destPos - animator.gameObject.transform.position).sqrMagnitude) > aproxTreshold)
                enemyScipt.Move(destPos);
            else
                isFollowing = false;
        }

    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animsAnimator.SetBool("isWalking", false);
    }
}
