using UnityEngine;

public class XBoxController : Controller
{
    public int joystickId = 1;

    protected override bool IsActionPressed()
    {
        return Input.GetButtonDown("XBOX_" + joystickId + "_X");
    }

    protected override bool IsSecondaryActionPressed()
    {
        return Input.GetButtonDown("XBOX_" + joystickId + "_A");
    }

    protected override Vector2 ComputeMovement()
    {
        return new Vector2(Input.GetAxis("XBOX_" + joystickId + "_Horizontal"), Input.GetAxis("XBOX_" + joystickId + "_Vertical"));
    }
}
