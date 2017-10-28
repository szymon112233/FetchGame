using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour {

    public float speed = 10;

    public Transform targetTransform;
    public Rigidbody rigidBody;


    void Update () {
        UpdateInput();
	}

    private void UpdateInput()
    {
        Vector3 translateVector = new Vector3();

        translateVector.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        translateVector.z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        rigidBody.MovePosition(rigidBody.position + translateVector);

        if (targetTransform != null)
        {
            rigidBody.rotation = Quaternion.LookRotation(new Vector3(targetTransform.position.x, rigidBody.position.y, targetTransform.position.z) - rigidBody.position, Vector3.up);
            Debug.DrawLine(rigidBody.position, new Vector3(targetTransform.position.x, rigidBody.position.y, targetTransform.position.z));
        }
            

    }
}
