using UnityEngine;

public class Player : MonoBehaviour
{
    private AbilityManager abilityManager;

    public GameObject spherePrefab;

    public Transform orientation;

    private void Start()
    {
        abilityManager = GameObject.Find("Ability Manager").GetComponent<AbilityManager>();

        abilityManager.AddAbility(new PrototypeAbility(spherePrefab, orientation));

        PrototypeAbility prototypeAbility = (PrototypeAbility) abilityManager.GetAbilityByName("Prototype Ability");
        prototypeAbility.UpgradeAbility();
    }
}
