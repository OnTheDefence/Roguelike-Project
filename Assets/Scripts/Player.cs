using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] string[] inventory = {"", "", ""};

    public void Awake(){
        SetHealth(15);
    }

    public void SetHealth(float health){
        this.health = health;
    }

    public void ReduceHealth(float reduction){
        this.health -= reduction;

        GameObject.Find("UIController").GetComponent<StatUI>().HandleHealthDecrease();

        if (this.health <= 0){
            Die();
        }
    }

    public void IncreaseHealth(float increase){
        this.health += increase;
        GameObject.Find("UIController").GetComponent<StatUI>().HandleHealthIncrease();
    }

    public float GetHealth(){
        return this.health;
    }

    public string GetInvSlot(int slot){
        return this.inventory[slot];
    }

    public string[] GetInv(){
        return this.inventory;
    }

    public void SetInvSlot(int slot, string item){
        this.inventory[slot] = item;
    }

    private void Die(){
        SceneManager.LoadScene("EndDied");
    }
}
