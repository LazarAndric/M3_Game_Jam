using System.Collections.Generic;
using UnityEngine;

public class SpellHolder : MonoBehaviour
{
    [SerializeField]
    private List<Spell> Spells = new List<Spell>();
    [SerializeField]
    private Spell Ultimate;

    public Spell getSpell(SpellType type)=> Spells.Find(x=>x.SpellType.Equals(type));
}
