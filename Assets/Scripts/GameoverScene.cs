using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameoverScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void retry()
    {
        SceneManager.LoadScene("Level1");
    }

    public void quit()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
