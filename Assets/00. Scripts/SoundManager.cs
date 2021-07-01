using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public Slider audioSlider;
    public AudioMixer masterMixer;

    public void AudioControl()
    {
        float sound = audioSlider.value;
        if(sound == -40f) masterMixer.SetFloat("Master", -80);
        else masterMixer.SetFloat("Master", sound);
    }

}
