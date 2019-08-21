using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RangeExtensions
{
    public static float ClampTo(this float f, Range r)
    {
        if (f > r.Max)
        {
            return r.Max;
        }
        else if (f < r.Min)
        {
            return r.Min;
        }
        else
        {
            return f;
        }
    }

}
