using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private void Start()
    {
        
        GameObject ContinueButton = GameObject.Find("ContinueButton");
        if (ContinueButton != null)
        {
            Button conButton = ContinueButton.GetComponent<Button>();
            if (PlayerPrefs.HasKey("SceneSave"))
            {
                if(PlayerPrefs.GetString("SceneSave") == "Level1")
                {
                    conButton.interactable = true;
                } 
            }
        }
    }
    public void StartGame()
    {
        for (int i = 0; i < 4; i++)
        {
            PlayerPrefs.DeleteKey("RelicIndex" + i);
        }
        PlayerPrefs.DeleteKey("PlayerPosX");
        PlayerPrefs.DeleteKey("PlayerPosY");
        PlayerPrefs.DeleteKey("PlayerPosZ");
        PlayerPrefs.DeleteKey("SceneSave");
        PlayerPrefs.DeleteKey("Guidecheckpoint");
        PlayerPrefs.DeleteKey("Guidechest");
        PlayerPrefs.SetInt("DialogTutorial", 0);
        PlayerPrefs.SetInt("DialogLevel1", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Cutscene");
    }

    public void MainMenu()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "Level1")
        {
            PlayerPrefs.SetString("SceneSave", currentSceneName);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void ContinueGame()
    {
        if (PlayerPrefs.HasKey("SceneSave"))
        {
            string loadScene = PlayerPrefs.GetString("SceneSave");
            SceneManager.LoadScene(loadScene);
        }
    }
    public void Museum()
    {
        SceneManager.LoadScene("Museum");
    }

    public void Quit()
    {
        Application.Quit(); 
    }
}
