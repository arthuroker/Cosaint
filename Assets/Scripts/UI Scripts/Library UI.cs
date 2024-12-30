using System.Collections.Generic;
using UnityEngine;

public class LibraryUI : MonoBehaviour
{

    [SerializeField] private List<AbilityBase> abilities = new List<AbilityBase>();

    private AbilityManager abilityManager;

    void Start()
    {
        abilityManager = GameObject.Find("Ability Manager").GetComponent<AbilityManager>();
    }


    void Update()
    {
        abilities = abilityManager.GetAbilities();
    }
}
