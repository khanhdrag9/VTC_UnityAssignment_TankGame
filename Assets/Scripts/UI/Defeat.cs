using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Defeat : MonoBehaviour
{
    public void Restart()
    {
        if(GameManager.Instance.gamemode == GameMode.SINGLE)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        if(GameManager.Instance.gamemode != GameMode.SINGLE)
        {
            //PhotonNetwork.LeaveRoom();
            //PhotonNetwork.LeaveLobby();
            PhotonNetwork.Disconnect();
        }
        SceneManager.LoadScene(0);
    }
}
