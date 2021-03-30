using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform cameraPivotTransform;
    public float speed = 5;
    public float torque = 0.6f;

    private Rigidbody playerRigid;
    private float forwardMovement = 0f;
    private Vector3 cameraForward;

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update() 
    {
        forwardMovement = Input.GetAxis("Vertical");
        cameraForward = new Vector3(cameraPivotTransform.forward.normalized.x, 0, cameraPivotTransform.forward.normalized.z);
    }

    void FixedUpdate()
    {
        // Movement
        Vector3 movement = cameraForward.normalized * forwardMovement;
        Vector3 force = movement * speed;

        // if we are reversing then apply less force
        if (forwardMovement < 0) 
        {
            playerRigid.AddForce(force * 0.95f);
        }
        else if (forwardMovement > 0)
        {
            playerRigid.AddForce(force);
        }

        // Rotate forward direction
        Vector3 newForwardDirection = new Vector3(movement.normalized.x, 0, movement.normalized.z);

        // If we are moving backwards then have the car's direction in the opposite of the force
        if (forwardMovement < 0) 
        {
            transform.forward = Vector3.Slerp(transform.forward, -newForwardDirection, Time.deltaTime * playerRigid.velocity.magnitude);
        }
        else if (forwardMovement > 0)
        {
            transform.forward = Vector3.Slerp(transform.forward, newForwardDirection, Time.deltaTime * playerRigid.velocity.magnitude);
        }
    }
}
