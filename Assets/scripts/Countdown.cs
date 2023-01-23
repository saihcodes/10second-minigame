using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Countdown : MonoBehaviour
{
 public GameObject winTextObject;
  public AudioClip WinClip;
  public GameObject survivetextObject;
 float currentTime = 0f;
 float startingTime = 12f;
 public AudioSource audioPlayer;
      AudioSource audioSource;


public TextMeshProUGUI countdownText;
 void Start()
 {
    currentTime = startingTime;
 


 }

 void Update()
 {
    currentTime -= 1 * Time.deltaTime;
    countdownText.text = currentTime.ToString("Timer:0");

    if (currentTime <= 0)
 {
      winTextObject.SetActive(true);
       audioSource.clip = WinClip;
       audioSource.Play();
      
 }

 {
   survivetextObject.SetActive(true);

   if (currentTime <= 10)
   {
      survivetextObject.SetActive(false);
   }
 }
}
}