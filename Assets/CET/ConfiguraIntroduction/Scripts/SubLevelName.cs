using Audio.CET;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubLevelName : MonoBehaviour
{
    public SubLevel subLevelName;
    public AudioName audioName;
    void Start()
    {
        
    }
}

public enum SubLevel
{
    NotSet = 0,
    CET = 1,
    EMacs = 2,
    CM = 3,
}
