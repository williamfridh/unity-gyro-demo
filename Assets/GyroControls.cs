using UnityEngine;

public class GyroControls : MonoBehaviour
{
    
    // Define global variables.
    private bool gyroEnabled;
    private Gyroscope gyro;
    private GameObject cameraContainer;
    private Quaternion rot;

    // Start is called before the first frame update
    private void Start() {
        cameraContainer = new GameObject("Camera Container");       // Create a new game object called Camera Container
        cameraContainer.transform.position = transform.position;    // Set the position of the camera container to the position of the camera
        transform.SetParent(cameraContainer.transform);             // Set the camera as a child of the camera container

        gyroEnabled = EnableGyro();                                 // Enable the gyro
    }

    /**
     * Enable Gyro
     *
     * Function used for enabling gryo.
     * This also checks if the device supports gyro.
     *
     * @return bool
     */
    private bool EnableGyro() {
        if (SystemInfo.supportsGyroscope) {                                         // Check if device supports gyro
            gyro = Input.gyro;                                                      // Get the gyro
            gyro.enabled = true;                                                    // Enable the gyro

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);    // Set the rotation of the camera container
            rot = new Quaternion(0, 0, 1, 0);                                       // Set the rotation of the camera    

            return true;
        }
        return false;
    }

    // Update is called once per frame
    private void Update() {
        if (gyroEnabled) {                                      // Check if gyro is enabled
            transform.localRotation = gyro.attitude * rot;      // Set the rotation of the camera
        }
    }
}
