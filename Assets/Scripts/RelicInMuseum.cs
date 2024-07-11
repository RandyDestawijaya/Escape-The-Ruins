using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicInMuseum : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    void Start()
    {
        // Loop melalui objek yang ingin diaktifkan
        for (int i = 0; i < objectsToActivate.Length; i++)
        {
            // Periksa apakah ada PlayerPrefs untuk objek ini
            if (PlayerPrefs.HasKey("RelicIndex" + i))
            {
                // Dapatkan nilai PlayerPrefs untuk objek ini
                int activatedObjectIndex = PlayerPrefs.GetInt("RelicIndex" + i);
                // Pastikan indeks berada dalam rentang array
                if (activatedObjectIndex >= 0 && activatedObjectIndex < objectsToActivate.Length)
                {
                    // Aktifkan objek dengan indeks yang sesuai
                    objectsToActivate[activatedObjectIndex].SetActive(true);
                }
            }
        }
    }
}
