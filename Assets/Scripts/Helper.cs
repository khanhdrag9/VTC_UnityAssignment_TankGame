using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public static float Angle90(Vector2 direction)
    {
        float angle = 0;
        angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg; 
        return angle;
    }

    public static float Angle0(Vector2 offset)
    {
        float angle = 0;
        if (offset.x == 0)
        {
            if (offset.y > 0) return 90;
            if (offset.x == 0 && offset.y < 0) return 270;
            return 0;
        }
        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        return angle;
    }

    public static Color SetAlpha(this Color color, float value)
    {
        color.a = value;
        return color;
    }
}
