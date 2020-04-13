using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityChanger : MonoBehaviour
{
    public List<SpriteRenderer> sprites = new List<SpriteRenderer>();
    public List<TextMesh> textMeshes = new List<TextMesh>();
    public bool visible { get; protected set; }

    void Start()
    {
        var p = GetComponentsInChildren<SpriteRenderer>();
        foreach (var e in p) sprites.Add(e);
        visible = true;
    }

    public void SetAlpha(float value)
    {
        foreach (var e in sprites)
            e.color = e.color.SetAlpha(value);
        foreach (var e in textMeshes)
            e.color = e.color.SetAlpha(value < 1 ? 0 : 1);
        visible = value > 0.3f;
    }
}
