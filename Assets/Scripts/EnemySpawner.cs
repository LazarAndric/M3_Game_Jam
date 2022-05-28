using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy Prefab;
    public Transform StartTranform;
    public Transform StopTransform;
    public float Timer=0;
    public float SpawnRate=5;
    public int Speed = 5;
    public Vector2 Direction;

    // Update is called once per frame
    void Update()
    {
        if (Timer > 0)
        {
            Timer-=Time.deltaTime;
        }
        else if(Timer < 0)
        {
            Timer = 0;
        }
        if(Timer==0)
        {
            Timer = SpawnRate;
            spawnEnemy();
        }    
    }
    public void spawnEnemy()
    {
        var firstRandom=Random.Range(0, 500);
        var secoundRandom=Random.Range(500, 1000);
        var random = (float)Random.Range(firstRandom, secoundRandom)/1000;
        var position=Vector2.Lerp(StartTranform.position, StopTransform.position, random);
        var item=Instantiate(Prefab);
        item.transform.position = position;
        item.initEnemy(Direction, Speed);
    }
}
