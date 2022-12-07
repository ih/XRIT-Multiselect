using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbstractionMachines;

public class SelectManager : MonoBehaviour
{
    private HashSet<GameObject> _selectedObjects;

    private void Start()
    {
        _selectedObjects = new HashSet<GameObject>();
    }

    public void Select(GameObject targetObject)
    {
        _selectedObjects.Add(targetObject);
        GameObjectUtility.Highlight(targetObject, Color.red);
    }
}
