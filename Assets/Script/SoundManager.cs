using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
            Load();
        }
        else
        {
            Load();
        }

    }

    public void changeVolume()
    {
        AudioListener.volume = volSlider.value;
        Save();
    }

    public void Load()
    {
        volSlider.value = PlayerPrefs.GetFloat("volume");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("volume", volSlider.value);
    }

}