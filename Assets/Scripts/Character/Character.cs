using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterMovement))]
public class Character : MonoBehaviour
{
  private CharacterMovement characterMovement;

  public Camera cam;

  public CameraController cameraController;



  void Start()
  {
    characterMovement = GetComponent<CharacterMovement>();
  }

  void Update()
  {
  }

  public void MoveInputHandler(float rightInput, float forwardInput)
  {
    // Debug.Log("x:" + x + "z:" + z);

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
      characterMovement.Velocity = direction;
    }
    else
    {
      characterMovement.Velocity = Vector3.zero;
    }

  }
}
