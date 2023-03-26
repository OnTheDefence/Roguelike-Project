using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float health;

    public void Awake(){
        SetHealth(10);
    }

    public void SetHealth(float health){
        this.health = health;
    }

    public void ReduceHealth(float reduction){
        this.health -= reduction;

        if (this.health <= 0){
            Die();
        }
    }

    public void IncreaseHealth(float increase){
        this.health -= increase;
    }

    public float GetHealth(){
        return health;
    }

    private void Die(){
        Debug.Log("You Died");
    }
}
