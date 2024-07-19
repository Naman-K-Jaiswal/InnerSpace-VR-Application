using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicBoxAudioSource : MonoBehaviour
{
    // public int currPlaying = 0;
    public Slider volumeSlider;
    public GameObject dropdownGameObject;
    private TMP_Dropdown myDropdown;
    public AudioSource AudioSourceOverwhelmed;
    public AudioSource AudioSourceRestless;
    public AudioSource AudioSourceTensed;

    void Start()
    {
        myDropdown = dropdownGameObject.GetComponent<TMP_Dropdown>();

        if (myDropdown == null)
        {
            Debug.LogError("No Dropdown component found on the provided GameObject.");
            return;
        }

        volumeSlider.onValueChanged.AddListener(HandleSliderValueChanged);
        HandleSliderValueChanged(volumeSlider.value);
    }

    public void HandleSliderValueChanged(float value)
    {
        // Set the volume for each AudioSource based on the slider value
        AudioSourceOverwhelmed.volume = value;
        AudioSourceRestless.volume = value;
        AudioSourceTensed.volume = value;
    }

    // Update is called once per frame
    public void HandleDropdown()
    {
        AudioSourceOverwhelmed.Pause();
        AudioSourceRestless.Pause();
        AudioSourceTensed.Pause();
        int selectedIndex = myDropdown.value;
        if (selectedIndex == 0)
        {
            AudioSourceOverwhelmed.Play();
            Debug.Log("HI");
        }
        if (selectedIndex == 1)
        {
            AudioSourceRestless.Play();
        }
        if (selectedIndex == 2)
        {
            AudioSourceTensed.Play();
        }
    }

    public void HandleButtonClick()
    {
        int selectedIndex = myDropdown.value;
        bool IsPlaying = AudioSourceOverwhelmed.isPlaying | AudioSourceRestless.isPlaying | AudioSourceTensed.isPlaying;
        if (IsPlaying == false)
        {
            if (selectedIndex == 0)
            {
                AudioSourceOverwhelmed.Play();
                Debug.Log("HI");
            }
            if (selectedIndex == 1)
            {
                AudioSourceRestless.Play();
            }
            if (selectedIndex == 2)
            {
                AudioSourceTensed.Play();
            }
        }

        else
        {
            AudioSourceOverwhelmed.Pause();
            AudioSourceRestless.Pause();
            AudioSourceTensed.Pause();
        }
    }
}
