using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Rotation : MonoBehaviour
{
    [Range(0, 1)]public float speed;

    public bool Handle(Vector2 direction, float speedScale = 1)
    {
        float angle = Helper.Angle90(direction);
        Quaternion target = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, target, speed * speedScale);

        return transform.rotation == target;
    }

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //    {
    //        stream.SendNext(transform.rotation);
    //    }
    //    else
    //    {
    //        transform.rotation = (Quaternion)stream.ReceiveNext();
    //    }
    //}
}
