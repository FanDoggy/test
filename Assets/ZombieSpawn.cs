using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public GameObject zombiePrefab;
    public float timer;
    public float spawnInterval;
    private Transform spot;
    private int temp;
    private int zombieIndex=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnInterval)
        {
            temp = Random.Range(1, 6);
            spot= gameObject.transform.Find("spot" + temp.ToString());
            timer = 0;
            GameObject zombie = Instantiate(zombiePrefab, spot);
            zombie.GetComponent<SpriteRenderer>().sortingOrder = zombieIndex;
            zombieIndex += 1;
        }
    }
}
