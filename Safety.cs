using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Safety
{

    public delegate void ComponentAction<in T>(T component);

    /// <summary>
    /// Get the component of the object and end the game with a formatted error if 
    /// the component is not found.
    /// </summary>
    /// <typeparam name="T">Component type</typeparam>
    /// <param name="gameObject"></param>
    /// <returns>The component.</returns>
    public static T GetComponentSafely<T>(this GameObject gameObject) where T : Component
    {
        T component = null;
        
        try
        {
            component = gameObject.GetComponent<T>();
        }
        catch(System.NullReferenceException)
        {
            Debug.LogError(string.Format("Tried to find a {0} on {1} but failed.", typeof(T), gameObject.name));
        }

        return component;
    }

    /// <summary>
    /// Get the component of the object and add it if it does not exist.
    /// </summary>
    /// <typeparam name="T">Component type</typeparam>
    /// <param name="gameObject"></param>
    /// <returns>The component.</returns>
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        T component = gameObject.GetComponent<T>();

        if (component == null)
        {
            Debug.LogFormat("Tried to find a {0} on {1} but failed. Adding one.", typeof(T).ToString(), gameObject.name);
            component = gameObject.AddComponent<T>();
        }

        return component;

    }
    
    /// <summary>
    /// Call a function on a component if it exists. Useful for one-off components that won't need to be reused.
    /// </summary>
    /// <param name="action">The function to be called.</param>
    /// <typeparam name="T">The type of component to call on.</typeparam>
    /// <returns>Whether or not the component exists.</returns>
    public static bool GetComponentCallbackOrIgnore<T>(this GameObject gameObject, ComponentAction<T> action) where T: Component
    {
        var component = gameObject.GetComponent<T>();
        
        if (component == null)
            return false;

        action(component);
        return true;
    }

    public static bool Exists(this Component c)
    {
        return !(c == null);
    }
}
