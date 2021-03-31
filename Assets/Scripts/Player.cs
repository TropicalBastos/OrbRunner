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
    
    // wheels
    private Transform[] wheels;

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();

        wheels = new Transform[4];
        wheels[0] = transform.GetChild(1);
        wheels[1] = transform.GetChild(2);
        wheels[2] = transform.GetChild(4);
        wheels[3] = transform.GetChild(5);
    }

    // Update is called once per frame
    private void Update() 
    {
        forwardMovement = Input.GetAxis("Vertical");
        cameraForward = new Vector3(cameraPivotTransform.forward.normalized.x, 0, cameraPivotTransform.forward.normalized.z);

        foreach (Transform wheel in wheels)
        {
            wheel.rotation *= Quaternion.Euler(playerRigid.velocity.magnitude, 0, 0);
        }
    }

    void FixedUpdate()
    {
        // Movement
        Vector3 movement = cameraForward.normalized * forwardMovement;
        Vector3 newForwardDirection = new Vector3(movement.normalized.x, 0, movement.normalized.z);
        Vector3 force = newForwardDirection * speed;

        // if we are reversing then apply less force
        if (forwardMovement < 0) 
        {
            playerRigid.AddForce(force * 0.95f);
        }
        else if (forwardMovement > 0)
        {
            playerRigid.AddForce(force);
        }

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
