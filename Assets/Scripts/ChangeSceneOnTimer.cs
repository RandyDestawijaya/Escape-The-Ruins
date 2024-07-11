using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeSceneOnTimer : MonoBehaviour
{
    public float ChangeTime;
    public string SceneName;

    // Update is called once per frame
    private void Update()
    {
        ChangeTime -= Time.deltaTime;
        if (ChangeTime <= 0)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneName);
        }
       
    }
}
