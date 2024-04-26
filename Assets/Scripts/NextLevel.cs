using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject text;
    private bool interaction = false;
    private void Start()
    {
        LoadPlayerPosition();
    }
    void Update()
    {
        if (interaction && Input.GetKeyDown(KeyCode.E))
        {
            SavePlayerPosition();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.SetActive(true);
            interaction = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.SetActive(false);
            interaction = false;
        }
    }
    private void SavePlayerPosition()
    {
        PlayerPrefs.SetFloat("PlayerPosX" + SceneManager.GetActiveScene().buildIndex, player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY" + SceneManager.GetActiveScene().buildIndex, player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ" + SceneManager.GetActiveScene().buildIndex, player.transform.position.z);
    }
    private void LoadPlayerPosition()
    {
        if (PlayerPrefs.HasKey("PlayerPosX" + SceneManager.GetActiveScene().buildIndex))
        {
            float playerPosX = PlayerPrefs.GetFloat("PlayerPosX" + SceneManager.GetActiveScene().buildIndex);
            float playerPosY = PlayerPrefs.GetFloat("PlayerPosY" + SceneManager.GetActiveScene().buildIndex);
            float playerPosZ = PlayerPrefs.GetFloat("PlayerPosZ" + SceneManager.GetActiveScene().buildIndex);
            player.transform.position = new Vector3(playerPosX, playerPosY, playerPosZ);
        }
        else if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("SceneSave"))
        {
            string savedSceneName = PlayerPrefs.GetString("SceneSave");
            if (savedSceneName == SceneManager.GetActiveScene().name)
            {
                float playerPosX = PlayerPrefs.GetFloat("PlayerPosX");
                float playerPosY = PlayerPrefs.GetFloat("PlayerPosY");
                float playerPosZ = PlayerPrefs.GetFloat("PlayerPosZ");
                player.transform.position = new Vector3(playerPosX, playerPosY, playerPosZ);
            }
        }
    }
}
