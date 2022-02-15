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

  // Update is called once per frame
  void Update()
  {
    character.moveInputHandler(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    if (Input.GetKeyDown(KeyCode.CapsLock))
    {

    }
  }
}
