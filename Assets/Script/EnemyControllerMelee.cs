using System.Collections;
using UnityEngine;

public class EnemyControllerMelee : MonoBehaviour
{
    public int damage;
    public float speed;
    private Animator animator;
    public int _hp;
    Rigidbody2D rigidbody2d;
    float timer;
    int direction;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + Time.deltaTime * speed * direction;
        rigidbody2d.MovePosition(position);
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
        }
    }
    public bool _targetable = true;



    public void OnCollisionEnter2D(Collision2D collision)
    {
        TopDownCharacterController player = collision.collider.gameObject.GetComponent<TopDownCharacterController>();
        if (player != null)
        {
            player.changeHP(damage);
        }
    }

    public void OnHit(int damage)
    {
        Health -= damage;
    }

    public void Die()
    {
        animator.SetTrigger("IsDead");


        // Deactivate the game object after a delay
        StartCoroutine(DeactivateAfterDelay(1.1f));
    }

    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }

    public IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Deactivate the game object
        OnObjectDestroyed();
    }
}
