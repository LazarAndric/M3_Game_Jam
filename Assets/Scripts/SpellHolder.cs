using System.Collections.Generic;
using UnityEngine;

public class SpellHolder : MonoBehaviour
{
    [SerializeField]
    private List<SpellsAbillity> Spells = new List<SpellsAbillity>();

    public Spell getSpell(SpellType type)=> Spells.Find(x=>x.SpellType.Equals(type)).Spell;
}
