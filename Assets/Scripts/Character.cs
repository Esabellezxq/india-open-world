using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

  private Vector3 velocity;

  public CameraController cameraController;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    transform.Translate(velocity);
  }

  public void moveInputHandler(float x, float z)
  {
    Debug.Log("x:" + x + "z:" + z);


    // Vector3 cameraTrans = x * cameraController.transform.right + z * cameraController.transform.forward;

    // if (velocity.magnitude > 0)
    // {
    //   velocity = (cameraTrans - transform.position).normalized;

    // }
    // else
    // {
    //   velocity = Vector3.zero;
    // }

    transform.Rotate(new Vector3(cameraController.transform.localRotation.x, cameraController.transform.localRotation.y, cameraController.transform.localRotation.z));
    
  }
}
