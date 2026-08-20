using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hantei : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static class GameResult
    {
        public static bool isClear;
        public static bool isGameOver;

        public static void Reset()
        {
            isClear = false;
            isGameOver = false;
        }
    }

}
