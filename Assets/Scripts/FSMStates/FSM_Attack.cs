using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Attack : StateMachineBehaviour
{
    Animator animsAnimator = null;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animsAnimator = animator.gameObject.GetComponent<Enemy>().animator;
        animsAnimator.SetBool("isAttacking", true);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animsAnimator.SetBool("isAttacking", false);
    }

}
