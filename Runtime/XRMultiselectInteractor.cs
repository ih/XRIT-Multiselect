using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class XRMultiselectInteractor : XRDirectInteractor
{
    public InputAction trigger;
    [SerializeField]
    SelectManager _selectManager;
    bool _isSelecting;

    protected override void OnEnable()
    {
        base.OnEnable();
        trigger.Enable();
        trigger.started += OnTriggerPress;
        trigger.canceled += OnTriggerRelease;
    }

    private void OnTriggerRelease(InputAction.CallbackContext obj)
    {
        OnTriggerRelease(); 
    }

    private void OnTriggerPress(InputAction.CallbackContext obj)
    {
        OnTriggerPress(); 
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        trigger.Disable();
        OnTriggerRelease(default);
        trigger.started -= OnTriggerPress;
        trigger.canceled -= OnTriggerRelease;
    }
    
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
        // enabled = true;
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
                _selectManager.Select(((XRBaseInteractable)hoveredObject).gameObject);
            }

        }
    }

    public void OnTriggerRelease()
    {
        _isSelecting = false;
        // enabled = false;
        GetComponent<Renderer>().enabled = false;
    }
}