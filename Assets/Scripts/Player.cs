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
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = new Vector3(cameraPivotTransform.forward.normalized.x, 0, cameraPivotTransform.forward.normalized.z);

        if (moveHorizontal == 0 && moveVertical == 0) 
        {
            playerRigid.velocity = Vector3.zero;
        } 
        else 
        {
            // Movement
            Vector3 forwardMovement = cameraForward.normalized * moveVertical;
            Vector3 sidewaysMovement = cameraForward.normalized * moveHorizontal;
            Vector3 movement = forwardMovement + sidewaysMovement;
            Vector3 force = movement * speed;
            playerRigid.AddForce(force);

            // Rotate forward direction
            Vector3 newForwardDirection = new Vector3(movement.normalized.x, 0, movement.normalized.z);

            if (moveVertical < 0 && Mathf.Abs(moveVertical) > moveHorizontal) 
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
