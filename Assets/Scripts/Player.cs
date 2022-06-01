using System;
using UnityEngine;

[RequireComponent(typeof(Joystick))]
public class Player : MonoBehaviour
{
    public SpriteRenderer Sprite;
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
        Sprite.sprite = Hero.Sprite;
        Joystick.OnActive += pressActive;
        Joystick.OnUltimate += pressUltimate;
        Joystick.OnUpdateAxis += updatePosition;
        Joystick.OffUltimate += pressOffUltimate;
        Joystick.OnBasic += basicAttack;
    }

    private void basicAttack()
    {
        PlayAudio.Instance.basicAttack.Play();
        Fire.Instance.FireOn(Hero.BasicAttack.Type, Hero.BasicAttack.AoeRadius, Hero.BasicAttack.AoeDamage, Hero.BasicAttack.Sprite, transform.position, Vector2.up, 5);
        Debug.Log("Basic");
    }

    private void pressOffUltimate()
    {
        IsPressed = false;
    }

    //private void OnDisable()
    //{
    //    Joystick.OnActive -= pressActive;
    //    Joystick.OnUltimate -= pressUltimate;
    //    Joystick.OnUpdateAxis -= updatePosition;
    //    Joystick.OffUltimate += pressOffUltimate;
    //}

    private void updatePosition(Vector2 position)
    {
        Vector2 newV2 = new Vector2(transform.position.x, transform.position.y) + new Vector2(position.x, -position.y)* GameManager.Instance.MovemnetSpeed * Time.deltaTime;
        gameObject.transform.position = BoundingBox.Instance.IsItBound(newV2) ? newV2 : transform.position;
    }

    private void pressUltimate()
    {
        IsPressed = true;
    }

    public void pressActive()
    {
        if (GameManager.Instance.isEnoughEnergy(Hero.Active.Damage) && Hero.Class!=HeroClass.SUP)
        {
            Fire.Instance.FireOn(Hero.Active.Type, Hero.Active.AoeRadius, Hero.Active.AoeDamage, Hero.Active.Sprite, transform.position, Vector2.up, 5);
            Debug.Log("Abbility");
        }
        if(GameManager.Instance.isEnoughEnergy(Hero.Active.Damage) && Hero.Class == HeroClass.SUP)
        {
            GameManager.Instance.Shield +=Hero.Active.Sheild;
            GameManager.Instance.numberOfShield+=Hero.Active.Sheild;
            GameManager.Instance.Energy-=Hero.Active.EnergyCost;
            UiHandler.Instance.AddShield(1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy") && GameManager.Instance.isInit)
        {
            GameManager.Instance.removeLife();
            Destroy(collision.GetComponent<Enemy>().gameObject);
        }
    }

}
