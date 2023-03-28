using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int health;

    public int GetHealth(){
        return this.health;
    }

    public void SetHealth(int health){
        this.health = health;
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
