using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Action OnUpdateControl;
    private Joystick[] Joysticks;
    private void OnEnable()
    {
        Joysticks = FindObjectsOfType<Joystick>();
        for (int i = 0; i < Joysticks.Length; i++)
        {
            OnUpdateControl += Joysticks[i].updateJoystick;
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < Joysticks.Length; i++)
        {
            OnUpdateControl -= Joysticks[i].updateJoystick;
        }
    }
    private void Update()
    {
        OnUpdateControl?.Invoke();
    }
}
