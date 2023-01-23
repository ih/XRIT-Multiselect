using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbstractionMachines;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private Color highlightColor = Color.green;
    private List<GameObject> selectedObjects;

    public List<GameObject> SelectedObjects
    {
        get => selectedObjects;
    }

    private void Start()
    {
        selectedObjects = new List<GameObject>();
    }

    public void Select(GameObject targetObject)
    {
        selectedObjects.Add(targetObject);
        GameObjectUtility.Highlight(targetObject, highlightColor);
    }

    public void Deselect(GameObject targetObject)
    {
        selectedObjects.Remove(targetObject);
        GameObjectUtility.UnHighlight(targetObject);
    }

    public void Clear()
    {
        for (int i = selectedObjects.Count - 1; i >= 0; i--)
        {
             Deselect(selectedObjects[i]);           
        }
    }
}
