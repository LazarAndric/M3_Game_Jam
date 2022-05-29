using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UltimateSpellHolder : MonoBehaviour
{
    public static UltimateSpellHolder Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    [SerializeField]
    private List<UltimateSpell> UltimatesSpell = new List<UltimateSpell>();

    public Spell getUltimate(HeroClass HeroClass, HeroClass HeroClass1) {
        foreach (var item in UltimatesSpell)
        {
            if (item.Class == HeroClass && item.Class1 == HeroClass1)
                return item.Spell;
        }
        return null;
    }
}
