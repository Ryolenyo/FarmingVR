using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerPocket : MonoBehaviourPun
{
    public int money;
    public GameObject pointer;
    public bool pointerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pointerOn)
        {
            pointer.SetActive(true);
        }
        
        if (!photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }
        
    }

}