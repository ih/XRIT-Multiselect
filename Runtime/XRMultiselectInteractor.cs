using System;
using System.Collections;
using System.Collections.Generic;
using AbstractionMachines;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRMultiselectInteractor : XRDirectInteractor
{
    [SerializeField] private SelectManager _selectManager;
    private bool _isSelecting;
    
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        if (_isSelecting)
        {
            _selectManager.Select(args.interactableObject.transform.gameObject);           
        }
    }

    public void OnTriggerPress()
    {
        enabled = true;
        GetComponent<Renderer>().enabled = true; 
        _isSelecting = true;
        if (interactablesHovered.Count == 0)
        {
            _selectManager.Clear();
        }
        else
        {
            foreach (IXRHoverInteractable hoveredObject in interactablesHovered)
            {
                _selectManager.Select(((XRBaseInteractable) hoveredObject).gameObject);               
            }

        }
    }

    public void OnTriggerRelease()
    {
        _isSelecting = false;
        enabled = false;
        GetComponent<Renderer>().enabled = false;
    }
}