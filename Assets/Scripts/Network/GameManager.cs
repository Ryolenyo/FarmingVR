using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public Transform[] sitPosition;
    public int number;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            number = 3;
        }

        PhotonNetwork.Instantiate(this.playerPrefab.name,
           new Vector3(sitPosition[number].transform.position.x, sitPosition[number].transform.position.y, sitPosition[number].transform.position.z),
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
