using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level1");
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        PlayerPrefs.DeleteKey("PlayerPosX" + SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.DeleteKey("PlayerPosY" + SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.DeleteKey("PlayerPosZ" + SceneManager.GetActiveScene().buildIndex);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && SceneManager.GetActiveScene().name != "Museum")
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetFloat("PlayerPosX", player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", player.transform.position.y);
            PlayerPrefs.SetFloat("PlayerPosZ", player.transform.position.z);
            PlayerPrefs.SetString("SceneSave", currentSceneName);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene("StartMenu");
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
}
