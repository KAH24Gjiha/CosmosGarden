using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicsource;
    public Slider musicSlider;

    private void Start()
    {
        musicsource = this.gameObject.GetComponent<AudioSource>();
    }
    public void SetMusicVolume(float volume)
    {
        musicsource.volume = volume * musicSlider.value;
    }

}
