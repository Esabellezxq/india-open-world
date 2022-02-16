using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class CharacterAnimation : MonoBehaviour
{
  private CharacterMovement characterMovement;
  public Animator animator;
  // Start is called before the first frame update
  void Start()
  {
    characterMovement = GetComponent<CharacterMovement>();
  }

  // Update is called once per frame
  void Update()
  {
    if (animator == null)
    {
      Debug.Log("Animation not valid");
      return;
    }

    var length = characterMovement.RidgidVelocity.magnitude;
    var readableLength = (int)length;
    // Debug.Log(readableLength);
    animator.SetFloat("velocity", length);
  }
}
