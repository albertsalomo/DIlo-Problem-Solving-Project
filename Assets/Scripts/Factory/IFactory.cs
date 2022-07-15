using System;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory
{
    GameObject Generate(GameObject prefab, Transform parent);
}
