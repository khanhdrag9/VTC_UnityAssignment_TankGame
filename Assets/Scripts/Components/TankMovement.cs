using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rotation))]
public class TankMovement : Movement
{
    [Range(0f, 1f)]public float speedRotation;
    private Rotation rotation = null;

    private void Start()
    {
        rotation = GetComponent<Rotation>();
    }
    public override void Handle(Vector2 direction, float speedScale)
    {
        if (direction == Vector2.zero) return;
        if (direction + (Vector2)transform.up == Vector2.zero)
        {
            direction += new Vector2(0.5f, 0.5f);
        }

        rotation.Handle(direction, speedRotation);
        transform.Translate(Vector2.up * Speed * speedScale * Time.fixedDeltaTime);
    }

    public override bool HandleWithTarget(Vector2 target, float speedScale)
    {
        float distanceMove = Speed * speedScale * Time.fixedDeltaTime;
        float distanceToTarget = (target - (Vector2)transform.position).magnitude;

        bool reachTarget = distanceToTarget < distanceMove / speedRotation;

        Vector2 direction = (target - (Vector2)transform.position).normalized;
        rotation.Handle(direction, speedRotation);
        if (!reachTarget)
        {
            transform.Translate(Vector2.up * distanceMove);
        }
        
        return reachTarget;
    }
}
