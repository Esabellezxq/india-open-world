using UnityEngine;

public class CameraController : MonoBehaviour
{
  private Quaternion camRotation;
  private float cameraSmoothFactor = 1;

  private float lookUpMax = 45;
  private float lookUpMin = -45;
  
  // Start is called before the first frame update
  void Start()
  {
    camRotation = transform.localRotation;
  }

  // Update is called once per frame
  void Update()
  {
    camRotation.x += -Input.GetAxis("Mouse Y") * cameraSmoothFactor; // look up/down
    camRotation.x = Mathf.Clamp(camRotation.x, lookUpMin, lookUpMax);
    camRotation.y += Input.GetAxis("Mouse X") * cameraSmoothFactor;  // look left/right
    transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);
    // Debug.Log($"x: {camRotation.x}, y: {camRotation.y}");
  }
}
