using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneActions : MonoBehaviour
{
    GameObject player;
    //[SerializeField] float minDistanceFromPlayer = 5f;
    [SerializeField] Vector2 moveSpeed = new Vector2(0.5f, 0.5f);
    [SerializeField] Vector2 directionToPlayer;
    private Rigidbody2D rb;
    float directionToPlayerX;
    float directionToPlayerY;
    Vector2 moveDirection;
    bool canMove;
    bool canShoot;
    
    private State state;
    private enum State {
        Sleeping,
        Awake,
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 10;

        canMove = true;
        canShoot = false;
        player = GameObject.Find("Player");
    }


    void FixedUpdate()
    {
        switch (state) {
            case State.Awake:
                HandleMovement();
                HandleShooting();
                break;
            case State.Sleeping:
                StartCoroutine(WakeUp());
                break;
        }
    }

    public void HandleMovement(){
        if (canMove){
            directionToPlayerX = player.transform.position.x - this.gameObject.transform.position.x;
            directionToPlayerY = player.transform.position.y - this.gameObject.transform.position.y;

            directionToPlayer = new Vector2(directionToPlayerX, directionToPlayerY).normalized;

            System.Random rnd = new System.Random();

            int directionRandom = rnd.Next(0,3);

            switch(directionRandom){
                case 0:
                    moveDirection = Vector2.Perpendicular(directionToPlayer);
                    break;
                case 1:
                    moveDirection = directionToPlayer;
                    break;
                case 2:
                    moveDirection = Vector2.Perpendicular(Vector2.Perpendicular(Vector2.Perpendicular(directionToPlayer)));
                    break;
            }

            StartCoroutine(Moving());
        }
    }

    public void HandleShooting(){
        if (canShoot){
            System.Random rnd = new System.Random();
            int toShoot = rnd.Next(0,25);

            if(toShoot == 0){
                Shoot();
            }
        }
    }

    void Shoot(){
        GameObject EnemyOneAttack = Instantiate (Resources.Load ("Prefab/EnemyOneAttack") as GameObject);
        EnemyOneAttack.transform.position = this.gameObject.transform.position;
        EnemyOneAttack.transform.up = player.transform.position - EnemyOneAttack.transform.position;
        StartCoroutine(ShootCooldown());
    }

    private IEnumerator Moving(){
        canMove = false;
        canShoot = false;

        float countDown = 0.5f;
        for (int i=0; i < 10000; i++) 
        {
            while (countDown >= 0)
            {
                rb.AddForce(moveDirection, ForceMode2D.Impulse);
                countDown -= Time.smoothDeltaTime;
                yield return new WaitForFixedUpdate();
            }
        }

        StartCoroutine(MoveCooldown());
        canShoot = true;
    }

    private IEnumerator MoveCooldown(){
        yield return new WaitForSeconds(2);

        canMove = true;
    }

    private IEnumerator ShootCooldown(){
        canShoot = false;

        yield return new WaitForSeconds(2);

        if(canMove){
            canShoot = true;
        };
    }

    private IEnumerator WakeUp(){

        yield return new WaitForSeconds(0.8f);

        state = State.Awake;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
    }

}
