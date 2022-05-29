using System;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Action OnBasic;
    public Action OnUltimate;
    public Action OffUltimate;
    public Action OnActive;
    public Action<Vector2> OnUpdateAxis;

    [SerializeField]
    private KeyCode BasicAttack;
    [SerializeField]
    private KeyCode Active;
    [SerializeField]
    private KeyCode Ultimate;
    [SerializeField]
    private string AxisHorizontal;
    [SerializeField]
    private string AxisVertical;

    public void updateJoystick()
    {
        if (Input.GetKeyDown(BasicAttack))
        {
            OnBasic?.Invoke();
        }
        else if (Input.GetKeyDown(Active))
        {
            OnActive?.Invoke();
        }
        else if (Input.GetKeyDown(Ultimate))
        {
            OnUltimate?.Invoke();
        }
        else if (Input.GetKeyUp(Ultimate))
        {
            OffUltimate?.Invoke();
        }
        var x=Input.GetAxis(AxisHorizontal);
        var y=Input.GetAxis(AxisVertical);
        OnUpdateAxis?.Invoke(new Vector2(x, y));


    }
}
