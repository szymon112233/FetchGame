using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Chase : StateMachineBehaviour
{
    Transform transform = null;
    Transform playerTransform = null;



    float speed = 5.0f;

    float aproxTreshold = 1.0f;




    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        speed = animator.gameObject.GetComponent<Enemy>().speed;
        transform = animator.gameObject.transform;
        playerTransform = animator.gameObject.GetComponent<Enemy>().playerTransform;
    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        transform.rotation = Quaternion.LookRotation(playerTransform.position - transform.position, Vector3.up);

        Vector3 playerVector = playerTransform.position - transform.position;
        playerVector.Normalize();
        playerVector *= (speed * Time.deltaTime);
        playerVector.y = 0;
        Debug.DrawRay(transform.position, playerVector * 10.0f, Color.red);

        transform.position += playerVector;
    }




}
