using System.Collections.Generic;
using System.Linq;
using AbstractionMachines;
using UnityEngine;
using UnityEngine.Events;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private Color highlightColor = Color.green;

    public HashSet<GameObject> SelectedObjects { get; private set; }

    public UnityEvent objectSelected;
    public UnityEvent objectDeselected;

    private void Start()
    {
        SelectedObjects = new HashSet<GameObject>();
    }

    public void Select(GameObject targetObject)
    {
        var selectable = targetObject.GetComponent<ISelectable>();
        if (selectable == null) return;
        SelectedObjects.Add(targetObject);
        selectable.OnSelect();
        GameObjectUtility.Highlight(targetObject, highlightColor);
        objectSelected.Invoke();
        // TODO add a delete event to ISeelctable objects and start listening here for it
        // if object is deleted from SelectedObjects
    }

    public void Deselect(GameObject targetObject)
    {
        var selectable = targetObject.GetComponent<ISelectable>();
        if (selectable == null) return;
        SelectedObjects.Remove(targetObject);
        selectable.OnDeselect();
        GameObjectUtility.UnHighlight(targetObject);
        objectDeselected.Invoke();
    }

    public void Clear()
    {
        var selectedObjectsList = SelectedObjects.ToList();
        for (var i = SelectedObjects.Count - 1; i >= 0; i--) Deselect(selectedObjectsList[i]);
    }
}