using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour {

    public float speed = 10;
    public float bulletForce = 10;

    public float shootInterval = 0.5f;
    public float shootTimer = 0.0f;


    public Transform targetTransform;
    public Transform gunPointTransform;
    public CharacterController chController;
    public GameObject bulletPrefab;
    public Animator animator;

    void Update () {
        UpdateTimers();
        UpdateInput();
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
            if (shootTimer <= 0.0f)
                Shoot(translateVector);
        }

    }

    private void UpdateTimers()
    {
        if (shootTimer > 0.0f)
            shootTimer -= Time.deltaTime;
    }

    private void Shoot(Vector3 moveVector)
    {
        GameObject bullet = Instantiate(bulletPrefab, gunPointTransform.position, new Quaternion()) as GameObject;
        if (bullet != null)
        {
            Vector3 forceVector = new Vector3(targetTransform.position.x, transform.position.y, targetTransform.position.z) - gunPointTransform.position;
            forceVector.Normalize();
            forceVector *= bulletForce;
            bullet.GetComponent<Rigidbody>().AddForce(forceVector, ForceMode.Impulse);
            shootTimer = shootInterval;
        }
    }
}
