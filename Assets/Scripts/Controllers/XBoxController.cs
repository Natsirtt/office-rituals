using UnityEngine;

public class XBoxController : Controller {
    protected override bool IsActionPressed()
    {
        return Input.GetButtonDown("XBOX_X");
    }

    protected override Vector2 ComputeMovement()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
