using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Audiocontrol : MonoBehaviour
{
    public Slider volumeSlider;
    public GameObject bgmusic;
    private float mvolume = 1;
    private AudioSource audiosource;

    private void Start()
    {
        bgmusic = GameObject.FindWithTag("BGMusic");
        audiosource = bgmusic.GetComponent<AudioSource>();
        mvolume = PlayerPrefs.GetFloat("volume");
        audiosource.volume = mvolume;
        volumeSlider.value = mvolume;
    }
    private void Update()
    {
            audiosource.volume = mvolume;
        PlayerPrefs.SetFloat("volume", mvolume);
    }
    public void VolumeUpdater(float volume)
    {
        mvolume = volume;
    }
    public void MusicReset()
    {
        PlayerPrefs.DeleteKey("volume");
        audiosource.volume = 1;
        volumeSlider.value = 1;
    }
}
