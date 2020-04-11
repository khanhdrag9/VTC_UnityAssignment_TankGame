using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class OnlineSystem : MonoBehaviourPunCallbacks
{
    public string playerName { get; set; }

    private const string gameversion = "1";

    public System.Action<bool> OnConnectResult;

    public static OnlineSystem Instance { get; private set; }

    protected void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void Find()
    {
        Connect();
    }

    private void Connect()
    {
        PhotonNetwork.NickName = playerName;
        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameversion;
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        OnConnectResult?.Invoke(false);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomOptions options = new RoomOptions();
        options.IsOpen = true;
        options.IsVisible = true;
        options.MaxPlayers = 4;

        PhotonNetwork.CreateRoom("room1", options, TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(3);
    }

}
