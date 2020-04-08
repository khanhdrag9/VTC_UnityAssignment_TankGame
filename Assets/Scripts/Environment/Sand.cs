using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand : MonoBehaviour
{
    public float speedScaleOn;

    private void OnTriggerStay2D(Collider2D collision)
    {
        var moveObj = collision.GetComponent<Movement>();
        if (moveObj)
        {
            moveObj.scale = speedScaleOn;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var moveObj = collision.GetComponent<Movement>();
        if (moveObj)
        {
            moveObj.scale = 1;
        }
    }
}
