using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovment : MonoBehaviour {

    public static UnityEvent OnPlayerKilled = new UnityEvent();

    public float speed = 10;
    public Gun gun = null;

    public float maxHP = 200.0f;

    public bool isGodMode = false;

    [SerializeField]
    private float currentHP = 1;
    public float CurrentHP
    {
        get
        {
            return currentHP;
        }
    }

    public Transform targetTransform;
    public Transform gunPointTransform;
    public CharacterController chController;
    public GameObject bulletPrefab;
    public Animator animator;

    private void Awake()
    {
        currentHP = maxHP;
    }

    void Update () {
        UpdateInput();
        UpdateCheats();
    }

    private void UpdateInput()
    {
        Vector3 translateVector = new Vector3();

        translateVector.x = Input.GetAxis("Horizontal") * speed;
        translateVector.z = Input.GetAxis("Vertical") * speed;

        chController.SimpleMove(translateVector);
        animator.SetFloat("Speed", translateVector.magnitude);
        if (targetTransform != null && gunPointTransform != null && (transform.position - targetTransform.position).sqrMagnitude > 10)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(targetTransform.position.x, gunPointTransform.position.y, targetTransform.position.z) - gunPointTransform.position, Vector3.up);
            Debug.DrawLine(gunPointTransform.position, new Vector3(targetTransform.position.x, transform.position.y, targetTransform.position.z));
        }
        

        if (Input.GetButton("Fire1"))
        {
            gun.Shoot(gunPointTransform.position, targetTransform.position);
        }

    }

    private void UpdateCheats()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            isGodMode = !isGodMode;

        if (Input.GetKeyDown(KeyCode.F2))
            gun.ammo += 100;

    }

    

    public void DealDamage(float value)
    {
        if (!isGodMode)
            currentHP -= value;

        if (currentHP <= 0.0f)
            Die();
    }

    void Die()
    {
        if (!isGodMode)
        {
            OnPlayerKilled.Invoke();
            Destroy(gameObject);
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            DealDamage(other.gameObject.GetComponent<Weapon>().Damage);
        }
    }

    public void GetPickup(PickUpType type, int value)
    {
        gun.ammo += value;
    }
}
