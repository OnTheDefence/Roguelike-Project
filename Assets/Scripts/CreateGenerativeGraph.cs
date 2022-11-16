using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGenerativeGraph : MonoBehaviour
{
    public long seed;

    // Start is called before the first frame update
    void Start()
    {
        seed = Generate_Seed();
        Debug.Log(seed);
        
        Graph g1 = new Graph();

    }

    static long Generate_Seed(){
        // Max Rules of between 7 and 14 currently
        System.Random rnd = new System.Random();
        int seed_bottom = 1;
        int seed_top = 10;
        int seed_length = rnd.Next(7, 14);

        for(int i = 0; i < System.Math.Floor((double)(seed_length/2))-1; i++){
            seed_bottom = seed_bottom * 10;
            seed_top = seed_top * 10;
        }
        seed_top -= 1;

        // Generate two halves of the seed and concatenate together

        int seed_first = rnd.Next(seed_bottom, seed_top);
        int seed_second = 0;
        if (seed_length % 2 == 0){
            seed_second = rnd.Next(seed_bottom, seed_top);
        }
        else{
            seed_second = rnd.Next(seed_bottom*10, (seed_top+1)*10);
        }

        long seed = long.Parse(seed_first.ToString() + seed_second.ToString());

        return seed;
    }
}
