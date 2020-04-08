using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityChanger : MonoBehaviour
{
    SpriteRenderer[] sprites;
    void Start()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    public void SetAlpha(float value)
    {
        foreach (var sprite in sprites)
            sprite.color = sprite.color.SetAlpha(value);
    }
}
