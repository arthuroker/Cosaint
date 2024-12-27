using UnityEngine;
public abstract class Ability : MonoBehaviour
{
    public string AbilityName { get; set; }
    public float CooldownTime { get; set; }
    private float lastActivatedTime;

    public virtual bool CanActivate()
    {
        return Time.time >= lastActivatedTime + CooldownTime;
    }

    public void Activate()
    {
        if (!CanActivate()) return;
        lastActivatedTime = Time.time;
        Execute();
    }

    protected abstract void Execute();
}