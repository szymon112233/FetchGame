using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public float visionRadius = 10.0f;
    public float attackDistance = 2.0f;
    public float speed = 10.0f;

    public float maxHP = 200.0f;
    private float currentHP = 1;

    private Animator animatorFSM = null;
    public Animator animator = null;

    public NavMeshAgent navAgent;
    private Transform target;
    public Transform playerTransform = null;



    private bool isChasing = false;
    int counter = 0;
    int perXFrames = 3;


    private void Awake()
    {
        currentHP = maxHP;
        animatorFSM = gameObject.GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
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
            animatorFSM.SetBool("isPlayerInRange", (Mathf.Abs((playerTransform.position - transform.position).sqrMagnitude) < visionRadius * visionRadius));
            animatorFSM.SetBool("isInAttackRange", (Mathf.Abs((playerTransform.position - transform.position).sqrMagnitude) < attackDistance * attackDistance));
        }

        
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DealDamage(collision.gameObject.GetComponent<Bullet>().damage);
        }
            
    }

    public void Move(Vector3 target)
    {
        /*
        Vector3 speedVector = direction;
        speedVector *= speed;
        chController.SimpleMove(speedVector);
        */

        navAgent.SetDestination(target);
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
        SpawnManager.Instance.spawnedEnemies.Remove(gameObject);
        Destroy(gameObject);
    }

}
