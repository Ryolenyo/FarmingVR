using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadinator : MonoBehaviour
{
    [SerializeField]
    private float timer;

    [SerializeField]
    private string sceneNameToLoad;

    private float timeElapsed;

    public bool timeOver;

    void Start()
    {
        timeOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if(timeElapsed > timer)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
