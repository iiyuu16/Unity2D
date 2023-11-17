using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            if (collision.GetComponent<EnemyControllerMelee>())
            {
                collision.GetComponent<EnemyControllerMelee>().OnHit(1);
            }
            else if (collision.GetComponent<EnemyControllerRanged>())
            {
                collision.GetComponent<EnemyControllerRanged>().OnHit(1);
            }
        }
    }

    private void OnDrawGizmos()
    {

        float facingDirection = Mathf.Sign(transform.localScale.x);

        // Calculate the position based on the facing direction
        Vector3 facingOffset = new Vector3(attkPosition.x * facingDirection, attkPosition.y, attkPosition.z);

        // Draw the wire cube with the adjusted position
        Gizmos.DrawWireCube(transform.position + facingOffset, boxRange);
    }



}
