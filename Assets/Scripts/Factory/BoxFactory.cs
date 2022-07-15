using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFactory : MonoBehaviour, IFactory
{
    public GameObject Generate(GameObject prefab, Transform parent)
    {
        GameObject newBox = Instantiate(prefab, parent);
        newBox.SetActive(true);
        return newBox;
    }
}
