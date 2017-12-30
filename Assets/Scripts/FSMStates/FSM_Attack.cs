using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Attack : StateMachineBehaviour
{
    Animator animsAnimator = null;
    Enemy enemyScipt = null;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        enemyScipt = animator.gameObject.GetComponent<Enemy>();
        enemyScipt.Move(animator.transform.position);
        animsAnimator = animator.gameObject.GetComponent<Enemy>().animator;
        animsAnimator.SetBool("isAttacking", true);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        Vector3 dirVector = enemyScipt.playerTransform.position - animator.gameObject.transform.position;
        dirVector.Normalize();
        dirVector.y = 0.0f;
        enemyScipt.transform.rotation = Quaternion.LookRotation(dirVector, Vector3.up);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animsAnimator.SetBool("isAttacking", false);
    }

}
