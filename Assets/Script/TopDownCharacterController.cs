using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody2d;
    private bool canAttack = true;
    private bool isAttacking = false;
    public float attackCooldown = 1.0f;
    private float timeSinceAttack = 0.0f;
    private bool canMove = true;

    //fps
    private int fps = 120;

    //health
    public float speed;
    public int maxHP = 3;
    public int currentHP;
    public int HP { get { return currentHP; } }

    //iFrames
    public float timeInvincible = 3.0f;
    private bool isInvincible;
    private float invincibleTimer = 0;

    //status check
    private float HPLogTimer = 0f;
    private float HPLogInterval = 1.0f;
    /*    private float InvincibleLogTimer = 0f;
        private float InvincibleLogInterval = 1.0f;*/

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHP = maxHP;

        //fps
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = fps;
    }

    private void Update()
    {
        HandleMovement();

        if (!isAttacking) { 
            HandleAttack();
        }

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }

        //statuses (comment this if final)
        //hp
        HPLogTimer += Time.deltaTime;
        if (HPLogTimer >= HPLogInterval)
        {
            Debug.Log("HP: " + currentHP + "/" + maxHP);
            HPLogTimer = 0f;
        }
        //invincibility
        /*        InvincibleLogTimer += Time.deltaTime;
                if (InvincibleLogTimer >= InvincibleLogInterval)
                {
                    Debug.Log("Invincible: " + isInvincible);
                    InvincibleLogTimer = 0f;
                }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TopDownCharacterController player = collision.gameObject.GetComponent<TopDownCharacterController>();
        if (player != null)
        {
            player.changeHP(1);
        }
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Move the player
        rigidbody2d.velocity = new Vector2(movement.x * speed, movement.y * speed);

        // Set animation parameters
        if (movement.magnitude > 0)
        {
            // Player is moving
            animator.SetBool("IsRunning", true);

            // Flip sprite based on movement direction
            if (movement.x > 0)
            {
                transform.localScale = new Vector3(4, 4, 4);
            }
            else if (movement.x < 0)
            {
                transform.localScale = new Vector3(-4, 4, 4);
            }
        }
        else
        {
            // Player is not moving
            animator.SetBool("IsRunning", false);
        }
    }

    private void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            // Set the trigger for attack animation
            animator.SetTrigger("Attack");

            // Set attack on cooldown
            canAttack = false;
            timeSinceAttack = 0.0f;

            // Start the cooldown coroutine
            StartCoroutine(AttackCooldown());
        }

        // Update the time since last attack
        timeSinceAttack += Time.deltaTime;
    }

    public void StartAttack()
    {
        isAttacking = true;
        rigidbody2d.velocity = Vector2.zero;
        isAttacking = false;
    }
    public void changeHP(int amnt)
    {
        if (!isInvincible)
        {
            currentHP -= amnt;

            if (currentHP <= 0)
            {
                Die();
            }
            else
            {
                animator.SetTrigger("Hit");
                isInvincible = true;
                invincibleTimer = timeInvincible;
            }
        }
    }

    private void Die()
    {
        // Disable the script to prevent further updates
        enabled = false;

        // Trigger death animation
        animator.SetTrigger("IsDead");

        // Deactivate the game object after a delay
        StartCoroutine(DeactivateAfterDelay(1.2f));
    }

    private IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        OnObjectDestroyed();
    }

    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

}
