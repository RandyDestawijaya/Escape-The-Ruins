using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DestroyonTimer : MonoBehaviour
{
    public float ChangeTime;

    [SerializeField]
    GameObject gameobject;

    // Update is called once per frame
    private void Update()
    {
        ChangeTime -= Time.deltaTime;
        if (ChangeTime <= 0)
        {
            Destroy(this.gameobject);
        }
       
    }
}
