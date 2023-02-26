using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMapSprites : MonoBehaviour
{
    public void Generate(GameObject current_node){
        Debug.Log(current_node);

        Node node = current_node.GetComponent<Node>();
        Vector3 scale_vector = new Vector3((float)1.7,(float)1.7,1);
        Vector3 scale_vector_down = new Vector3((float)0.75,(float)0.65,1);
        Vector3 box_vector_size = new Vector3(1, 1, 1);

        GameObject sprites = Instantiate (Resources.Load ("Prefab/Sprites") as GameObject);
        sprites.transform.position = current_node.transform.position + new Vector3(0,0,1);
        sprites.transform.parent = current_node.transform;


        GameObject north_door = new GameObject("north_door");
        north_door.transform.position = sprites.transform.position;
        north_door.transform.parent = sprites.transform;
        north_door.transform.localScale = scale_vector;
        north_door.AddComponent<SpriteRenderer>();
        if (current_node.GetComponent<Node>().GetNorthExit() != null){
            north_door.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Doors_north");

            GameObject north_door_gate = new GameObject("north_door_gate");
            north_door_gate.transform.position = sprites.transform.position;
            north_door_gate.transform.parent = sprites.transform;
            north_door_gate.transform.localScale = scale_vector;
            north_door_gate.AddComponent<SpriteRenderer>();
            north_door_gate.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Gates_north");

            north_door.AddComponent<BoxCollider2D>();
            north_door.GetComponent<BoxCollider2D>().size = box_vector_size;
            north_door.GetComponent<BoxCollider2D>().offset = new Vector3 ((float) 0,(float) 2.325, 1);

            north_door_gate.AddComponent<BoxCollider2D>();
            north_door_gate.GetComponent<BoxCollider2D>().size = box_vector_size;
            north_door_gate.GetComponent<BoxCollider2D>().offset = new Vector3 ((float) 0,(float) 2.3, 1);
            
        } else{
            north_door.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Walls_north");            
        }


        GameObject east_door = new GameObject("east_door");
        east_door.transform.position = sprites.transform.position;
        east_door.transform.parent = sprites.transform;
        east_door.transform.localScale = scale_vector;
        east_door.AddComponent<SpriteRenderer>();
        if (current_node.GetComponent<Node>().GetEastExit() != null){
            east_door.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Doors_east");

            GameObject east_door_gate = new GameObject("east_door_gate");
            east_door_gate.transform.position = sprites.transform.position;
            east_door_gate.transform.parent = sprites.transform;
            east_door_gate.transform.localScale = scale_vector;
            east_door_gate.AddComponent<SpriteRenderer>();
            east_door_gate.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Gates_east");

            east_door.AddComponent<BoxCollider2D>();
            east_door.GetComponent<BoxCollider2D>().size = box_vector_size;
            east_door.GetComponent<BoxCollider2D>().offset = new Vector3 ((float) 3.6,(float) 0, 1);

            east_door_gate.AddComponent<BoxCollider2D>();
            east_door_gate.GetComponent<BoxCollider2D>().size = box_vector_size;
            east_door_gate.GetComponent<BoxCollider2D>().offset = new Vector3 ((float) 3.575,(float) 0, 1);

        } else{
            east_door.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Walls_east");
        }


        GameObject south_door = new GameObject("south_door");
        south_door.transform.position = sprites.transform.position;
        south_door.transform.parent = sprites.transform;
        south_door.transform.localScale = scale_vector;
        south_door.AddComponent<SpriteRenderer>();
        if (current_node.GetComponent<Node>().GetSouthExit() != null){
            south_door.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Doors_south");

            GameObject south_door_gate = new GameObject("south_door_gate");
            south_door_gate.transform.position = sprites.transform.position;
            south_door_gate.transform.parent = sprites.transform;
            south_door_gate.transform.localScale = scale_vector;
            south_door_gate.AddComponent<SpriteRenderer>();
            south_door_gate.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Gates_south");

            south_door.AddComponent<BoxCollider2D>();
            south_door.GetComponent<BoxCollider2D>().size = box_vector_size;
            south_door.GetComponent<BoxCollider2D>().offset = new Vector3 ((float) 0,(float) -2.325, 1);

            south_door_gate.AddComponent<BoxCollider2D>();
            south_door_gate.GetComponent<BoxCollider2D>().size = box_vector_size;
            south_door_gate.GetComponent<BoxCollider2D>().offset = new Vector3 ((float) 0,(float) -2.3, 1);

        } else{
            south_door.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Walls_south");
        }


        GameObject west_door = new GameObject("west_door");
        west_door.transform.position = sprites.transform.position;
        west_door.transform.parent = sprites.transform;
        west_door.transform.localScale = scale_vector;
        west_door.AddComponent<SpriteRenderer>();
        if (current_node.GetComponent<Node>().GetWestExit() != null){
            west_door.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Doors_west");

            GameObject west_door_gate = new GameObject("west_door_gate");
            west_door_gate.transform.position = sprites.transform.position;
            west_door_gate.transform.parent = sprites.transform;
            west_door_gate.transform.localScale = scale_vector;
            west_door_gate.AddComponent<SpriteRenderer>();
            west_door_gate.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Gates_west");

            west_door.AddComponent<BoxCollider2D>();
            west_door.GetComponent<BoxCollider2D>().size = box_vector_size;
            west_door.GetComponent<BoxCollider2D>().offset = new Vector3 ((float) -3.6,(float) 0, 1);

            west_door_gate.AddComponent<BoxCollider2D>();
            west_door_gate.GetComponent<BoxCollider2D>().size = box_vector_size;
            west_door_gate.GetComponent<BoxCollider2D>().offset = new Vector3 ((float) -3.575,(float) 0, 1);

        } else{
            west_door.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Walls_west");
        }


        // GameObject map_skeleton = new GameObject("map_skeleton");
        // map_skeleton.transform.position = sprites.transform.position + new Vector3(0,0,1);
        // map_skeleton.transform.parent = sprites.transform;
        // map_skeleton.transform.localScale = scale_vector;
        // map_skeleton.AddComponent<SpriteRenderer>();
        // map_skeleton.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Skeleton Map");
        // map_skeleton.AddComponent<BoxCollider2D>();
        // map_skeleton.GetComponent<BoxCollider2D>().size = Vector3.Scale(map_skeleton.GetComponent<BoxCollider2D>().size, scale_vector_down);

        
    }
}
