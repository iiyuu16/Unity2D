using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class EnemyController : MonoBehaviour , IDamageable
{
    public int damage;
    public float speed;
    public float changeTime = 3.0f;
    private Animator animator;
    public int _hp;

    Rigidbody2D rigidbody2d;
    float timer;
    int direction;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = changeTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;

        position.x = position.x + Time.deltaTime * speed * direction;

        rigidbody2d.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TopDownCharacterController player = collision.collider.gameObject.GetComponent<TopDownCharacterController>();
        if (player != null)
        {
            player.changeHP(damage);
        }
    }

    public int Health
    {
        set
        {
            if (value < _hp)
            {
                animator.SetTrigger("Hit");

                //check hp
                Debug.Log(Health);

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

    public bool Targetable { get { return _targetable; }
        set 
        {
            _targetable = value;
            rigidbody2d.simulated = value;
        }
    }
    public bool _targetable = true;

    public void OnHit(int damage)
    {
        Health -= damage;
    }

    private void Die()
    {
        animator.SetTrigger("IsDead");


        // Deactivate the game object after a delay
        StartCoroutine(DeactivateAfterDelay(1.1f));
    }

    private IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Deactivate the game object
        OnObjectDestroyed();
    }

    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }
}
