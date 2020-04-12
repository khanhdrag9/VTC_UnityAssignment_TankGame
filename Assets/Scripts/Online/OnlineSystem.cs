using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using ExitGames.Client.Photon;

public class OnlineSystem : MonoBehaviourPunCallbacks, IOnEventCallback
{
    public string playerName { get; set; }
    private const string gameversion = "1";
    public System.Action<bool> OnConnectResult;
    public ServerSettings cloudSetting;
    public ServerSettings serverSetting;

    public TextNotification notificationPrefab;


    public static OnlineSystem Instance { get; private set; }

    public enum OnlineEvent
    {
        PLAYER_JOIN = 1, PLAYER_LEAVE
    }

    protected void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        Instance = this;
        PhotonNetwork.AutomaticallySyncScene = false;
        PhotonNetwork.AddCallbackTarget(this);
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
        SendEventJoinStatus(true);
        PhotonNetwork.NickName = playerName;
        PhotonNetwork.LoadLevel(3);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        SendEventJoinStatus(false);
    }

    private void OnApplicationQuit()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
        PhotonNetwork.Disconnect();
    }

    public void SendEventJoinStatus(bool isJoin)
    {
        byte evCode = isJoin ? (byte)OnlineEvent.PLAYER_JOIN : (byte)OnlineEvent.PLAYER_LEAVE;
        object[] content = new object[] { playerName };
        RaiseEventOptions options = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
        SendOptions send = new SendOptions { Reliability = true };
        PhotonNetwork.RaiseEvent(evCode, content, options, send);
    }

    public void OnEvent(EventData photonEvent)
    {
        if(photonEvent.Code == (byte)OnlineEvent.PLAYER_JOIN || photonEvent.Code == (byte)OnlineEvent.PLAYER_LEAVE)
        {
            var noti = Instantiate(notificationPrefab, Camera.main.transform);
            string lastText = photonEvent.Code == (byte)OnlineEvent.PLAYER_JOIN ? " joined our game!" : " left our game!";
            noti.text = (string)((object[])photonEvent.CustomData)[0] + lastText;
            noti.timeRemain = 3f;
        }
    }
}
