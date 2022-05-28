using System.Collections.Generic;
using UnityEngine;

public class SpellHolder : MonoBehaviour
{
    public static SpellHolder Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    [SerializeField]
    private List<Spell> Spells = new List<Spell>();

    public Spell getSpell(SpellType type, HeroClass hClass)=> Spells.Find(x => x.HeroClass.Equals(hClass) && x.SpellType.Equals(type));
}
