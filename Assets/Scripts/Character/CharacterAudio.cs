using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
  public AudioSource audioSource;
  public AudioClip audioClip;
  void Start()
  {

  }

  public void PlayFootStepAudio()
  {
    Debug.Log("PlayFootStepAudio");
    audioSource.PlayOneShot(audioClip);
    audioSource.Play();
  }
}
