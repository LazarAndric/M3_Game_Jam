using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UltimateSpellHolder))]
public class GameManager : MonoBehaviour
{
    public Action ActivateUltimate;
    public int DistanceForUltimate;
    public Player Player1;
    public Player Player2;
    [Range(0,6)]
    public int Life;
    [Range(0, 2)]
    public int Shield;
    public int Score;
    [Range(0, 100)]
    public int Energy;
    [Range(0, 10)]
    public int MovemnetSpeed;
    public static GameManager Instance;
    public List<Hero> Heroes = new List<Hero>();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

    }
    private void Start()
    {
        initPlayers(5,3,Heroes[0], Heroes[1]);
    }
    private void Update()
    {
        if(Life<=0)
        {
            die();
        }
        if(Energy==100 && Player1.IsPressed && Player2.IsPressed)
        {
            if(Vector2.Distance(Player1.transform.position, Player2.transform.position) < DistanceForUltimate)
            {
                Energy = 0;
                Debug.Log("Ultimate");
                Player1.IsPressed = false;
                Player2.IsPressed = false;
            }
        }
    }

    private void die()
    {
        Time.timeScale = 0;
        Debug.Log("you are dead!");
    }

    public void initPlayers(int speed, int lifes, Hero heroClass, Hero heroClass1)
    {
        MovemnetSpeed = speed;
        Life = lifes;
        Life += heroClass.Passive.ExtraLife + heroClass.Passive.ExtraLife;
        Energy += heroClass.Passive.Energy + heroClass.Passive.Energy;
        UiHandler.Instance.AddLife(Life);
        MovemnetSpeed += heroClass.Passive.MovementSpeed + heroClass1.Passive.MovementSpeed;
        Shield = heroClass.Passive.Sheild + heroClass1.Passive.Sheild;
        if (Shield != 0)
            UiHandler.Instance.AddShield(Shield);

        Player1.initPlayer(heroClass);
        Player2.initPlayer(heroClass1);
    }
    public bool isEnoughEnergy(int energy)
    {
        bool isEnough = false;
        if (Energy >= energy)
        {
            Energy -= energy;
            isEnough = true;
        }
        return isEnough;
    }
}
public enum HeroClass
{
    ADC,
    SUP,
    TANK
}
public enum SpellType
{
    BASIC_ATTACK,
    ACTIVE,
    PASSIVE
}
[System.Serializable]
public class Hero
{
    public string Name;
    public string Description;
    public Texture2D ClassIcon;
    public Sprite Sprite;

    public Spell BasicAttack;
    public Spell Passive;
    public Spell Active;

    public Hero(string name, string description, Texture2D classIcon,Spell BasicAttack, Spell passive, Spell active)
    {
        Name = name;
        Description = description;
        ClassIcon = classIcon;
        Passive = passive;
        Active = active;
    }
}
[System.Serializable]
public class Spell
{
    public string Name;
    public string Description;
    public Texture2D SpellIcon;
    public Bullet Sprite;
    public int Damage;
    public int EnergyCost;
    public int Energy;
    public int Sheild;
    public int MovementSpeed;
    public int ExtraLife;
    public int Collider;

    public Spell(int movementSpeed, string name, string description, Texture2D spellIcon, int damage, int energyCost, int shield, int extraLife)
    {
        ExtraLife = extraLife;
        MovementSpeed = movementSpeed;
        Sheild = shield;
        Name = name;
        Description = description;
        SpellIcon = spellIcon;
        Damage = damage;
        EnergyCost = energyCost;
    }
}
