using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform cameraPivotTransform;
    public float speed = 5;
    private Rigidbody playerRigid;

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = new Vector3(cameraPivotTransform.forward.normalized.x, 0, cameraPivotTransform.forward.normalized.z);

        if (moveVertical == 0) 
        {
            playerRigid.velocity = Vector3.zero;
        } 
        else 
        {
            // Movement
            Vector3 movement = cameraForward.normalized * moveVertical;
            Vector3 force = movement * speed;
            playerRigid.AddForce(force);

            // Rotate forward direction
            Vector3 newForwardDirection = new Vector3(movement.normalized.x, 0, movement.normalized.z);

            // If we are moving backwards then have the car's direction in the opposite of the force
            if (moveVertical < 0) 
            {
                transform.forward = Vector3.Lerp(transform.forward, -newForwardDirection, Time.deltaTime * speed);
            }
            else
            {
                transform.forward = Vector3.Lerp(transform.forward, newForwardDirection, Time.deltaTime * speed);
            }
        }

        // transform.forward = Vector3.Lerp(transform.forward, cameraForward, Time.deltaTime);
    }
}
