using UnityEngine;

public class MenuControls : ControlBehavior
{
    public MenuControls()
    {
        action = KeyCode.Return;
        cancel = KeyCode.Backspace;
    }

    public void Update()
    {
        if (Input.GetKeyDown(action))
        {

        }
    }


}


