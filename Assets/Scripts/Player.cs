using System;
using UnityEngine;

[RequireComponent(typeof(Joystick))]
public class Player : MonoBehaviour
{
    private Hero Hero;
    private Joystick Joystick;
    private void Awake()
    {
        Joystick = GetComponent<Joystick>();
    }
    public void initPlayer(HeroClass hClass)
    {
        Hero.Active = SpellHolder.Instance.getSpell(SpellType.ACTIVE, hClass);
        Hero.Passive = SpellHolder.Instance.getSpell(SpellType.PASSIVE, hClass);
        Hero.Ultimate = SpellHolder.Instance.getSpell(SpellType.ULTIMATE, hClass);
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
        Debug.Log("Ultimate");
    }

    public void pressActive()
    {
        if (GameManager.Instance.isEnoughEnergy(Hero.Active.Damage))
        {
            Hero.castSpell(Hero.Active);
        }
        Debug.Log("Abbility");
    }

}
