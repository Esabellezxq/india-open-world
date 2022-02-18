using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementMode { Walking, Running, Crouching, Proning, Swimming, Sprinting }

public class CharacterMovement : MonoBehaviour
{
  private Vector3 velocity;
  public Vector3 Velocity
  {
    get => velocity;
    set => velocity = value;
  }

  private Vector3 ridgidVelocity;
  public Vector3 RidgidVelocity
  {
    get => characterRidgidBody.velocity;
  }
  private float smoothSpeed = 0;

  private float maxSpeed = 5;
  public Transform characterMesh;
  private Rigidbody characterRidgidBody;

  private MovementMode movementMode = MovementMode.Walking;

  public Dictionary<MovementMode, float> stateSpeedMap = new Dictionary<MovementMode, float>()
  {
      {MovementMode.Walking, 5},
      {MovementMode.Running, 10},
      {MovementMode.Crouching, 4},
      {MovementMode.Proning, 2},
      {MovementMode.Swimming, 8},
      {MovementMode.Sprinting ,15},
  };

  void Start()
  {
    characterRidgidBody = GetComponent<Rigidbody>();

  }

  // Update is called once per frame
  void Update()
  {
    // transform.position += Velocity;
    if (Velocity.magnitude > 0)
    {
      var v = Velocity.normalized;
      characterRidgidBody.velocity = new Vector3(v.x * smoothSpeed, v.y, v.z * smoothSpeed);
      Debug.Log("Velocity.magnitude > 0");

      smoothSpeed = Mathf.Lerp(smoothSpeed, maxSpeed, Time.deltaTime * 5);
      characterMesh.rotation = Quaternion.Lerp(characterMesh.rotation, Quaternion.LookRotation(velocity), Time.deltaTime * 10);
      // 另一种旋转方式
      // if (x != 0 || z != 0)
      // {
      //   var newRotate = cameraController.transform.rotation;
      //   newRotate.x = michelle.transform.rotation.x;
      //   newRotate.z = michelle.transform.rotation.z;
      // }
    }
    else
    {
      smoothSpeed = Mathf.Lerp(smoothSpeed, 0, Time.deltaTime);
      if (smoothSpeed < 0.1)
      {
        smoothSpeed = 0;
      }
    }
  }

  public void SetMovementMode(MovementMode m)
  {
    movementMode = m;
    var isSuccess = stateSpeedMap.TryGetValue(movementMode, out maxSpeed);
    Debug.Log("set MovementMode state" + isSuccess);
  }

  public MovementMode GetMovementMode()
  {
    return movementMode;
  }

  public void ToggleRunning()
  {
    if (GetMovementMode() == MovementMode.Running)
    {
      SetMovementMode(MovementMode.Walking);
    }
    else
    {
      SetMovementMode(MovementMode.Running);
    }
  }

  public void ToggleCrouching()
  {
    if (GetMovementMode() == MovementMode.Crouching)
    {
      SetMovementMode(MovementMode.Walking);
    }
    else
    {
      SetMovementMode(MovementMode.Crouching);
    }
  }
}
