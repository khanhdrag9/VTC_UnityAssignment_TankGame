using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    //private void OnTriggerEnter2D(Collider2D collision)
    {
        var o = collision.GetComponent<OpacityChanger>();
        o?.SetAlpha(0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var o = collision.GetComponent<OpacityChanger>();
        o?.SetAlpha(1);
    }
}
