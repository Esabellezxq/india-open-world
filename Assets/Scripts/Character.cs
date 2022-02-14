using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
  private float forwardInput;
  private float rightInput;

  private Vector3 velocity;

  public Camera cam;

  public CameraController cameraController;

  public GameObject michelle;
  void Start()
  {

  }

  void Update()
  {
    transform.position += velocity;

  }

  public void moveInputHandler(float x, float z)
  {
    // Debug.Log("x:" + x + "z:" + z);
    rightInput = x;
    forwardInput = z;

    // 我的方法
    // var charcartForward = (transform.position - cam.transform.position).normalized;
    // var forwardDis = charcartForward * forwardInput;
    // var rightDis = Vector3.Cross(Vector3.up, charcartForward) * rightInput;
    // var direction = forwardDis + rightDis;
    // direction = Vector3.ProjectOnPlane(direction, Vector3.up).normalized;
    // transform.position += direction;


    // 印度老鼠的方法好像更简单
    var forwardDis = forwardInput * cameraController.transform.forward;
    var rightDis = rightInput * cameraController.transform.right;
    var direction = Vector3.ProjectOnPlane(forwardDis + rightDis, Vector3.up).normalized;
    if (direction.magnitude > 0)
    {
      velocity = direction;
    }
    else
    {
      velocity = Vector3.zero;
    }
    if (x != 0 || z != 0)
    {
      var newRotate = cameraController.transform.rotation;
      newRotate.x = michelle.transform.rotation.x;
      newRotate.z = michelle.transform.rotation.z;
      michelle.transform.rotation = newRotate;
    }

  }

  public float getVelocity()
  {
    Debug.Log("velocity:" + velocity.magnitude);
    return velocity.magnitude;
  }
}
