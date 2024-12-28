using UnityEngine;

public class ProtopyeProjectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Enemy>().TakeDamage(100);
        }
    }
}
