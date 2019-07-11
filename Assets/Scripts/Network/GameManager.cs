using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(this.playerPrefab.name,
           new Vector3(0,0.5f,0),
           Quaternion.Euler(0, 0, 0),
           0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (!PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene("Start");
            return;
        }
    }

}
