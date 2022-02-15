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

  private float speed = 10;

  private float maxSpeed = 5;
  public Transform characterMesh;
  private Rigidbody characterRidgidBody;

  public MovementMode movementMode;

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
    var v = Velocity.normalized;
    characterRidgidBody.velocity = new Vector3(v.x * speed, v.y, v.z * speed);
    if (Velocity.magnitude > 0)
    {
      characterMesh.rotation = Quaternion.LookRotation(velocity);

      // 另一种旋转方式
      // if (x != 0 || z != 0)
      // {
      //   var newRotate = cameraController.transform.rotation;
      //   newRotate.x = michelle.transform.rotation.x;
      //   newRotate.z = michelle.transform.rotation.z;
      // }
    }
  }

  public void setMovementMode(MovementMode movementMode)
  {
    var isSuccess = stateSpeedMap.TryGetValue(movementMode, out maxSpeed);
  }

  public MovementMode getMovementMode()
  {
    return movementMode;
  }

}
