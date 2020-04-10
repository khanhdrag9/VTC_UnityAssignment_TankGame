using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    private Transform valueObj;
    [Range(0f, 1f)]public float value;

    void Awake()
    {
        valueObj = transform.GetChild(0);
    }

    private void Update()
    {
        valueObj.localScale = Vector2.Lerp(valueObj.localScale, new Vector2(value, 1), 0.3f);
    }
}
