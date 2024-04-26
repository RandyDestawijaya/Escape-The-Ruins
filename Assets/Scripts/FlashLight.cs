using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashLight : MonoBehaviour
{
    public float startingBattery = 60f;
    private float currentBattery; // baterai saat ini
    private float batteryDecreasePerSecond = 1f; // Jumlah pengurangan baterai per detik
    private Light2D senterX;
    void Start()
    {
        if (PlayerPrefs.HasKey("BatteryHealth"))
        {
            currentBattery = PlayerPrefs.GetFloat("BatteryHealth");
        }
        else
        {
            currentBattery = startingBattery;
            PlayerPrefs.SetFloat("BatteryHealth", currentBattery);
        }
        senterX = GetComponent<Light2D>(); // Mendapatkan komponen Light2D
        senterX.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Periksa apakah baterai masih cukup untuk menyalakan senter
            if (currentBattery > 0)
            {
                // Toggle senter on off
                senterX.enabled = !senterX.enabled;
            }
            else
            {
                Debug.Log("Battery Empty! Cannot turn on the spotlight."); // untuk notif di UI
            }
        }
        // Matikan senter jika baterai = 0
        if (currentBattery == 0)
        {
            senterX.enabled = false;
        }
        // Kurangi baterai jika senter menyala
        if (senterX.enabled)
        {
            DecreaseBattery(batteryDecreasePerSecond * Time.deltaTime); // Kurangi baterai per detik
        }
    }
    void DecreaseBattery(float amount)
    {
        currentBattery -= amount;
        PlayerPrefs.SetFloat("BatteryHealth", currentBattery); // Simpan baterai di PlayerPrefs
        if (currentBattery <= 0)
        {
            currentBattery = 0; // Pastikan baterai tidak negatif
        }
    }
}
