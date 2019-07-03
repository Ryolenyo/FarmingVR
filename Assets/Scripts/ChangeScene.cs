using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeScene : MonoBehaviour
{
    public float countDown = 3;
    public string sceneName;

    private void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown < 0)
        {
            Application.LoadLevel(sceneName);
        }
    }

}
