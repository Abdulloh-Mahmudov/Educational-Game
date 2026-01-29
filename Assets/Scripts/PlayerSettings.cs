using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField] Toggle _soundToggle;
    [SerializeField] GameObject _sound;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("firstrun"))
        {
            PlayerPrefs.SetInt("firstrun", 1);
            Debug.Log("First run");
        }
        else
        {
            Debug.Log("Run already performed before");
        }

        SoundSettings();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayerProfile(string profile)
    {
        PlayerPrefs.SetString("CurrentProfile", profile);

        if (!PlayerPrefs.HasKey(profile + "_MathScore"))
            PlayerPrefs.SetInt(profile + "_MathScore", 0);
        if (!PlayerPrefs.HasKey(profile + "_PuzzleScore"))
            PlayerPrefs.SetInt(profile + "_PuzzleScore", 0);
        if (!PlayerPrefs.HasKey(profile + "_TileScore"))
            PlayerPrefs.SetInt(profile + "_TileScore", 0);

        PlayerPrefs.Save();
    }

    public void DeleteProfile(string profile)
    {

        if (PlayerPrefs.HasKey(profile + "_MathScore"))
            PlayerPrefs.DeleteKey(profile + "_MathScore");
        if (PlayerPrefs.HasKey(profile + "_PuzzleScore"))
            PlayerPrefs.DeleteKey(profile + "_PuzzleScore");
        if (PlayerPrefs.HasKey(profile + "_TileScore"))
            PlayerPrefs.DeleteKey(profile + "_TileScore");

        if (!PlayerPrefs.HasKey("SoundOn"))
            PlayerPrefs.SetInt("SoundOn", 1);


        PlayerPrefs.Save();

        Debug.Log(profile + " has been deleted");
    }

    public void SoundToggle()
    {
        bool soundOn = _soundToggle.isOn;

        if(soundOn == true)
        {
            PlayerPrefs.SetInt("SoundOn", 1);
        }
        else
        {
            PlayerPrefs.SetInt("SoundOn", 0);
        }
        PlayerPrefs.Save();
        _sound.SetActive(soundOn);
    }

    public void SoundSettings()
    {
        if(PlayerPrefs.GetInt("SoundOn") == 1)
        {
            _soundToggle.isOn = true;
        }
        else
        {
            _soundToggle.isOn = false;
        }
        SoundToggle();
    }
}
