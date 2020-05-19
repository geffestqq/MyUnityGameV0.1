using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
 public Slider slider;
 public Text valueCount;
 public float volumeMusic;
 


 void Start () { 
 
     AudioListener.volume = PlayerPrefs.GetFloat("Volume");
	 slider.value = PlayerPrefs.GetFloat("Volume");
}
 void Update () {

  valueCount.text = slider.value.ToString ();
  AudioListener.volume = slider.value;
  
  PlayerPrefs.SetFloat("Volume",AudioListener.volume);

 }
}