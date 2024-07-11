using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameoverScene : MonoBehaviour
{
    public void retry()
    {
        SceneManager.LoadScene("Level1");
    }

    public void quit()
    {
        PlayerPrefs.SetString("SceneSave", "Level1");
        SceneManager.LoadScene("MainMenu");
    }
}
