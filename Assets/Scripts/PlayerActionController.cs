using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionController : MonoBehaviour
{
    private float moveSpeed = 1.5f;
    private float rollSpeed = 1500f;
    private float rollCooldownTime = 2f;
    private bool canRoll = true;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private State state;
    private enum State {
        Normal,
        Rolling,
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 10;
    }

    void FixedUpdate()
    {
        switch (state) {
            case State.Normal:
                HandleMovement();
                HandleRoll();
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
                StartCoroutine(Roll());
            }
        } 
    }

    private void HandleRolling(){
        if (rb.velocity.magnitude <= 2){
            state = State.Normal;
        }
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
}
