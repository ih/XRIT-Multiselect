using System;
using TreeEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class XRMultiselectInteractor : MonoBehaviour 
{
    public InputAction trigger;

    [SerializeField] private SelectManager _selectManager;

    private bool _isSelecting;


    [SerializeField]
    private float _selectorRadius;

    protected void OnEnable()
    {
        trigger.Enable();
        trigger.started += OnTriggerPress;
        trigger.canceled += OnTriggerRelease;
    }

    protected void OnDisable()
    {
        trigger.Disable();
        OnTriggerRelease(default);
        trigger.started -= OnTriggerPress;
        trigger.canceled -= OnTriggerRelease;
    }

    private void OnTriggerRelease(InputAction.CallbackContext obj)
    {
        OnTriggerRelease();
    }

    private void OnTriggerPress(InputAction.CallbackContext obj)
    {
        OnTriggerPress();
    }

    private void Awake()
    {
        _selectorRadius = GetComponent<SphereCollider>().radius * transform.localScale.x;
    }

    private void Update()
    {
        if (_isSelecting)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _selectorRadius);
            foreach (Collider collider in colliders)
            {
                ISelectable selectable = collider.GetComponent<ISelectable>();
                if (selectable != null)
                {
                    _selectManager.Select(collider.gameObject); 
                }
            }
        }
    }

    public void OnTriggerPress()
    {
        GetComponent<Renderer>().enabled = true;
        _isSelecting = true;
        int hoverCount = 0;
        Collider[] colliders = Physics.OverlapSphere(transform.position, _selectorRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.GetComponent<BaseSelectable>())
            {
                hoverCount += 1;
            }
        } 
        if (hoverCount == 0)
            _selectManager.Clear();
    }

    public void OnTriggerRelease()
    {
        _isSelecting = false;
        GetComponent<Renderer>().enabled = false;
    }
}