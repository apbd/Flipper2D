using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class OnlinePlayer : MonoBehaviourPun
{
    private bool player2 = false;
    void Start()
    {
        //jos scenessä on jo onlineplayer niin aseta uusi p2
        if (this.gameObject.name == "OnlinePlayer(clone)") 
        {
            player2 = true;
        }
    }

    void Update()
    {
        if (player2)
        {
            this.gameObject.transform.position = new Vector3(0, 10, -1);
            P2FlipperMover.swapped = true;
        }

    }

    public static void RefreshInstance(ref OnlinePlayer player, OnlinePlayer Prefab)
    {
        var position = Vector3.zero;
        var rotation = Quaternion.identity;
        if (player != null)
        {
            position = player.transform.position;
            rotation = player.transform.rotation;
            PhotonNetwork.Destroy(player.gameObject);
        }

        player = PhotonNetwork.Instantiate(Prefab.gameObject.name, position, rotation).GetComponent<OnlinePlayer>();
    }
}
