using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float visionRadius = 10.0f;
    public float attackDistance = 2.0f;
    public float speed = 10.0f;

    public float maxHP = 200.0f;
    private float currentHP = 1;

    public Transform playerTransform = null;

    private Animator animator = null;
    private CharacterController chController;



    private bool isChasing = false;
    int counter = 0;
    int perXFrames = 3;


    private void Awake()
    {
        currentHP = maxHP;
        animator = gameObject.GetComponent<Animator>();
        chController = GetComponent<CharacterController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        counter = Random.Range(0, perXFrames);
    }

    void Start () {
        
	}
	
	void Update () {
        counter++;
        if (counter % perXFrames == 0)
        {
            counter = 0;
            animator.SetBool("isPlayerInRange", (Mathf.Abs((playerTransform.position - transform.position).sqrMagnitude) < visionRadius * visionRadius));
            animator.SetBool("isInAttackRange", (Mathf.Abs((playerTransform.position - transform.position).sqrMagnitude) < attackDistance * attackDistance));
        }

        
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DealDamage(collision.gameObject.GetComponent<Bullet>().damage);
        }
            
    }

    public void Move(Vector3 direction)
    {
        Vector3 speedVector = direction;
        speedVector *= speed;
        chController.SimpleMove(speedVector);
    }

    public void DealDamage(float value)
    {
        currentHP -= value;

        if (currentHP < 0.0f)
            Die();
    }

    void Die()
    {
        isChasing = false;
        visionRadius = -1;
        Destroy(gameObject);
    }

}
