using System.Collections.Generic;
using UnityEngine;

public class SpellHolder : MonoBehaviour
{
    public static SpellHolder Instance;
    private void Awake()
    {
        if(Instance==null)
            Instance = this;
    }
    [SerializeField]
    private List<SpellsAbillity> Spells = new List<SpellsAbillity>();

    public Spell getSpell(SpellType type, HeroClass hClass)=> Spells.Find(x=>x.SpellType.Equals(type) && x.Class.Equals(hClass)).Spell;
}
