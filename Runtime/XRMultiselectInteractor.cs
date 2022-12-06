using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRMultiselectInteractor : XRDirectInteractor
{
    [SerializeField] private GameObject pointer;
    
    protected void ActivatePointer()
    {
       pointer.SetActive(true); 
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        Debug.Log("Entered a selectable!");
    }
}
