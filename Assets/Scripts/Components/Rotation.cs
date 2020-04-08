using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public void Handle(Vector2 direction, float speedScale)
    {
        float angle = Helper.Angle90(direction);
        Quaternion target = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, target, speedScale);
    }
}
