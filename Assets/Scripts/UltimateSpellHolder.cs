using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateSpellHolder : MonoBehaviour
{
    [SerializeField]
    private List<UltimateSpell> UltimatesSpell = new List<UltimateSpell>();

    public UltimateSpell getUltimate(HeroClass HeroClass, HeroClass HeroClass1) => UltimatesSpell.Find(x => x.Class.Equals(HeroClass) && x.Class1.Equals(HeroClass1));
}
