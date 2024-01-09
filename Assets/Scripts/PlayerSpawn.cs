using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        int randX = Random.Range(1, 21);
        int randZ = Random.Range(1, 21);

        int x = randX - 11;
        int z = randZ - 11;

        Instantiate(Player, new Vector3(x, 0, z), Quaternion.identity);
    }
}
