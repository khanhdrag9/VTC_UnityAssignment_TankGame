using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Tank
{
    private ControlAbleObject controlAbleObject;

    public override void ReUpdateComponents()
    {
        base.ReUpdateComponents();
        controlAbleObject = GetComponent<ControlAbleObject>();
    }

    protected override void UpdateMine()
    {
        barrelRotation?.Handle(controlAbleObject.mouseDirect, 1);

        if (Input.GetMouseButtonDown(0))
        {
            shootObject?.Shoot(controlAbleObject.mouseDirect);
        }
    }

    protected override void FixedUpdateMine()
    {
        movement?.Handle(controlAbleObject.direct, 1);
    }
}
