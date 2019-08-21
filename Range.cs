using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Range
{

    public float Min;
    public float Max;

    /// <summary>
    /// Produces a 'normal' (0-1) range.
    /// </summary>
    public static Range NormalRange = new Range(0f, 1f);

    /// <summary>
    /// Produces a 'percentile' (0-100) range.
    /// </summary>
    public static Range PercentageRange = new Range(0f, 100f);

    public Range(float min, float max)
    {
        Min = min;
        Max = max;


        if (GetSize() <= 0f)
        {
            throw new System.InvalidOperationException("Invalid range created: Range size must be greater than zero.");
        }
    }

    public float GetSize()
    {
        return Max - Min;
    }

    public bool ContainsValue(float f)
    {
        return (f <= Max && f >= Min);
    }

    public static float MapValueBetweenRanges(float value, Range from, Range to)
    {
        return ((value - from.Min) * (to.Max - to.Min) / (from.Max - from.Min)) + to.Min;
    }

    public static Vector3 MapValuesBetweenRanges(Vector3 value, Range from, Range to)
    {
        Vector3 output = Vector3.zero;
        output.x = MapValueBetweenRanges(value.x, from, to);
        output.y = MapValueBetweenRanges(value.y, from, to);
        output.z = MapValueBetweenRanges(value.z, from, to);

        return output;
    }

}
