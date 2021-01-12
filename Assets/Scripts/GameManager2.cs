using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class GameManager2 : MonoBehaviourPunCallbacks
{

    public OnlinePlayer PlayerPrefab;

    [HideInInspector]
    public Player LocalPlayer;

    private void Awake()
    {
        if (!PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene("arena");
            return;
        }
    }

    // Use this for initialization
    void Start()
    {
        LocalPlayer = PhotonNetwork.Instantiate("OnlinePlayer", Vector3.zero, Quaternion.identity).GetComponent<Player>();
       // if (PhotonNetwork.IsMasterClient)
        //    PhotonNetwork.InstantiateSceneObject("Car", new Vector3(0, 1, 20), Quaternion.identity);
    }
    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player target, ExitGames.Client.Photon.Hashtable changedProps)
    {
        foreach (var change in changedProps)
            Debug.Log("Property " + change.Key + " of player " + target.UserId + " changed to " + change.Value);
    }
}
