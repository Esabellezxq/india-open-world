using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterAC : MonoBehaviour
{
  private Character character;
  public Animator animator;
  // Start is called before the first frame update
  void Start()
  {
    character = GetComponent<Character>();
  }

  // Update is called once per frame
  void Update()
  {
    if (animator == null)
    {
      Debug.Log("Animation not valid");
      return;
    }

    animator.SetFloat("velocity", character.getVelocity());
  }
}
