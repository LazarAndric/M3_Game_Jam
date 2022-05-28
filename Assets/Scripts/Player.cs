using System;
using UnityEngine;

[RequireComponent(typeof(Joystick))]
public class Player : MonoBehaviour
{
    public bool IsPressed;
    private Hero Hero;
    private Joystick Joystick;
    private void Awake()
    {
        Joystick = GetComponent<Joystick>();
    }
    public void initPlayer(HeroClass hClass)
    {
        var active= SpellHolder.Instance.getSpell(SpellType.ACTIVE, hClass);
        var passive = SpellHolder.Instance.getSpell(SpellType.PASSIVE, hClass);
        Hero = new Hero("ASD", "asdf", new Texture2D(20, 20), active, passive);
        //SpellHolder.Instance.getSpell(SpellType.ULTIMATE, hClass);
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
        gameObject.transform.position += new Vector3(position.x, -position.y) * Time.deltaTime;
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
