using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    public float Speed => speed * scale;
    [HideInInspector] public float scale = 1;

    public abstract void Handle(Vector2 direction, float speedScale);
    public abstract bool HandleWithTarget(Vector2 target, float speedScale);
}
