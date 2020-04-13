using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class Sync<T> : MonoBehaviour, IPunObservable
{
    private PhotonView view;
    public T value;

    public virtual void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (view == null) view = GetComponent<PhotonView>();

        if (view.IsMine)
        {
            stream.SendNext(value);
        }
        else
        {
            value = (T)stream.ReceiveNext();
        }

    }
}
