using UnityEngine;


public class AttackHitbox : MonoBehaviour
{
    public Vector3 attkPosition;
    public Vector2 boxRange;

    // Start is called before the first frame update
    public void AttackAtPlayer()
    {
        float facingDirection = Mathf.Sign(transform.localScale.x);
        Vector3 facingOffset = new Vector3(attkPosition.x * facingDirection, attkPosition.y, attkPosition.z);

        Collider2D[] collider = Physics2D.OverlapBoxAll(transform.position + facingOffset, boxRange, 0);

        foreach (Collider2D collision in collider)
        {
            if (collision.GetComponent<TopDownCharacterController>())
            {
                collision.GetComponent<TopDownCharacterController>().changeHP(1);
            }
        }
    }

    public void AttackAtEnemy()
    {
        float facingDirection = Mathf.Sign(transform.localScale.x);
        Vector3 facingOffset = new Vector3(attkPosition.x * facingDirection, attkPosition.y, attkPosition.z);

        Collider2D[] collider = Physics2D.OverlapBoxAll(transform.position + facingOffset, boxRange, 0);

        foreach (Collider2D collision in collider)
        {
            if (collision.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject); // Destroy the bullet
            }
            else if (collision.GetComponent<EnemyController>())
            {
                collision.GetComponent<EnemyController>().OnHit(1);
            }
        }
    }

    //uncomment gizmo for debugging hitbox
/*    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;

        float facingDirection = Mathf.Sign(transform.localScale.x);

        // Calculate the position based on the facing direction
        Vector3 facingOffset = new Vector3(attkPosition.x * facingDirection, attkPosition.y, attkPosition.z);

        // Draw the wire cube with the adjusted position
        Gizmos.DrawWireCube(transform.position + facingOffset, boxRange);

    }*/

}
