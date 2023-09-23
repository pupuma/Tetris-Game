using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : class, new()
{
    private static T instance = null;

    [Header("Singleton Setting")]
    public bool useDontDestoryOnLoad = true;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
            }

            return instance;

        }
    }

    protected bool InitSingleton(T set)
    {
        if (instance == null)
        {
            instance = set;
            transform.SetParent(null);

            if (useDontDestoryOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }

            return true;
        }
        else
        {
            if (useDontDestoryOnLoad)
            {
                Destroy(gameObject);
                return false;
            }
            else
            {
                instance = set;
                transform.SetParent(null);
                return true;
            }

        }

    }

    protected virtual void DestroyedSinglton()
    {
        instance = null;
    }


}
