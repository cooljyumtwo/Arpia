using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static private T _instance;

    static public T Instance
    {
        get 
        {
            if (_instance == null)
            {
                string name = typeof(T).Name;
                GameObject gameObject = new GameObject(name);
                gameObject.AddComponent<T>();
            }

            return _instance;
        }
    }
}
