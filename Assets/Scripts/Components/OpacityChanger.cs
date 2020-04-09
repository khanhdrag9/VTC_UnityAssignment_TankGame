using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityChanger : MonoBehaviour
{
    private SpriteRenderer[] sprites;
    public bool visible { get; protected set; }

    void Start()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
        visible = true;
    }

    public void SetAlpha(float value)
    {
        foreach (var sprite in sprites)
            sprite.color = sprite.color.SetAlpha(value);
        visible = value > 0.3f;
    }
}
