using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.tankSpawns.Add(this); 
    }

    private void OnDestroy()
    {
        GameManager.instance.tankSpawns.Remove(this);
    }

}
