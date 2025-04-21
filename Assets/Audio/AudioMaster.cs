using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMaster : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioSource sfx;

    private void Start()
    {
    
        if (PlayerPrefs.HasKey("vol"))
        {
            float vol = PlayerPrefs.GetFloat("vol");
            volSlider.value = vol;
            audioMixer.SetFloat("vol", Mathf.Log10(vol) * 20);
        }
        else
        {
            volSlider.value = 1f;
            PlayerPrefs.SetFloat("vol", 1f);
        }

        if (PlayerPrefs.HasKey("sfx"))
        {
            float sfxVol = PlayerPrefs.GetFloat("sfx");
            sfxSlider.value = sfxVol;
            audioMixer.SetFloat("sfx", Mathf.Log10(sfxVol) * 20);
        }
        else
        {
            sfxSlider.value = 1f;
            PlayerPrefs.SetFloat("sfx", 1f);
        }
    }

   
    public void SetVolume()
    {
        float value = volSlider.value;
        audioMixer.SetFloat("vol", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("vol", value); 
    }

    
    public void SetSFX()
    {
        float value = sfxSlider.value;
        audioMixer.SetFloat("sfx", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("sfx", value); 
        sfx.Play();
    }
}
