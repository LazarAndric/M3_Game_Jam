using System;
using UnityEngine;

[RequireComponent(typeof(Joystick))]
public class Player : MonoBehaviour
{
    private SpellHolder SpellHolder;
    public bool IsPressed;
    private Hero Hero;
    private Joystick Joystick;
    private void Awake()
    {
        Joystick = GetComponent<Joystick>();
        SpellHolder = GetComponent<SpellHolder>();
    }
    public void initPlayer(Hero hero)
    {
        Hero = hero;
        Joystick.OnActive += pressActive;
        Joystick.OnUltimate += pressUltimate;
        Joystick.OnUpdateAxis += updatePosition;
    }
    private void OnDisable()
    {
        Joystick.OnActive -= pressActive;
        Joystick.OnUltimate -= pressUltimate;
        Joystick.OnUpdateAxis -= updatePosition;
    }

    private void updatePosition(Vector2 position)
    {
        var newV2 = gameObject.transform.position + new Vector3(position.x, -position.y) * Time.deltaTime;

        gameObject.transform.position = BoundingBox.Instance.IsItBound(newV2) ? newV2 : gameObject.transform.position;
    }

    private void pressUltimate()
    {
        IsPressed = true;
    }

    public void pressActive()
    {
        if (GameManager.Instance.isEnoughEnergy(Hero.Active.Damage))
        {
            Debug.Log("Abbility");
        }
    }

}
