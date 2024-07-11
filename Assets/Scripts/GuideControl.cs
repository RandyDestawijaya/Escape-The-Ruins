using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideControl : MonoBehaviour
{
    public GameObject MainCam;
    public GameObject GuideCam;
    public GameObject GuidePanel;
    public string GuideName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PlayerPrefs.HasKey("Guide" + GuideName))
        {
            PlayerPrefs.SetInt("Guide" +  GuideName, 0);
            GuidePanel.SetActive(true);
            Time.timeScale = 0f;
        }   
    }
    public void ContinueGuide()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        GuideCam.SetActive(true);
        MainCam.SetActive(false);
        StartCoroutine(FinishGuide());
    }

    IEnumerator FinishGuide()
    {
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1f;
        MainCam.SetActive(true);
        GuideCam?.SetActive(false);
    }
}
