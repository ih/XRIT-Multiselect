using System.Collections.Generic;
using System.Linq;
using AbstractionMachines;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [SerializeField]
    Color highlightColor = Color.green;

    public HashSet<GameObject> SelectedObjects { get; private set; }

    void Start()
    {
        SelectedObjects = new HashSet<GameObject>();
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
        List<GameObject> selectedObjectsList = SelectedObjects.ToList();
        for (int i = SelectedObjects.Count - 1; i >= 0; i--)
        {
            Deselect(selectedObjectsList[i]);
        }
    }
}
