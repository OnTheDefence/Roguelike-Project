using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int health;
    [SerializeField] private int difficulty;

    public Enemy(int difficulty){

        switch(difficulty){
            case 0:
                SetDifficulty(0);
                SetHealth(10);
                break;
            case 1:
                SetDifficulty(1);
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

    public void SetDifficulty(int difficulty){
        this.difficulty = difficulty;
    }

    public int GetDifficulty(){
        return this.difficulty;
    }

    public void Damage(int damage){
        SetHealth(GetHealth() - damage);

        if (GetHealth() <= 0){
            Die();
        }
    }

    public void Die(){
        Destroy(this.gameObject);
    }
}
