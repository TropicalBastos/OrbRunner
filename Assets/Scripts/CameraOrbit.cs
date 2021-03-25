using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    protected Transform cameraTransform;
    protected Transform pivotTransform;
    protected Vector3 localRotation;
    protected float cameraDistance = 10f;

    public Transform playerTransform; 
    public float mouseSensitivity = 4f;
    public float scrollSensitivity = 2f;
    public float orbitDampening = 10f;
    public float scrollDampening = 6f;
    public bool isCameraEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = this.transform;
        pivotTransform = this.transform.parent;
        AlignPivotWithPlayer();
        // pivotTransform.rotation = pivotTransform.rotation * Quaternion.Euler(0, 25, 0);
        localRotation = pivotTransform.rotation.eulerAngles;
    }

    // LateUpdate is called once per frame, after Update() on every game object in the scene
    void LateUpdate()
    {
        AlignPivotWithPlayer();

        if (isCameraEnabled)
        {
            // Rotation of camera based on mouse coordinates
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                localRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                localRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;

                // Clamp y rotation to horizon and not flipping over the top              
                localRotation.y = Mathf.Clamp(localRotation.y, 0, 90);
            }

            // Scrolling input from mouse scroll
            if (Input.GetAxis("Mouse ScrollWheel") != 0f) 
            {
                float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;

                // Makes camera zoom faster the further out it is
                scrollAmount *= (cameraDistance * 0.3f);

                cameraDistance += scrollAmount;
                cameraDistance = Mathf.Clamp(cameraDistance, 1.5f, 100f);
            }
        }

        // Actual camera rig transformations
        Quaternion qt = Quaternion.Euler(localRotation.y, localRotation.x, 0);
        pivotTransform.rotation = Quaternion.Lerp(pivotTransform.rotation, qt, Time.deltaTime * orbitDampening);

        if (cameraTransform.localPosition.z != cameraDistance * -1f)
        {
            cameraTransform.localPosition = new Vector3(0f, 0f, Mathf.Lerp(cameraTransform.localPosition.z, cameraDistance * -1f, Time.deltaTime * scrollDampening));
        }
    }

    // Have the camera pivot point centered on the player
    void AlignPivotWithPlayer()
    {
        if (playerTransform)
        {
            pivotTransform.position = playerTransform.position;
        }
    }
}
