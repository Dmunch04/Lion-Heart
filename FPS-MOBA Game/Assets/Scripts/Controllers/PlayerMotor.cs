using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    private bool inField = false;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move (Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void CameraRotate(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    void FixedUpdate()
    {
        Movement();
        Rotation();
    }

    //Do the movement
    void Movement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(transform.position + velocity * Time.deltaTime);
        }
    }

    //Do the rotation & camera rotation
    void Rotation()
    {
        rb.MoveRotation(transform.rotation * Quaternion.Euler(rotation));

        //Checks if there is a camera and applies the rotation. The minus is important because else it will rotate the other direction!
        if (cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }

    void OnTriggerEnter(Collider field)
    {
        if (field.tag == "CaptureField")
        {
            inField = true;
            Debug.Log("You entered it!");
        }
    }

    void OnTriggerExit(Collider field)
    {
        if (field.tag == "CaptureField")
        {
            inField = false;
            Debug.Log("You left it!");
        }
    }

}
