using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TextSync : MonoBehaviour, IPunObservable
{
    private PhotonView view;
    public string value;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(view == null) view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            stream.SendNext(value);
        }
        else
        {
            value = (string)stream.ReceiveNext();
        }
    }
}
