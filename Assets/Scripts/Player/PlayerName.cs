using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerName : MonoBehaviour
{
    private TextMesh displayer;
    private TextSync textOnline;
    private FloatSync alphaOnline;
    private PhotonView view;

    void Awake()
    {
        view = GetComponent<PhotonView>();
        displayer = GetComponent<TextMesh>();
        textOnline = GetComponent<TextSync>();
        alphaOnline = GetComponent<FloatSync>();
        alphaOnline.value = displayer.color.a;

        GetComponent<Renderer>().sortingLayerName = "Objects";
    }

    void Update()
    {
        if (displayer == null || textOnline == null) return;

        if (view.IsMine)
        {
            textOnline.value = displayer.text;
            alphaOnline.value = displayer.color.a;
        }
        else
        {
            displayer.text = textOnline.value;
            displayer.color = displayer.color.SetAlpha(alphaOnline.value);
        }
    }
}
