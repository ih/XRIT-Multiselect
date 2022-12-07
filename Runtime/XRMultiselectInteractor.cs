using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRMultiselectInteractor : XRDirectInteractor
{
    [SerializeField] private SelectManager _selectManager;
    
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        Debug.Log("Entered a selectable!");
        _selectManager.Select(args.interactableObject.transform.gameObject);
    }
}
