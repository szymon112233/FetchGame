using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public string name;

    public GameObject bulletPrefab;

    public float bulletForce = 10;

    public float shootInterval = 0.5f;
    public float shootTimer = 0.0f;

    public int ammo = 0;

    void Update()
    {
        UpdateTimers();
    }

    private void UpdateTimers()
    {
        if (shootTimer > 0.0f)
            shootTimer -= Time.deltaTime;
    }

    public void Shoot(Vector3 gunPointPosition, Vector3 targetPosition)
    {
        if (ammo > 0 && shootTimer <= 0.0f)
        {
            GameObject bullet = Instantiate(bulletPrefab, gunPointPosition, new Quaternion()) as GameObject;
            if (bullet != null)
            {
                Vector3 forceVector = new Vector3(targetPosition.x, transform.position.y, targetPosition.z) - gunPointPosition;
                forceVector.Normalize();
                forceVector.y = 0.0f;
                forceVector *= bulletForce;
                bullet.GetComponent<Rigidbody>().AddForce(forceVector, ForceMode.Impulse);
                shootTimer = shootInterval;
                ammo--;
            }
        }
        
    }

}
