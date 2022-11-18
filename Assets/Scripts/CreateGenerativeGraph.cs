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
        
        Generate_Graph(seed);
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

    static void Generate_Graph(long seed){
        GameObject graph = new GameObject("Level");
        GameObject start_node = new GameObject("Start Node");
        start_node.AddComponent<Node>();
        start_node.transform.parent = graph.transform; //make node a child
        CreateNodes(start_node, int.Parse(seed.ToString()[0].ToString()));
    }

    static void CreateNodes(GameObject parent, int seed_digit){
        if(parent.name == "Start Node"){
            parent.GetComponent<Node>().SetRoomType(-1);
            GameObject east_node = new GameObject("East Node");
            GameObject south_node = new GameObject("South Node");
            GameObject west_node = new GameObject("West Node");

            switch (seed_digit){
                case 1:
                case 7:
                    east_node.AddComponent<Node>();
                    east_node.transform.parent = parent.transform;
                    east_node.GetComponent<Node>().SetEntranceDirection("West");

                    Destroy(south_node);
                    Destroy(west_node);
                    break;
                case 2:
                case 8:
                    south_node.AddComponent<Node>();
                    south_node.transform.parent = parent.transform;
                    south_node.GetComponent<Node>().SetEntranceDirection("North");

                    Destroy(east_node);
                    Destroy(west_node);
                    break;
                case 3:
                case 9:
                    west_node.AddComponent<Node>();
                    west_node.transform.parent = parent.transform;
                    west_node.GetComponent<Node>().SetEntranceDirection("West");

                    Destroy(east_node);
                    Destroy(south_node);
                    break;
                case 4:
                    east_node.AddComponent<Node>();
                    east_node.transform.parent = parent.transform;
                    east_node.GetComponent<Node>().SetEntranceDirection("West");
                    
                    south_node.AddComponent<Node>();
                    south_node.transform.parent = parent.transform;
                    south_node.GetComponent<Node>().SetEntranceDirection("North");

                    Destroy(west_node);
                    break;
                case 5:
                    south_node.AddComponent<Node>();
                    south_node.transform.parent = parent.transform;
                    south_node.GetComponent<Node>().SetEntranceDirection("North");

                    west_node.AddComponent<Node>();
                    west_node.transform.parent = parent.transform;
                    west_node.GetComponent<Node>().SetEntranceDirection("East");

                    Destroy(east_node);
                    break;
                case 6:
                    east_node.AddComponent<Node>();
                    east_node.transform.parent = parent.transform;
                    east_node.GetComponent<Node>().SetEntranceDirection("West");

                    south_node.AddComponent<Node>();
                    south_node.transform.parent = parent.transform;
                    south_node.GetComponent<Node>().SetEntranceDirection("North");

                    west_node.AddComponent<Node>();
                    west_node.transform.parent = parent.transform;
                    west_node.GetComponent<Node>().SetEntranceDirection("East");
                    break;
            }

        } else if(seed_digit == 9){
            parent.GetComponent<Node>().SetRoomType(9);
        } else if(seed_digit == 0){
            parent.GetComponent<Node>().SetRoomType(0);
        } else if(seed_digit % 4 == 0){
            parent.GetComponent<Node>().SetRoomType(4);
        } else if(seed_digit % 4 == 1){
            parent.GetComponent<Node>().SetRoomType(1);
        } else if(seed_digit % 4 == 2){
            parent.GetComponent<Node>().SetRoomType(2);
        } else if(seed_digit % 4 == 3){
            parent.GetComponent<Node>().SetRoomType(3);
        }
    }
}
