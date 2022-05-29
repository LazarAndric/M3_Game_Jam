using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy Prefab;
    public Enemy Prefab2;
    public Enemy Prefab3;
    //public Enemy_hivemind_body Prefab_body_1;
    public Transform StartTranform;
    public Transform StopTransform;
    public float Timer=5;
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
            Timer = 0.4f;
            spawnEnemy();
        }    
    }
    public void spawnEnemy()
    {
        var coin = Random.Range(0, 3);
        Debug.Log(coin);
        if (coin == 0)
        {
            var firstRandom = Random.Range(0, 500);
            var secoundRandom = Random.Range(500, 1000);
            var random = (float)Random.Range(firstRandom, secoundRandom) / 1000;
            var position = Vector2.Lerp(StartTranform.position, StopTransform.position, random);
            var item = Instantiate(Prefab);
            item.transform.position = position;
            item.initEnemy(5, 10, Direction, Speed);
        }
        else if (coin == 1)
        {
            var firstRandom = Random.Range(0, 500);
            var secoundRandom = Random.Range(500, 1000);
            var random = (float)Random.Range(firstRandom, secoundRandom) / 1000;
            var position = Vector2.Lerp(StartTranform.position, StopTransform.position, random);
            var item = Instantiate(Prefab2);
            item.transform.position = position;
            item.initEnemy(20, 20, Direction, Speed);
        }
        else
        {
            var firstRandom = Random.Range(0, 500);
            var secoundRandom = Random.Range(500, 1000);
            var random = (float)Random.Range(firstRandom, secoundRandom) / 1000;
            var position = Vector2.Lerp(StartTranform.position, StopTransform.position, random);
            var item = Instantiate(Prefab3);
            item.transform.position = position;
            item.initEnemy(30, 80, Direction, Speed);
            /*
            var position_1 = Vector2.Lerp(StartTranform.position, StopTransform.position, random + 30);
            var item1 = Instantiate(Prefab_body_1);
            item.transform.position = position_1;
            item.initEnemy_hivemind_body(Direction, Speed);
            */
        }

    }
}
