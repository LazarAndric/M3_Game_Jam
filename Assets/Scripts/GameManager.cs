using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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
    public List<Spell> Spells = new List<Spell>();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;


    }
    private void Start()
    {
    }
    public bool isEnoughEnergy(int energy)
    {
        return Energy >= energy;
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
    ACTIVE,
    PASSIVE,
    ULTIMATE
}
public class Hero
{
    public string Name;
    public string Description;
    public Texture2D ClassIcon;


    public Spell Passive;
    public Spell Active;
    public Spell Ultimate;

    public Hero(string name, string description, Texture2D classIcon, Spell passive, Spell active, Spell ultimate)
    {
        Name = name;
        Description = description;
        ClassIcon = classIcon;
        Passive = passive;
        Active = active;
        Ultimate = ultimate;
    }
    public void castSpell(Spell spell)
    {
    }
}
[System.Serializable]
public class Spell
{
    public HeroClass HeroClass;
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
