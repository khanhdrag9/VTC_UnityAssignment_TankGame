using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMovement : Movement
{
    public override void Handle(Vector2 direction, float speedScale)
    {
        Vector2 newpos = (Vector2)transform.position + direction * Speed * speedScale * Time.fixedDeltaTime;
        newpos = Controller.ClampPosition(newpos, false, Vector2.one);
        //transform.position = Vector2.Lerp(transform.position, newpos, 0.3f);
        transform.position = newpos;

        scale = 1;
    }

    void Update()
    {
        
    }
}
