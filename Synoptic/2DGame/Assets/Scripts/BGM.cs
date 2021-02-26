using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    // 1st method Unity runs 
    void Awake()
    {
        SetUpSingleton();
    }

    //will be implemented once
    private void SetUpSingleton()
    {
        //this is getting type of object in the BgMusic script
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            //destroy last BgMusic
            Destroy(gameObject);
        }
        else
        {
            //keeps playing same music on different scenes
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
