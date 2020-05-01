using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class MonobehaviourHelper
{
    /// <summary>
    /// Ensure that there is one and only one instance of a monobehaviour
    /// </summary>
    /// <param name="m"></param>
    /// <param name="instance"></param>
    public static void Singleton<T>(this T m, ref T instanceVariable) where T:MonoBehaviour
    {
        if (instanceVariable == null)
        {
            instanceVariable = m;
            return;
        }
        
        Debug.LogWarningFormat("Warning, extra instance of {0} in scene.", m.GetType());
    }
    
}
