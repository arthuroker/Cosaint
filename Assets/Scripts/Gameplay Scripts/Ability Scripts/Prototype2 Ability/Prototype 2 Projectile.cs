using UnityEngine;

public class Protopye2Projectile : MonoBehaviour
{

    private float freezeTime = 5f;

    public float getFreezeTime()
    {
        return freezeTime;
    }

    public void setFreezeTime(float freezeTime)
    {
        this.freezeTime = freezeTime;
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Enemy>().ApplyFreeze(freezeTime);
        }
    }
}
