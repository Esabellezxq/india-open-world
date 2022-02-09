using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Character))]
public class PlayerInput : MonoBehaviour
{
  private Character character;
  // Start is called before the first frame update
  void Start()
  {
    character = GetComponent<Character>();
  }

  // Update is called once per frame
  void Update()
  {
    character.moveInputHandler(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
  }
}
