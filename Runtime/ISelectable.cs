public interface ISelectable
{
    void OnSelect();
    void OnDeselect();

    void OnRightPrimaryActivate();

    void OnRightSecondaryActivate();

    string GetRightSecondaryLabel();
    
    string GetRightPrimaryLabel();

    public void OnRightThumbstickRight()
    {
        
    }
    
    public void OnRightThumbstickLeft()
    {
            
    }
    
    public void OnRightThumbstickUp()
    {
                
    }
    
    public void OnRightThumbstickDown()
    {
                
    }
}