using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGenerativeGraph : MonoBehaviour
{
    public long seed;
    public int[] seed_arr;

    // Start is called before the first frame update
    void Start()
    {
        seed = Generate_Seed();
        Debug.Log(seed);
        
        seed_arr = new int[seed.ToString().Length];
        for (int i = 0; i < seed_arr.Length; i++){
            seed_arr[i] = int.Parse(seed.ToString()[i].ToString());
        }


        Generate_Graph(seed_arr);
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

    static void Generate_Graph(int[] seed){
        GameObject graph = new GameObject("Level");
        GameObject start_node = new GameObject("Start Node");

        start_node.AddComponent<Node>();
        start_node.transform.parent = graph.transform; //make node a child

        List<GameObject> nodes = new List<GameObject>();
        nodes.Add(start_node);

        GameObject[,] map = new GameObject[17,17];
        map[9,9] = start_node;

        start_node.GetComponent<Node>().SetCoordinates(9,9);

        string debugString = "";

        for (int i = 0; i < 17; i++){
            for (int j = 0; j < 17; j++){
                if (map[i,j] == null){
                    debugString += " ";
                } else {
                    debugString += "0";
                }
            }
            debugString += "\n";
        }

        Debug.Log(debugString);


        //for(int i = 0; i < seed.Length; i++){
            nodes = CreateConnectedNodes(nodes[0], seed, 0, nodes);
        //}
    }

    static List<GameObject> CreateConnectedNodes(GameObject current_node, int[] seed, int seed_digit, List<GameObject> nodes){
        Debug.Log(seed[seed_digit]);
        if(current_node.name == "Start Node"){
            current_node.GetComponent<Node>().SetRoomType(-1);
            GameObject east_node = new GameObject("East");
            GameObject south_node = new GameObject("South");
            GameObject west_node = new GameObject("West");

            switch (seed[seed_digit]){
                case 1:
                case 7:
                    east_node.AddComponent<Node>();
                    east_node.transform.parent = current_node.transform;
                    east_node.GetComponent<Node>().SetName(east_node.name);
                    east_node.GetComponent<Node>().SetEntrance(current_node);                    

                    current_node.GetComponent<Node>().SetExit(east_node, east_node.name);
                    current_node.GetComponent<Node>().SetEastExit(east_node);

                    nodes.Add(east_node);

                    Destroy(south_node);
                    Destroy(west_node);
                    break;
                case 2:
                case 8:
                    south_node.AddComponent<Node>();
                    south_node.transform.parent = current_node.transform;
                    south_node.GetComponent<Node>().SetName(south_node.name);
                    south_node.GetComponent<Node>().SetEntrance(current_node);

                    current_node.GetComponent<Node>().SetExit(south_node, south_node.name);
                    current_node.GetComponent<Node>().SetSouthExit(south_node);

                    nodes.Add(south_node);

                    Destroy(east_node);
                    Destroy(west_node);
                    break;
                case 3:
                case 9:
                    west_node.AddComponent<Node>();
                    west_node.transform.parent = current_node.transform;
                    west_node.GetComponent<Node>().SetName(west_node.name);
                    west_node.GetComponent<Node>().SetEntrance(current_node);

                    current_node.GetComponent<Node>().SetExit(west_node, west_node.name);
                    current_node.GetComponent<Node>().SetWestExit(west_node);

                    nodes.Add(west_node);

                    Destroy(east_node);
                    Destroy(south_node);
                    break;
                case 4:
                    east_node.AddComponent<Node>();
                    east_node.transform.parent = current_node.transform;
                    east_node.GetComponent<Node>().SetName(east_node.name);
                    east_node.GetComponent<Node>().SetEntrance(current_node);

                    current_node.GetComponent<Node>().SetExit(east_node, east_node.name);
                    current_node.GetComponent<Node>().SetEastExit(east_node);

                    nodes.Add(east_node);
                    
                    south_node.AddComponent<Node>();
                    south_node.transform.parent = current_node.transform;
                    south_node.GetComponent<Node>().SetName(south_node.name);
                    south_node.GetComponent<Node>().SetEntrance(current_node);                    

                    current_node.GetComponent<Node>().SetExit(south_node, south_node.name);
                    current_node.GetComponent<Node>().SetSouthExit(south_node);

                    nodes.Add(south_node);

                    Destroy(west_node);
                    break;
                case 5:
                    south_node.AddComponent<Node>();
                    south_node.transform.parent = current_node.transform;
                    south_node.GetComponent<Node>().SetName(south_node.name);
                    south_node.GetComponent<Node>().SetEntrance(current_node);                    

                    current_node.GetComponent<Node>().SetExit(south_node, south_node.name);
                    current_node.GetComponent<Node>().SetSouthExit(south_node);

                    nodes.Add(south_node);

                    west_node.AddComponent<Node>();
                    west_node.transform.parent = current_node.transform;
                    west_node.GetComponent<Node>().SetName(west_node.name);
                    west_node.GetComponent<Node>().SetEntrance(current_node);                    

                    current_node.GetComponent<Node>().SetExit(west_node, west_node.name);
                    current_node.GetComponent<Node>().SetWestExit(west_node);

                    nodes.Add(west_node);

                    Destroy(east_node);
                    break;
                case 6:
                    east_node.AddComponent<Node>();
                    east_node.transform.parent = current_node.transform;
                    east_node.GetComponent<Node>().SetName(east_node.name);
                    east_node.GetComponent<Node>().SetEntrance(current_node);                    

                    current_node.GetComponent<Node>().SetExit(east_node, east_node.name);
                    current_node.GetComponent<Node>().SetEastExit(east_node);

                    nodes.Add(east_node);

                    south_node.AddComponent<Node>();
                    south_node.transform.parent = current_node.transform;
                    south_node.GetComponent<Node>().SetName(south_node.name);
                    south_node.GetComponent<Node>().SetEntrance(current_node);

                    current_node.GetComponent<Node>().SetExit(south_node, south_node.name);
                    current_node.GetComponent<Node>().SetSouthExit(south_node);

                    nodes.Add(south_node);

                    west_node.AddComponent<Node>();
                    west_node.transform.parent = current_node.transform;
                    west_node.GetComponent<Node>().SetName(west_node.name);
                    west_node.GetComponent<Node>().SetEntrance(current_node);

                    current_node.GetComponent<Node>().SetExit(west_node, west_node.name);
                    current_node.GetComponent<Node>().SetWestExit(west_node);
                    
                    nodes.Add(west_node);
                    break;
            }

        } 
        //else if(seed_digit == 0){

        //     current_node.GetComponent<Node>().SetRoomType(0);

        // } else if(seed_digit == 4){
            
        //     current_node.GetComponent<Node>().SetRoomType(4);
        
        // } else if(seed_digit == 8){
        
        //     current_node.GetComponent<Node>().SetRoomType(5);
        
        // } else if(seed_digit % 4 == 1){

        //     GameObject node = new GameObject();

        //     current_node.GetComponent<Node>().SetRoomType(1);

        //     if (seed[seed_digit] == 1 && seed[seed_digit-1] < 7){ 
        //         node.name = LeftDirection(current_node.name);
        //     } else if ((seed[seed_digit] == 1 && seed[seed_digit-1] >= 7) | (seed[seed_digit] == 5 && seed[seed_digit-1] <= 3)){
        //         node.name = current_node.name;
        //     } else{
        //         node.name = RightDirection(current_node.name);
        //     }

        //     if (seed_digit < 2){
        //         node.AddComponent<Node>();
        //         node.transform.parent = current_node.transform;
        //         node.GetComponent<Node>().SetEntranceDirection(OppositeDirection(node.name));

        //         nodes.Add(node);
        //     } else{
        //         if (true){ 
        //             node.AddComponent<Node>();
        //             node.transform.parent = current_node.transform;
        //             node.GetComponent<Node>().SetEntranceDirection(OppositeDirection(node.name));

        //             nodes.Add(node);
        //         }
        //     }
        
        // } else if(seed_digit % 4 == 2){
        
        //     current_node.GetComponent<Node>().SetRoomType(2);

        //     GameObject node1 = new GameObject();
        //     GameObject node2 = new GameObject();

        //     if (seed[seed_digit] == 2 && seed[seed_digit-1] < 7){ 
        //         node1.name = LeftDirection(current_node.name);
        //         node2.name = current_node.name;
        //     } else if ((seed[seed_digit] == 2 && seed[seed_digit-1] >= 7) | (seed[seed_digit] == 6 && seed[seed_digit-1] <= 3)){
        //         node1.name = current_node.name;
        //         node2.name = RightDirection(current_node.name);
        //     } else{
        //         node1.name = LeftDirection(current_node.name);
        //         node2.name = RightDirection(current_node.name);
        //     }

        //     node1.AddComponent<Node>();
        //     node1.transform.parent = current_node.transform;
        //     node1.GetComponent<Node>().SetEntranceDirection(OppositeDirection(node1.name));

        //     nodes.Add(node1);

        //     node2.AddComponent<Node>();
        //     node2.transform.parent = current_node.transform;
        //     node2.GetComponent<Node>().SetEntranceDirection(OppositeDirection(node2.name));        

        //     nodes.Add(node2);   
        

        // } else if(seed_digit % 4 == 3){

        //     GameObject node1 = new GameObject();
        //     GameObject node2 = new GameObject();
        //     GameObject node3 = new GameObject();
        
        //     current_node.GetComponent<Node>().SetRoomType(3);

        //     node1.AddComponent<Node>();
        //     node1.name = LeftDirection(current_node.name);
        //     node1.transform.parent = current_node.transform;
        //     node1.GetComponent<Node>().SetEntranceDirection(OppositeDirection(node1.name));

        //     nodes.Add(node1);

        //     node2.AddComponent<Node>();
        //     node2.name = current_node.name;
        //     node2.transform.parent = current_node.transform;
        //     node2.GetComponent<Node>().SetEntranceDirection(OppositeDirection(node1.name));

        //     nodes.Add(node2);

        //     node3.AddComponent<Node>();
        //     node3.name = RightDirection(current_node.name);
        //     node3.transform.parent = current_node.transform;
        //     node3.GetComponent<Node>().SetEntranceDirection(OppositeDirection(node1.name));

        //     nodes.Add(node3);
        
        // }

        current_node.GetComponent<Node>().SetAssignedSeedDigit(seed[seed_digit]);

        nodes.RemoveAt(0);

        return nodes;
    }

    static string OppositeDirection(string original_direction){
        switch(original_direction){
            case "North":
                return "South";
            case "East":
                return "West";
            case "South":
                return "North";
            case "West":
                return "East";
            default:
                return "";
        }
    }

    static string RightDirection(string original_direction){
        switch(original_direction){
            case "North":
                return "East";
            case "East":
                return "South";
            case "South":
                return "West";
            case "West":
                return "North";
            default:
                return "";
        }
    }

    static string LeftDirection(string original_direction){
        switch(original_direction){
            case "North":
                return "West";
            case "East":
                return "North";
            case "South":
                return "East";
            case "West":
                return "South";
            default:
                return "";
        }
    }
}
