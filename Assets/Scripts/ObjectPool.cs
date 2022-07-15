using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    // Create a list for random box 
    private List<GameObject> pool = new List<GameObject>();

    public GameObject CheckPool()
    {
        return pool.Find(obj => !obj.activeSelf);
    }

    public void AddToPool(GameObject obj)
    {
        pool.Add(obj);
    }
}
