using UnityEngine;

public class BaseSelectable : MonoBehaviour, ISelectable
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void OnSelect()
    {
    }

    public void OnDeselect()
    {
    }

    public virtual void OnRightPrimaryActivate()
    {
    }

    public virtual void OnRightSecondaryActivate()
    {
    }

    public virtual string GetRightPrimaryLabel()
    {
        return "";
    }

    public virtual string GetRightSecondaryLabel()
    {
        return "";
    }
}