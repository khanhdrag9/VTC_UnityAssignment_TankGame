using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        var player = Instantiate(prefab, GetPosition(), Quaternion.identity);
        controller.target = player.GetComponent<ControlAbleObject>();
    }

    void Update()
    {
        
    }
}
