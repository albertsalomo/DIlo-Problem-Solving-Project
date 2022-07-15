using System;
using System.Collections.Generic;
using UnityEngine;

public class OldRandomBoxFactory : MonoBehaviour, OldIFactory
{
    public GameObject Generate(GameObject prefab, Vector2 generate, Transform parent)
    {
        GameObject newRandomBox = Instantiate(prefab, generate, Quaternion.identity, parent);

        return newRandomBox;
    }
}