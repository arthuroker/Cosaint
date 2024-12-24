using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float speed = 2f;
    public Transform target;

    private void Update()
    {
        Move();
    }

    // Basic movement logic shared by all enemies
    protected virtual void Move()
    {
        if (target == null)
        {
            Debug.LogWarning("Target not set for " + name);
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    // Generic method to take damage
    public virtual void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    // Death logic
    protected virtual void Die()
    {
        Debug.Log($"{name} has died!");
        Destroy(gameObject);
    }

    // Placeholder for abilities (to be overridden by child or component scripts)
    public virtual void UseAbility()
    {
        Debug.Log($"{name} has no special ability!");
    }
}