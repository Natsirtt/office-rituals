using UnityEngine;

public class XBoxController : Controller
{
    public int joystickId = 1;

    public static string ActionPressedDescriptor(int joyId)
    {
        return "XBOX_" + joyId + "_X";
    }

    public static string SecondaryActionPressedDescriptor(int joyId)
    {
        return "XBOX_" + joyId + "_A";
    }

    public static string HorizontalAxisDescriptor(int joyId) {
        return "XBOX_" + joyId + "_Horizontal";
    }

    public static string VerticalAxisDescriptor(int joyId) {
        return "XBOX_" + joyId + "_Vertical";
    }

    protected override bool IsActionPressed()
    {
        return Input.GetButtonDown(ActionPressedDescriptor(joystickId));
    }

    protected override bool IsSecondaryActionPressed()
    {
        return Input.GetButtonDown(SecondaryActionPressedDescriptor(joystickId));
    }

    protected override Vector2 ComputeMovement()
    {
        var v = new Vector2(Input.GetAxis(HorizontalAxisDescriptor(joystickId)), -Input.GetAxis(VerticalAxisDescriptor(joystickId)));
        //if (Mathf.Abs(v.x) > 0.01f || Mathf.Abs(v.y) > 0.01f)
        //{
        //    Debug.Log("Joystick " + joystickId + " " + v);
        //}
        return v;
    }
}
