using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Chase : StateMachineBehaviour
{
    Transform transform = null;
    Transform playerTransform = null;

    float aproxTreshold = 1.0f;
    private Enemy enemyScipt;
    Animator animsAnimator = null;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        enemyScipt = animator.gameObject.GetComponent<Enemy>();
        transform = animator.gameObject.transform;
        playerTransform = animator.gameObject.GetComponent<Enemy>().playerTransform;
        animsAnimator = animator.gameObject.GetComponent<Enemy>().animator;
        animsAnimator.SetBool("isWalking", true);
    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        //transform.rotation = Quaternion.LookRotation(playerTransform.position - transform.position, Vector3.up);

        Vector3 playerVector = playerTransform.position - transform.position;
        playerVector.Normalize();
        playerVector.y = 0;
        Debug.DrawRay(transform.position, playerVector * 10.0f, Color.red);

        enemyScipt.Move(playerTransform.position);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animsAnimator.SetBool("isWalking", false);
    }




}
