using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Character))]
[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(CharacterAnimation))]
public class PlayerInput : MonoBehaviour
{
  private Character character;
  private CharacterMovement characterMovement;

  private CharacterAnimation CharacterAnimation;
  void Start()
  {
    character = GetComponent<Character>();
    characterMovement = GetComponent<CharacterMovement>();
    CharacterAnimation = GetComponent<CharacterAnimation>();
  }

  void Update()
  {
    character.MoveInputHandler(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    if (Input.GetKeyDown(KeyCode.LeftShift))
    {
      Debug.Log("shift pressed");
      characterMovement.ToggleRunning();
      CharacterAnimation.SetAnimatorMoveMode();
    }

    if (Input.GetKeyDown(KeyCode.C))
    {
      Debug.Log("c pressed");
      characterMovement.ToggleCrouching();
      CharacterAnimation.SetAnimatorMoveMode();
    }
  }
}
