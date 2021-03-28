using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform cameraPivotTransform;
    public float speed = 5;

    private Rigidbody ballRigid;

    // Start is called before the first frame update
    void Start()
    {
        ballRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal == 0 && moveVertical == 0) {
            ballRigid.velocity = Vector3.zero;
        } else {
            // Movement
            Vector3 forwardMovement = cameraPivotTransform.forward.normalized * moveVertical;
            Vector3 sidewaysMovement = cameraPivotTransform.right.normalized * moveHorizontal;
            Vector3 movement = forwardMovement + sidewaysMovement;
            ballRigid.AddForce(movement * speed);

            // Rotate forward direction
            Vector3 newForwardDirection = new Vector3(movement.normalized.x, 0, movement.normalized.z);
            transform.forward = newForwardDirection;
        }
    }
}
