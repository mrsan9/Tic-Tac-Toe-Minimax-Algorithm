using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantManager : MonoBehaviour
{
    public static PersistantManager PM;

    private void Awake()
    {
        if (PM == null)
        {
            PM = this;
        }
        else
        {
            if (PM != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public enum gameStates { easy=1,medium,hard,multiplayer };

    public gameStates currGameState=0;


}
