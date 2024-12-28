using UnityEngine;

public class ProtopyeProjectile : MonoBehaviour
{

    private float damage = 100f;

    public float getDamage()
    {
        return damage;
    }

    public void setDamage(float damage)
    {
        this.damage = damage;
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
