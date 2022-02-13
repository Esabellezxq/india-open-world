using UnityEngine;

public class CameraController : MonoBehaviour
{
  private Vector3 camEuler;
  private float cameraSmoothFactor = 1;

  private float lookUpMax = 45;
  private float lookUpMin = -45;

  void Start()
  {
    camEuler = transform.rotation.eulerAngles;
    Cursor.lockState = CursorLockMode.Locked;
  }

  void Update()
  {
    camEuler.x += -Input.GetAxis("Mouse Y") * cameraSmoothFactor;
    camEuler.x = Mathf.Clamp(camEuler.x, lookUpMin, lookUpMax);
    camEuler.y += Input.GetAxis("Mouse X") * cameraSmoothFactor;
    transform.rotation = Quaternion.Euler(camEuler);
  }
}
