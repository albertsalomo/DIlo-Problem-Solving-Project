using System;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxFactory : MonoBehaviour, IFactory
{
    public GameObject Generate(GameObject prefab, Transform parent)
    {
        GameObject newRandomBox = Instantiate(prefab, parent);
        return newRandomBox;
    }
}