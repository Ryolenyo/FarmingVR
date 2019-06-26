using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string nextSceneName;
    public void nextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
