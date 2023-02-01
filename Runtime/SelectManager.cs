using System.Collections.Generic;
using AbstractionMachines;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [SerializeField]
    Color highlightColor = Color.green;

    public List<GameObject> SelectedObjects { get; private set; }

    void Start()
    {
        SelectedObjects = new List<GameObject>();
    }

    public void Select(GameObject targetObject)
    {
        ISelectable selectable = targetObject.GetComponent<ISelectable>();
        if (selectable == null)
        {
            return;
        }
        SelectedObjects.Add(targetObject);
        selectable.OnSelect();
        GameObjectUtility.Highlight(targetObject, highlightColor);
    }

    public void Deselect(GameObject targetObject)
    {
        ISelectable selectable = targetObject.GetComponent<ISelectable>();
        if (selectable == null)
        {
            return;
        }
        SelectedObjects.Remove(targetObject);
        selectable.OnDeselect();
        GameObjectUtility.UnHighlight(targetObject);
    }

    public void Clear()
    {
        for (int i = SelectedObjects.Count - 1; i >= 0; i--)
        {
            Deselect(SelectedObjects[i]);
        }
    }
}
