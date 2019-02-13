using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    //Movement speed
    [SerializeField]
    private float speed = 5f;

    //Mouse sensitivity
    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        // Checks if the pause menu is on. Returns if it's on
        if (PauseMenu.IsOn || LegendSelection.IsOn)
        {
            // Make the cursor unlocked, so now it can move anywhere
            if (Cursor.lockState != CursorLockMode.None)
                Cursor.lockState = CursorLockMode.None;

            // Locks all movement and rotation
            motor.Move(Vector3.zero);
            motor.Rotate(Vector3.zero);
            motor.CameraRotate(Vector3.zero);

            return;
        }

        // Locking the cursor
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        //Movement
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;

        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

        //Applying the movement, to the PlayerMotor script
        motor.Move(velocity);


        //Rotation
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;

        //Applying the rotation, to the PlayerMotor script
        motor.Rotate(rotation);

        //Camera rotation
        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * lookSensitivity;

        //Applying the camera rotation, to the PlayerMotor script
        motor.CameraRotate(cameraRotation);
    }

}
