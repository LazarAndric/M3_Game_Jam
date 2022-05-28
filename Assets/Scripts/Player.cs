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
        Joystick.OffUltimate += pressOffUltimate;
    }

    private void pressOffUltimate()
    {
        IsPressed = false;
    }

    private void OnDisable()
    {
        Joystick.OnActive -= pressActive;
        Joystick.OnUltimate -= pressUltimate;
        Joystick.OnUpdateAxis -= updatePosition;
        Joystick.OffUltimate += pressOffUltimate;
    }

    private void updatePosition(Vector2 position)
    {
        Vector2 newV2 = new Vector2(transform.position.x, transform.position.y) + position;
        gameObject.transform.position = BoundingBox.Instance.IsItBound(newV2) ? newV2 : transform.position;
    }

    private void pressUltimate()
    {
        IsPressed = true;
    }

    public void pressActive()
    {
        if (GameManager.Instance.isEnoughEnergy(Hero.Active.Damage))
        {
            Fire.Instance.FireOn(transform, Vector2.up, 5);
            Debug.Log("Abbility");
        }
    }

}
