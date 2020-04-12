using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerName : MonoBehaviour
{
    private TextMesh displayer;
    private TextSync textOnline;

    void Awake()
    {
        displayer = GetComponent<TextMesh>();
        textOnline = GetComponent<TextSync>();
    }

    void Update()
    {
        if (displayer == null || textOnline == null) return;

        displayer.text = textOnline.value;
    }
}
