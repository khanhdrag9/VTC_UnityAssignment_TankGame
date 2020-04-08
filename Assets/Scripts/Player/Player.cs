using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private ControlAbleObject controlAbleObject;
    private Movement movement;
    private Rotation rotation;
    private ShootObject shootObject;

    void Start()
    {
        ReUpdateComponents();
    }

    public void ReUpdateComponents()
    {
        controlAbleObject = GetComponent<ControlAbleObject>();
        movement = GetComponent<Movement>();
        rotation = GetComponent<Rotation>();
        shootObject = GetComponent<ShootObject>();
    }

    private void UpdateMine()
    {
        rotation?.Handle(controlAbleObject.mouseDirect, 1);

        if (Input.GetMouseButtonDown(0))
        {
            shootObject?.Shoot(controlAbleObject.mouseDirect, 1, 1);
        }
    }

    private void FixedUpdateMine()
    {
        movement?.Handle(controlAbleObject.direct, 1);
    }

    void Update()
    {
        UpdateMine();
    }

    private void FixedUpdate()
    {
        FixedUpdateMine();
    }
}
