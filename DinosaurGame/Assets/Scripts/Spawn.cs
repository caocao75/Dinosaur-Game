using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject birdPrefab;
    public GameObject rockPrefab;
    public float starttime = 0f;
    public float spawnTime;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        spawnTime = Random.Range(6/PlayerControl.speedup, 10 / PlayerControl.speedup);
        Debug.Log(spawnTime);
        starttime += 1 * Time.deltaTime;
        if (starttime >= spawnTime)
        {
            int pick = Random.Range(1 , 3);
            if(pick ==1)
            {
                spawnbird();
            }
            else
            {
                spawnrock();
            }
            starttime = 0;
        }
    }
    void spawnbird()
    {
        
        GameObject bird = Instantiate(birdPrefab, new Vector2(transform.position.x, Random.Range(2f, 3f)), Quaternion.identity);
    }
    void spawnrock()
    {
        GameObject rock = Instantiate(rockPrefab, new Vector2(transform.position.x, 1), Quaternion.identity);
    }
}
