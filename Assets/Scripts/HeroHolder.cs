using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHolder : MonoBehaviour
{
    public static HeroHolder Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public List<Hero> Heroes = new List<Hero>();

    public Hero getHero(int i)
    {
        return Heroes[i];
    }
}
