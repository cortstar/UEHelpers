using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorHelper
{
    public delegate float ComponentOperation(float f);
    public delegate bool ComponentConditionCheck(float f);

    /// <summary>
    /// Performs an operation on each component of a vector.
    /// </summary>
    /// <param name="v">The vector to operate on</param>
    /// <param name="c">The operation to perform (ComponentOperation - single float parameter, returns float).</param>
    /// <returns></returns>
    public static Vector3 Componentwise(this Vector3 v, ComponentOperation c)
    {
        return new Vector3( c(v.x), c(v.y), c(v.z) );
    }

    /// <summary>
    /// Performs an operation on each component of a vector.
    /// </summary>
    /// <param name="v">The vector to operate on</param>
    /// <param name="c">The operation to perform (ComponentOperation - single float parameter, returns float).</param>
    /// <returns></returns>
    public static Vector2 ComponentWise(this Vector2 v, ComponentOperation c)
    {
        return new Vector2( c(v.x), c(v.y) );
    }

    /// <summary>
    /// Checks if each component of a vector meets a condition.
    /// </summary>
    /// <param name="v">The vector to check</param>
    /// <param name="c">The condition to satisfy,</param>
    /// <returns>Returns whether each component meets the condition.</returns>
    public static bool ComponentwiseCheck(this Vector3 v, ComponentConditionCheck c)
    {
        return c(v.x) && c(v.y) && c(v.z);
    }

    /// <summary>
    /// Checks if each component of a vector meets a condition.
    /// </summary>
    /// <param name="v">The vector to check</param>
    /// <param name="c">The condition to satisfy,</param>
    /// <returns>Returns whether each component meets the condition.</returns>
    public static bool ComponentwiseCheck(this Vector2 v, ComponentConditionCheck c)
    {
        return c(v.x) && c(v.y);
    }

}
