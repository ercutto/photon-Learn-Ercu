using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{
    #region Variables
    [HideInInspector] public static MyGameManager Instance { get; private set; }
    float lagTimer;
    #endregion Variables

    ///////////////////////////////////////////////////////////

    #region Unity's functions
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else if (this != Instance)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }


}
    #endregion

