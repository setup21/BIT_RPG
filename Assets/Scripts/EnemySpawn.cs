using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Obj;
    public float time;
    public Transform[] point = new Transform[3];

    public int Max;
    static public int Count;

    void Create()
    {
        if (Count >= Max)
            return;

        Count++;

        int i = Random.Range(0, point.Length);
        Instantiate(Obj, point[i]);
    }
    void Start()
    {
        Create();
        InvokeRepeating("Create", time, time);
    }    
}
