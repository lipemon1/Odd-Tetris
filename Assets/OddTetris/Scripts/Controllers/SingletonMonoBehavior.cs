using UnityEngine;

public class SingletonMonoBehavior<T> : MonoBehaviour where T : SingletonMonoBehavior<T>
{
    private static T _Instance;
    private static Transform _Holder;
    
    public static T Instance
    {
        get
        {
            if (_Instance != null)
                return _Instance;

            T obj = FindObjectOfType<T>();
            if (obj == null)
            {
                GameObject newObject = new GameObject($"Singleton {typeof(T).Name}");
                newObject.transform.SetParent(GetTransformHolder());
                obj = newObject.AddComponent<T>();
            }
            _Instance = obj;
            return _Instance;
        }
    }

    private static Transform GetTransformHolder()
    {
        if (_Holder == null)
        {
            _Holder = GameObject.Find("[SINGLETON]").GetComponent<Transform>();
        }

        return _Holder;
    }
}
