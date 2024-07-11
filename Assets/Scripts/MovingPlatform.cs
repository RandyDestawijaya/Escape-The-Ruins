using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    Transform Platform;

    [SerializeField]
    Transform[] Points;

    float mover = 0;

    [SerializeField]
    float moveSpeed = 2;

    // Update is called once per frame
    void Update()
    {
        mover = mover + Time.deltaTime * moveSpeed;
        Platform.position = Vector2.Lerp(Points[0].position, Points[1].position, (Mathf.Sin(mover) + 1) / 2);
    }
}
