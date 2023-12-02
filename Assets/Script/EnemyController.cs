using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int touchDamage;
    public int damage;
    private Animator animator;
    public int _hp;
    private Rigidbody2D rigidbody2d;
    public new Collider2D collider;
    private bool playerInAttackZone = false;
    private bool canAttack = true;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (playerInAttackZone && canAttack)
        {
            AttackPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInAttackZone = true;
            Debug.Log("entered");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInAttackZone = false;
            Debug.Log("exited");
            canAttack = true;
        }
    }

    void AttackPlayer()
    {
        animator.SetTrigger("Attack");
        canAttack = false;
    }

    public int Health
    {
        set
        {
            if (value < _hp)
            {
                animator.SetTrigger("Hit");
            }

            _hp = value;

            if (_hp <= 0)
            {
                Die();
                Targetable = false;
            }
        }
        get
        {
            return _hp;
        }
    }

    public bool Targetable
    {
        get { return _targetable; }
        set
        {
            _targetable = value;
            rigidbody2d.simulated = value;
            collider.enabled = value;
        }
    }
    public bool _targetable = true;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        TopDownCharacterController player = collision.collider.gameObject.GetComponent<TopDownCharacterController>();
        if (player != null)
        {
            player.changeHP(touchDamage);
        }
    }

    public void OnHit(int damage)
    {
        Health -= damage;
    }

    public void Die()
    {
        animator.SetTrigger("IsDead");

        StartCoroutine(DeactivateAfterDelay(1.0f));
    }

    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }

    public IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        OnObjectDestroyed();
    }
}
