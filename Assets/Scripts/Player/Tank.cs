using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tank : MonoBehaviour
{
    protected Movement movement;
    protected Rotation rotation;
    protected ShootObject shootObject;

    protected virtual void Awake()
    {
        ReUpdateComponents();
    }

    public virtual void ReUpdateComponents()
    {
        movement = GetComponent<Movement>();
        rotation = GetComponent<Rotation>();
        shootObject = GetComponent<ShootObject>();
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
