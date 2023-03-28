using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionController : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 1.5f;
    [SerializeField] private float rollSpeed = 1500f;
    [SerializeField] private float rollCooldownTime = 2f;
    [SerializeField] private float shootCooldownTime = 0.75f;
    private bool canRoll = true;
    private bool canShoot = true;
    private bool isRolling = false;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 moveDirection;

    public State state;
    public enum State {
        Waking,
        Normal,
        Rolling,
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.drag = 10;
        state = State.Waking;
    }

    void FixedUpdate()
    {
        switch (state) {
            case State.Waking:
                StartCoroutine(WakeUp());
                break;
            case State.Normal:
                HandleMovement();
                HandleRoll();
                HandleShooting();
                break;
            case State.Rolling:
                HandleRolling();
                break;
        }
    }

    private void HandleMovement(){
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
        rb.AddForce(moveDirection * moveSpeed, ForceMode2D.Impulse);
    }

    private void HandleRoll(){
        if (Input.GetAxisRaw("Roll") != 0){
            if (canRoll){
                state = State.Rolling;
                isRolling = true;
                sr.color = Color.cyan;
                StartCoroutine(Roll());
            }
        } 
    }

    private void HandleRolling(){
        if (rb.velocity.magnitude <= 2){
            state = State.Normal;
            sr.color = Color.white;
            isRolling = false;
        }
    }

    private void HandleShooting(){
        if (Input.GetAxisRaw("Attack") != 0){
            if (canShoot){
                GameObject playerAttack = Instantiate (Resources.Load ("Prefab/PlayerAttack") as GameObject);
                playerAttack.transform.position = this.gameObject.transform.position;
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  
                playerAttack.transform.up = (new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y)).normalized;
                StartCoroutine(ShootCooldown());
            }
        }
    }

    public bool IsRolling(){
        return this.isRolling;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
    }

    private IEnumerator Roll(){
        float rollDistance = 8f;

        rb.velocity = new Vector2(0,0);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  
        Vector2 rollDirection = (new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y)).normalized;
        Vector3 originalPosition = transform.position;
        
        while (rollDistance > 0){
            Vector2 velocity = new Vector2((rollDirection.x * rollSpeed), (rollDirection.y * rollSpeed)).normalized;
            rb.AddForce(velocity, ForceMode2D.Impulse);
            rollDistance -= (transform.position - originalPosition).magnitude;

            yield return new WaitForSeconds(.01f);
        }

        StartCoroutine(RollCooldown());
    }

    private IEnumerator RollCooldown(){
        canRoll = false;

        yield return new WaitForSeconds(rollCooldownTime);

        canRoll = true;
    }

    private IEnumerator ShootCooldown(){
        canShoot = false;

        yield return new WaitForSeconds(shootCooldownTime);

        canShoot = true;
    }

    private IEnumerator WakeUp(){

        yield return new WaitForSeconds(0.8f);

        state = State.Normal;
    }

}
