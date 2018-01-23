using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickUpType
{
    HEALTH,
    AMMO
}


public class Pickup : MonoBehaviour {

    PickUpType type;
    int ammount;

    private void Awake()
    {
        type = PickUpType.AMMO;
        ammount = 30;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovment>().GetPickup(type, ammount);
            Destroy(gameObject);
        }
    }
}
