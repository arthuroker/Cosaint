using UnityEngine;

public class PrototypeAbility : AbilityBase
{
    private GameObject projectilePrefab; // Reference to the prefab for the projectile
    private Transform playerTransform;  // Reference to the player's transform

    // Constructor
    public PrototypeAbility(GameObject prefab, Transform player) 
        : base("Prototype Ability", KeyCode.E, 3f)
    {
        projectilePrefab = prefab;
        playerTransform = player;
    }

    protected override void Execute()
    {
        Debug.Log($"{abilityName} activated!");

        // Ensure prefab and playerTransform are set
        if (projectilePrefab == null || playerTransform == null)
        {
            Debug.LogError("ProjectilePrefab or PlayerTransform is not set!");
            return;
        }

        // Instantiate the projectile
        GameObject projectile = GameObject.Instantiate(
            projectilePrefab, 
            playerTransform.position + playerTransform.forward, // Spawn in front of player
            Quaternion.LookRotation(playerTransform.forward)    // Orient forward
        );

        // Add velocity to the projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.linearVelocity = playerTransform.forward * 10f; // Adjust speed as needed
        }
        else
        {
            Debug.LogError("ProjectilePrefab does not have a Rigidbody component!");
        }
    }
}