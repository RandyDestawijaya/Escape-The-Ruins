using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public Transform Firepoint;
    public GameObject Arrow;
    float timebetween;
    public float starttimebetween;
    public static int remainingArrow = 0;
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
            remainingArrow = remainingArrow + 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timebetween -= Time.deltaTime;
        }
    }

    public static void RemoveArrow()
    {
        remainingArrow--;
    }
}
