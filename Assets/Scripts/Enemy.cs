using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private int health;

    public Enemy(int difficulty){

        switch(difficulty){
            case 0:
                SetHealth(10);
                break;
            case 1:
                SetHealth(20);
                break;
        }
    }

    public int GetHealth(){
        return this.health;
    }

    public void SetHealth(int health){
        this.health = health;
    }

    public void Die(){
        Destroy(this.gameObject);
    }
}
