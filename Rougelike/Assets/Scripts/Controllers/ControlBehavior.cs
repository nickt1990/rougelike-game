using UnityEngine;

public abstract class ControlBehavior : MonoBehaviour
{
    public KeyCode action = KeyCode.Return;
    public KeyCode cancel = KeyCode.Backspace;

    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

}

public class PlayerControls : ControlBehavior
{
    public PlayerControls()
    {

    }
}


