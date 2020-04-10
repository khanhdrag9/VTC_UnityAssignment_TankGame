using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tank : MonoBehaviour
{
    protected Movement movement;
    protected Rotation rotation;
    protected Rotation barrelRotation;
    protected ShootObject shootObject;
    protected LiveObject liveObject;

    protected virtual void Awake()
    {
        ReUpdateComponents();
    }

    public virtual void ReUpdateComponents()
    {
        movement = GetComponent<Movement>();
        rotation = GetComponent<Rotation>();
        barrelRotation = transform.Find("Barrel").GetComponent<Rotation>();
        shootObject = GetComponent<ShootObject>();
        liveObject = GetComponent<LiveObject>();
    }

    protected abstract void UpdateMine();

    protected abstract void FixedUpdateMine();

    #region basic loop
    private void Update()
    {
        UpdateMine();
    }

    private void FixedUpdate()
    {
        FixedUpdateMine();
    }
    #endregion
}
