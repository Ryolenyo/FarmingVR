using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void nextScene(string nextSceneName)
    {
        Application.LoadLevel(nextSceneName);
    }
}
