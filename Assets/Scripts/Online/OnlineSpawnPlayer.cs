using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OnlineSpawnPlayer : MonoBehaviour
{
    public List<Vector2> positions;
    public Player prefab;
    public Controller controller;

    void Start()
    {
        SpawnPlayer();
    }

    public Vector2 GetPosition()
    {
        int rand = Random.Range(0, positions.Count);
        Vector2 output = positions[rand];
        return output;
    }

    public void SpawnPlayer()
    {
        GameObject player = null;
        if (GameManager.Instance.gamemode == GameMode.MULTI)
        {
            player = PhotonNetwork.Instantiate("Player", GetPosition(), Quaternion.identity);
            player.GetComponent<PhotonView>().RPC("SetName", RpcTarget.All, OnlineSystem.Instance.playerName);
            
        }
        else
            player = Instantiate(prefab, GetPosition(), Quaternion.identity).gameObject;

        controller.target = player.GetComponent<ControlAbleObject>();
    }

    void Update()
    {
        
    }
}
