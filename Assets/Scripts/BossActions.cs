using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActions : MonoBehaviour
{
    GameObject player;
    GameObject current_node;
    private Rigidbody2D rb;
    bool canRotate;
    bool canShoot;
    float shootCooldown = 0.8f;
    float rotateCooldown = 3f;
    
    private State state;
    private enum State {
        Sleeping,
        Awake,
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 10;

        current_node = GameObject.Find("GameController").GetComponent<GameController>().GetCurrentNode();

        canRotate = true;
        canShoot = true;
        player = GameObject.Find("Player");

        state = State.Sleeping;
    }


    void FixedUpdate()
    {
        switch (state) {
            case State.Awake:
                transform.position = current_node.transform.position;
                HandleRotation();
                HandleShooting();
                break;
            case State.Sleeping:
                StartCoroutine(WakeUp());
                break;
        }
    }

    public void HandleRotation(){
        if (canRotate){
            StartCoroutine(Rotating());
        }
    }

    public void HandleShooting(){
        if (canShoot){
            Shoot();
        }
    }

    void Shoot(){
        canShoot = false;

        Vector2[] directions = {this.gameObject.transform.up, this.gameObject.transform.right, -this.gameObject.transform.up, -this.gameObject.transform.right};

        for (int i = 0; i < 4; i++){
            GameObject EnemyOneAttack = Instantiate (Resources.Load ("Prefab/EnemyOneAttack") as GameObject);
            EnemyOneAttack.name = "Bullet";
            EnemyOneAttack.transform.position = this.gameObject.transform.position;
            EnemyOneAttack.transform.up = directions[i];
        }

        
        StartCoroutine(ShootCooldown());
    }

    private IEnumerator Rotating(){
        canRotate = false;

        float rotation_increment = 2f;

        while(rotation_increment < 30){
            rb.rotation += rotation_increment;

            rotation_increment += 0.2f;

            yield return new WaitForFixedUpdate();
        }

        while(rotation_increment > 0){
            rb.rotation -= rotation_increment;

            rotation_increment -= 0.2f;

            yield return new WaitForFixedUpdate();
        }

        StartCoroutine(RotateCooldown());
    }

    private IEnumerator RotateCooldown(){
        yield return new WaitForSeconds(rotateCooldown);

        canRotate = true;
    }

    private IEnumerator ShootCooldown(){
        yield return new WaitForSeconds(shootCooldown);

        canShoot = true;
    }

    private IEnumerator WakeUp(){

        yield return new WaitForSeconds(1.8f);

        state = State.Awake;
    }

}
