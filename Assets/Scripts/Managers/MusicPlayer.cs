using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance = null;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        if (Application.isEditor)
            Destroy(gameObject);
    }
}
