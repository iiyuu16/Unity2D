using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static AudioClip hit, death, attack;
    static AudioSource audioSrc;
    [SerializeField] Slider volSlider;
    // Start is called before the first frame update
    void Start()
    {
        hit = Resources.Load<AudioClip>("Hit");
        death = Resources.Load<AudioClip>("Death");
        attack = Resources.Load<AudioClip>("Attack");

        audioSrc = GetComponent<AudioSource>();

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

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Hit":
                audioSrc.PlayOneShot(hit);
                break;
            case "Death":
                audioSrc.PlayOneShot(death);
                break;
            case "Attack":
                audioSrc.PlayOneShot(attack);
                break;
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