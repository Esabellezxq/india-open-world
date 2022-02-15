using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class CharacterAnimation : MonoBehaviour
{
  private CharacterMovement character;
  public Animator animator;
  // Start is called before the first frame update
  void Start()
  {
    character = GetComponent<CharacterMovement>();
  }

  // Update is called once per frame
  void Update()
  {
    if (animator == null)
    {
      Debug.Log("Animation not valid");
      return;
    }

    animator.SetFloat("velocity", character.Velocity.magnitude);
    Debug.Log(character.Velocity.magnitude);
  }
}
