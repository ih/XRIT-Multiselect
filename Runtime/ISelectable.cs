public interface ISelectable
{
    void OnSelect();
    void OnDeselect();

    void OnRightPrimaryActivate();

    void OnRightSecondaryActivate();

    string GetRightSecondaryLabel();
    
    string GetRightPrimaryLabel();
}