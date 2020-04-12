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
    public ServerSettings cloudSetting;
    public ServerSettings serverSetting;

    public static OnlineSystem Instance { get; private set; }

    protected void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        PhotonNetwork.AutomaticallySyncScene = false;
        //PhotonNetwork.SendRate = 300;
        //PhotonNetwork.SerializationRate = 150;
    }

    public void Find()
    {
        Connect();
    }

    private void Connect()
    {
        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.PhotonServerSettings = GameManager.Instance.gamemode == GameMode.MULTI ? cloudSetting : serverSetting;
            PhotonNetwork.GameVersion = gameversion;
            PhotonNetwork.ConnectUsingSettings();
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
        PhotonNetwork.NickName = playerName;
        PhotonNetwork.LoadLevel(3);
    }

    private void OnApplicationQuit()
    {
        PhotonNetwork.Disconnect();
    }
}
