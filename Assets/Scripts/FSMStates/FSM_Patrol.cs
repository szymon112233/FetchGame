using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Patrol : StateMachineBehaviour
{

    [SerializeField]
    Vector3 destPos = new Vector3();
    [SerializeField]
    Vector3 dirVector = new Vector3();

    bool isFollowing = false;

    float speed = 5.0f;
    float aproxTreshold = 1.0f;

    public float patrolRange = 5.0f;



    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        speed = animator.gameObject.GetComponent<Enemy>().speed;
    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (!isFollowing)
        {
            destPos = new Vector3(Random.Range(-patrolRange, patrolRange), 0, Random.Range(-patrolRange, patrolRange));
            destPos += animator.gameObject.transform.position;
            dirVector = destPos - animator.gameObject.transform.position;
            dirVector.Normalize();
            dirVector.y = 0.0f;
            isFollowing = true;
        }
        else
        {
            if (Mathf.Abs((destPos - animator.gameObject.transform.position).sqrMagnitude) > aproxTreshold)
                animator.gameObject.transform.position += (dirVector * speed * Time.deltaTime);
            else
                isFollowing = false;
        }
    }

    


}
