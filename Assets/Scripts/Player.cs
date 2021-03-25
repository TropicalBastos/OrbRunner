using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform cameraTransform;

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
            ballRigid.Sleep();
        }

        Vector3 forwardMovement = cameraTransform.forward.normalized * moveVertical;
        Vector3 sidewaysMovement = cameraTransform.right.normalized * moveHorizontal;
        Vector3 movement = forwardMovement + sidewaysMovement;
        Vector3 rotationVector = Vector3.RotateTowards(transform.forward, -cameraTransform.forward, speed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(rotationVector);

        ballRigid.AddForce(movement * speed);
    }
}
