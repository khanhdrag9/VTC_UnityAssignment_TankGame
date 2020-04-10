using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Tank
{
    public float ranger;
    public Transform target;

    private int shootLayer;
    private void Start()
    {
        shootLayer = LayerMask.GetMask("Player", "Obstacle");
    }

    protected override void FixedUpdateMine()
    {
        
    }

    protected override void UpdateMine()
    {
        if (target == null || target.gameObject.activeSelf == false) return;

        Vector2 offset = target.position - transform.position;
        Vector2 direction = offset.normalized;
        RaycastHit2D cast = Physics2D.Raycast(transform.position, direction, ranger, shootLayer);
        
        if(cast)
        {
            if (cast.collider.tag.Equals("Player") == false) return;

            bool aim = barrelRotation.Handle(direction);
            OpacityChanger playerOp = cast.collider.GetComponent<OpacityChanger>();
            if (playerOp && playerOp.visible == false) return;

            if (aim && shootObject.canShoot)
                shootObject.Shoot(barrelRotation.transform.rotation);
        }
    }

    public bool MoveTo(Vector2 target)
    {
        //rotation.Handle(target - (Vector2)transform.position, 1);
        return movement.HandleWithTarget(target, 1);
    }
}
