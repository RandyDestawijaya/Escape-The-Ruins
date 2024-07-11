using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingMenu : MonoBehaviour
{
    public TMP_Dropdown graphicsDropdown;
    public Slider volume, musicVol, sfxVol;
    public AudioMixer AudioMixer;
    public Toggle toggleFullscreen;
    public GameObject setting;
    private PlayerController playerController;

    private void Start()
    {
        LoadSettings();
        toggleFullscreen.onValueChanged.AddListener(SetFullscreen);
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName != "MainMenu")
        {
            GameObject player = GameObject.Find("Player");
            playerController = player.GetComponent<PlayerController>();
        }
    }
    private void Update()
    {
        if (setting.activeInHierarchy && playerController != null)
        {
            playerController.enabled = false;
        }
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
    }

    public void ChangeGraphicsQuality()
    {
        int qualityLevel = graphicsDropdown.value;
        QualitySettings.SetQualityLevel(qualityLevel);
        PlayerPrefs.SetInt("GraphicsQuality", qualityLevel);
    }

    public void VolumeChange()
    {
        float volumeValue = volume.value;
        AudioMixer.SetFloat("MasterVol", volumeValue);
        PlayerPrefs.SetFloat("MasterVolume", volumeValue);
    }

    public void MusicVolChange()
    {
        float musicVolumeValue = musicVol.value;
        AudioMixer.SetFloat("MusicVol", musicVolumeValue);
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeValue);
    }

    public void SfxVolChange()
    {
        float sfxVolumeValue = sfxVol.value;
        AudioMixer.SetFloat("SfxVol", sfxVolumeValue);
        PlayerPrefs.SetFloat("SfxVolume", sfxVolumeValue);
    }

    private void LoadSettings()
    {
        if (PlayerPrefs.HasKey("Fullscreen"))
        {
            bool isFullscreen = PlayerPrefs.GetInt("Fullscreen") == 1;
            Screen.fullScreen = isFullscreen;
            toggleFullscreen.isOn = isFullscreen;
        }
        else
        {
            toggleFullscreen.isOn = Screen.fullScreen;
        }

        if (PlayerPrefs.HasKey("GraphicsQuality"))
        {
            int qualityLevel = PlayerPrefs.GetInt("GraphicsQuality");
            QualitySettings.SetQualityLevel(qualityLevel);
            graphicsDropdown.value = qualityLevel;
        }
        else
        {
            graphicsDropdown.value = QualitySettings.GetQualityLevel();
        }

        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            float volumeValue = PlayerPrefs.GetFloat("MasterVolume");
            volume.value = volumeValue;
            AudioMixer.SetFloat("MasterVol", volumeValue);
        }
        else
        {
            float volumeValue;
            AudioMixer.GetFloat("MasterVol", out volumeValue);
            volume.value = volumeValue;
        }

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float musicVolumeValue = PlayerPrefs.GetFloat("MusicVolume");
            musicVol.value = musicVolumeValue;
            AudioMixer.SetFloat("MusicVol", musicVolumeValue);
        }
        else
        {
            float musicVolumeValue;
            AudioMixer.GetFloat("MusicVol", out musicVolumeValue);
            musicVol.value = musicVolumeValue;
        }

        if (PlayerPrefs.HasKey("SfxVolume"))
        {
            float sfxVolumeValue = PlayerPrefs.GetFloat("SfxVolume");
            sfxVol.value = sfxVolumeValue;
            AudioMixer.SetFloat("SfxVol", sfxVolumeValue);
        }
        else
        {
            float sfxVolumeValue;
            AudioMixer.GetFloat("SfxVol", out sfxVolumeValue);
            sfxVol.value = sfxVolumeValue;
        }
    }

    public void BackFromSetting()
    {
        playerController.enabled = true;
        Time.timeScale = 1f;
    }
}
