using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Tank
{
    protected override void FixedUpdateMine()
    {
        
    }

    protected override void UpdateMine()
    {
    }

    public bool MoveTo(Vector2 target)
    {
        rotation.Handle(target - (Vector2)transform.position, 1);
        return movement.HandleWithTarget(target, 1);
    }
}
