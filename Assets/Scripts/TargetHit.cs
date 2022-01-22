using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    [SerializeField] private Material materialTarget;
    ColorState statePattern = new ColorState(new Red());
    

    private void OnCollisionEnter(Collision collision)
    {
        materialTarget.color = statePattern.ChangeColor();
    }

}

interface IColor
{
    Color ChangeColor(ColorState colorState);
}

class Red : IColor
{

    Color IColor.ChangeColor(ColorState colorState)
    {
        colorState.color = new Blue();

        return Color.blue;
    }
}

class Blue : IColor
{

    Color IColor.ChangeColor(ColorState colorState)
    {
        colorState.color = new Green();

        return Color.green;
    }
}

class Green : IColor
{

    Color IColor.ChangeColor(ColorState colorState)
    {
        colorState.color = new Yellow();

        return Color.yellow;
    }
}

class Yellow : IColor
{

    Color IColor.ChangeColor(ColorState colorState)
    {
        colorState.color = new Red();

        return Color.red;
    }
}

class ColorState
{
    public IColor color;

    public ColorState(IColor color)
    {
        this.color = color;

    }

    public Color ChangeColor()
    {
        return color.ChangeColor(this);
    }

}
