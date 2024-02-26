using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventure : MonoBehaviour
{
    #region Singleton
    public static Adventure Instance { get; private set; }
    public void Awake()
    {
        if (Instance == null) Instance = this;
        else DestroyImmediate(this);

    }
    public void OnDestroy()
    { }
    #endregion
}
