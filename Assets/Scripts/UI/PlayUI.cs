using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayUI : MonoBehaviour
{
    public void Exit()
    {
        if (GameManager.Instance.gamemode != GameMode.SINGLE)
        {
            Photon.Pun.PhotonNetwork.Disconnect();
        }
    }
}
