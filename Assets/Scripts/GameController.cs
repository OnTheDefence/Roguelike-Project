using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    private GameObject current_node;
    private GameObject player;
    private GameObject enemies;
    private GameObject main_camera;
    private GameObject sprites;
    private GameObject gate;

    System.Random rnd = new System.Random();

    [SerializeField] private bool level_clear = false;
    private string[] directions = {"north", "east", "south", "west"};
    private string[] gate_names = {"", "", "", ""};
    private bool[,] enemy_spawn_spot = {{true,true,true},{true,true,true},{true,true,true}};

    
    void Awake()
    {
        player = GameObject.Find("Player");
        current_node = GameObject.Find("Start Node");
        enemies = GameObject.Find("Enemies");
        main_camera = GameObject.Find("Main Camera");
        main_camera.transform.position = new Vector3(current_node.transform.position.x, current_node.transform.position.y, -10);

        

        for (int i = 0; i < 4; i++){
            gate_names[i] = directions[i] + "_door_gate";
        }
    }

    
    void FixedUpdate()
    {
        if(enemies.transform.childCount == 0 && level_clear == false){
            sprites = GetChildWithName(current_node, "Sprites");

            gate = null;

            for (int i = 0; i < 4; i++){
                gate = GetChildWithName(sprites, gate_names[i]);
                if (gate != null){
                    Destroy(gate);
                }
            }

            if (current_node.GetComponent<Node>().RoomCompleted() == false && current_node.name != "Start Node"){
                int potion_drop = rnd.Next(1,6);
                if(potion_drop == 5){
                    int potion_type = rnd.Next(0,3);

                    switch(potion_type){
                        case 0:
                            GameObject healthUp = Instantiate(Resources.Load("Prefab/HealthUp") as GameObject);
                            healthUp.name = "DamageUp";
                            healthUp.transform.position = current_node.transform.position;
                            break;
                        case 1:
                            GameObject damageUp = Instantiate(Resources.Load("Prefab/DamageUp") as GameObject);
                            damageUp.name = "DamageUp";
                            damageUp.transform.position = current_node.transform.position;
                            break;
                        case 2:
                            GameObject speedUp = Instantiate(Resources.Load("Prefab/SpeedUp") as GameObject);
                            speedUp.name = "SpeedUp";
                            speedUp.transform.position = current_node.transform.position;
                            break;
                    }
                }

                level_clear = true;
            }

            current_node.GetComponent<Node>().CompleteRoom();
        }

        if (current_node.GetComponent<Node>().RoomCompleted() == true && current_node.GetComponent<Node>().GetRoomType() == 9){
            SpawnWin();
        }
    }


    public void TransportPlayer(string direction){

        if (player.GetComponent<PlayerActionController>().IsRolling()){
            player.GetComponent<PlayerActionController>().state = PlayerActionController.State.Normal;
            player.GetComponent<PlayerActionController>().sr.color = Color.white;
            player.GetComponent<PlayerActionController>().isRolling = false;
            player.GetComponent<PlayerActionController>().rb.velocity = new Vector2(0, 0);
        }
        
        if (GetChildWithName(current_node, direction) != null){
            current_node = GetChildWithName(current_node, direction);
        } else {
            current_node = current_node.transform.parent.gameObject;
        }
        
        main_camera.transform.position = new Vector3(current_node.transform.position.x, current_node.transform.position.y, -10);
        enemies.transform.position = current_node.transform.position;
        float x_offset = 4f;
        float y_offset = 2.3f;
        GameObject sprites_local = GetChildWithName(current_node, "Sprites");
        switch(direction){
            case "North":
                player.transform.position = new Vector3(current_node.transform.position.x, current_node.transform.position.y - y_offset);
                break;
            case "East":
                player.transform.position = new Vector3(current_node.transform.position.x - x_offset, current_node.transform.position.y);
                break;
            case "South":
                player.transform.position = new Vector3(current_node.transform.position.x, current_node.transform.position.y + y_offset);
                break;
            case "West":
                player.transform.position = new Vector3(current_node.transform.position.x + x_offset, current_node.transform.position.y);
                break;
        }

        if (current_node.GetComponent<Node>().RoomCompleted() == false && current_node.GetComponent<Node>().GetRoomType() == 4){
            GameObject speedUp = Instantiate(Resources.Load("Prefab/SpeedUpItem") as GameObject);
            speedUp.name = "SpeedUp";
            speedUp.transform.position = current_node.transform.position;
            StartCoroutine(SetLevelFull());
        } else if (current_node.GetComponent<Node>().RoomCompleted() == false && current_node.GetComponent<Node>().GetRoomType() == 5){
            GameObject damageUp = Instantiate(Resources.Load("Prefab/DamageUpItem") as GameObject);
            damageUp.name = "DamageUp";
            damageUp.transform.position = current_node.transform.position;
            StartCoroutine(SetLevelFull());
        } else if (current_node.GetComponent<Node>().RoomCompleted() == false && current_node.GetComponent<Node>().GetRoomType() == 9){
            SpawnBoss();
        } else if (current_node.GetComponent<Node>().RoomCompleted() == false && current_node.GetComponent<Node>().GetRoomType() != 0){
            SpawnEnemies(direction);
        } else{
            StartCoroutine(SetLevelFull());
        }

        player.GetComponent<PlayerActionController>().state = PlayerActionController.State.Waking;
    }


    public void SpawnEnemies(string entry_direction){

        enemy_spawn_spot = new bool[,]{{true,true,true},{true,true,true},{true,true,true}};

        int enemy_pos_x = 0;
        int enemy_pos_y = 0;

        switch (entry_direction){
            case "North":
                enemy_spawn_spot[0,1] = false;
                enemy_pos_x = 0;
                enemy_pos_y = 1;
                break;
            case "East":
                enemy_spawn_spot[1,2] = false;
                enemy_pos_x = 1;
                enemy_pos_y = 2;
                break;
            case "South":
                enemy_spawn_spot[2,1] = false;
                enemy_pos_x = 2;
                enemy_pos_y = 1;
                break;
            case "West":
                enemy_spawn_spot[1,0] = false;
                enemy_pos_x = 1;
                enemy_pos_y = 0;
                break;
        }

        Vector3[,] spawn_locations = EnemySpawnLocation();

        int number_of_enemies = (int) Math.Floor(current_node.GetComponent<Node>().GetAssignedSeedDigit() / 2.0);

        if(number_of_enemies == 0){number_of_enemies = 1;}

        List<Vector3> spawns = new List<Vector3>();


        for (int i = 0; i < number_of_enemies; i++){
            while (enemy_spawn_spot[enemy_pos_x, enemy_pos_y] == false){
                System.Random rnd = new System.Random();
                enemy_pos_x = rnd.Next(0, 3);
                enemy_pos_y = rnd.Next(0, 3);
            }

            float pos_x = current_node.transform.position.x + spawn_locations[enemy_pos_x, enemy_pos_y].x;
            float pos_y = current_node.transform.position.y + spawn_locations[enemy_pos_x, enemy_pos_y].y;

            spawns.Add(new Vector3(pos_x, pos_y, 0));
            enemy_spawn_spot[enemy_pos_x, enemy_pos_y] = false;
        }

        for (int i = 0; i < number_of_enemies; i++){
            GameObject enemy = Instantiate(Resources.Load("Prefab/Enemy") as GameObject);
            enemy.name = "Enemy";
            enemy.transform.parent = enemies.transform;

            enemy.transform.position = spawns[i];

        }

        StartCoroutine(SetLevelFull());

    }


    public Vector3[,] EnemySpawnLocation(){
        ArrayList output = new ArrayList();

        float x_offset = 4f;
        float y_offset = 2.7f;

        output.Add(new Vector3(x_offset, -y_offset, 0));
        
        output.Add(new Vector3(0, -y_offset, 0));

        output.Add(new Vector3(-x_offset, -y_offset, 0));

        output.Add(new Vector3(x_offset, 0, 0));

        output.Add(new Vector3(0, 0, 0));

        output.Add(new Vector3(-x_offset, 0, 0));

        output.Add(new Vector3(x_offset, y_offset, 0));

        output.Add(new Vector3(0, y_offset, 0));

        output.Add(new Vector3(-x_offset, y_offset, 0));

        Vector3[,] output_array = {{(Vector3)output[0], (Vector3)output[1], (Vector3)output[2]}, 
                                   {(Vector3)output[3], (Vector3)output[4], (Vector3)output[5]}, 
                                   {(Vector3)output[6], (Vector3)output[7], (Vector3)output[8]},};

        return output_array;
    }


    public void SpawnBoss(){
        GameObject boss = Instantiate(Resources.Load("Prefab/Boss") as GameObject);
        boss.name = "Boss";
        boss.transform.parent = enemies.transform;
        boss.transform.position = current_node.transform.position;

        StartCoroutine(SetLevelFull());
    }

    public void SpawnWin(){
        GameObject win = Instantiate(Resources.Load("Prefab/EndGame") as GameObject);
        win.name = "Win Chest";
        win.transform.parent = enemies.transform;
        win.transform.position = current_node.transform.position;
    }


    public GameObject GetCurrentNode(){
        return this.current_node;
    }


    public static GameObject GetChildWithName(GameObject obj, string name){

        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
             
        if (childTrans != null){
            return childTrans.gameObject;
        }
 
        return null;
    }

    private IEnumerator SetLevelFull(){
        yield return new WaitForSeconds(2);

        level_clear = false;
    }

}
