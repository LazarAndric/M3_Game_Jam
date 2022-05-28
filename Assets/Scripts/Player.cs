using System;
using UnityEngine;

[RequireComponent(typeof(Joystick))]
[RequireComponent(typeof(SpellHolder))]
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
    public void initPlayer(HeroClass hClass)
    {
        var active= SpellHolder.getSpell(SpellType.ACTIVE);
        var passive = SpellHolder.getSpell(SpellType.PASSIVE);
        var basic = SpellHolder.getSpell(SpellType.BASIC_ATTACK);
        Hero = new Hero("ASD", "asdf", new Texture2D(20, 20), basic, passive, active);
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
