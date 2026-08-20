using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMana : MonoBehaviour
{
    // “|‚µ‚½”
    [SerializeField] int Kill = 0;
    // o‚Å—ˆ‚é”
    [SerializeField] int Scren = 5;

    [SerializeField] GameObject BossObj;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Count()
    {

        Kill += 1;

        if(Kill >= Scren)
        {

            come();
        }

    }
    void come()
    {

       // Instantiate(BossObj, bossSpawnPos.position, Quaternion.identity);

    }
}
