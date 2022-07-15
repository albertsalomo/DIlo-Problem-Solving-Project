using System;
using System.Collections.Generic;
using UnityEngine;

public interface OldIFactory
{
    GameObject Generate(GameObject prefab, Vector2 generate, Transform parent);
}