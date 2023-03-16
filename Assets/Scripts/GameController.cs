using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Node currentNode;
    private GameObject enemies;
    [SerializeField] private bool killEnemy = false;
    // Start is called before the first frame update
    void Awake()
    {
        currentNode = GameObject.Find("Level").transform.GetChild(0).GetComponent<Node>();
        enemies = GameObject.Find("Enemies");
    }

    // Update is called once per frame
    void Update()
    {
        if(killEnemy){
            foreach (Transform enemy in (enemies.transform.GetComponentsInChildren<Transform>())){
                //enemy.gameObject.GetComponent<Enemy>().Die();

                Debug.Log(enemy.name);

                if (enemy.name == "Enemy"){
                    enemy.GetComponent<Enemy>().Die();
                }

                killEnemy = false;
            }
        }
    }

}
