using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbstractionMachines;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private Color highlightColor = Color.green;
    private List<GameObject> _selectedObjects;

    private void Start()
    {
        _selectedObjects = new List<GameObject>();
    }

    public void Select(GameObject targetObject)
    {
        _selectedObjects.Add(targetObject);
        GameObjectUtility.Highlight(targetObject, highlightColor);
    }

    public void Deselect(GameObject targetObject)
    {
        _selectedObjects.Remove(targetObject);
        GameObjectUtility.UnHighlight(targetObject);
    }

    public void Clear()
    {
        for (int i = _selectedObjects.Count - 1; i >= 0; i--)
        {
             Deselect(_selectedObjects[i]);           
        }
    }
}
