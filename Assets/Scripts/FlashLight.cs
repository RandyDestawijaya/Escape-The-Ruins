using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashLight : MonoBehaviour
{
    public float ChangeTime;

    private void Update()
    {
        ChangeTime -= Time.deltaTime;
        if (ChangeTime <= 0)
        {
           gameObject.SetActive(false);
        }
    }
}
