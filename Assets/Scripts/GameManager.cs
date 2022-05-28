using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Action ActivateUltimate;
    public int DistanceForUltimate;
    public Player Player1;
    public Player Player2;
    [Range(0,100)]
    public int Health;
    [Range(0, 100)]
    public int Shield;
    [Range(0, 100)]
    public int Energy;
    public static GameManager Instance;
    public Dictionary<HeroClass, Hero> ClassHeroPair = new Dictionary<HeroClass, Hero>();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

    }
    private void Update()
    {
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
    private void Start()
    {
        Player1.initPlayer(HeroClass.ADC);
        Player2.initPlayer(HeroClass.SUP);
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
    PASSIVE,
    ULTIMATE
}
public class Hero
{
    public string Name;
    public string Description;
    public Texture2D ClassIcon;

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
    public SpellType SpellType;
    public string Name;
    public string Description;
    public Texture2D SpellIcon;
    public int Damage;
    public int EnergyCost;
    public Spell(string name, string description, Texture2D spellIcon, int damage, int energyCost)
    {
        Name = name;
        Description = description;
        SpellIcon = spellIcon;
        Damage = damage;
        EnergyCost = energyCost;
    }
}
