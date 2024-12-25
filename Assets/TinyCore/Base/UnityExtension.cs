using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameMei
{
    public static class UnityExtension
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            if(component==null)
            {
                component = gameObject.AddComponent<T>();
            }

            return component;
        }
    }

}
