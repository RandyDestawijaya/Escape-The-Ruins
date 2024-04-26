using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public Transform Firepoint;
    public GameObject Arrow;
    float timebetween;
    public float starttimebetween;
    private void Start()
    {
        timebetween = starttimebetween;
    }
    private void Update()
    {
        if (timebetween <= 0)
        {
            Instantiate(Arrow, Firepoint.position, Firepoint.rotation);
            timebetween = starttimebetween;
        }
        else
        {
            timebetween -= Time.deltaTime;
        }
    }
}
