using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Character))]
[RequireComponent(typeof(CharacterMovement))]
public class PlayerInput : MonoBehaviour
{
  private Character character;
  private CharacterMovement characterMovement;
  void Start()
  {
    character = GetComponent<Character>();
    characterMovement = GetComponent<CharacterMovement>();
  }

  void Update()
  {
    character.MoveInputHandler(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    if (Input.GetKeyDown(KeyCode.LeftShift))
    {
      Debug.Log("shift press");
      characterMovement.SwitchWalkingAndRunning();
    }
  }
}
