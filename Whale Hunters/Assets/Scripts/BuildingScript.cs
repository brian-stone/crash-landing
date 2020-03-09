using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    [SerializeField] private int health;

    [SerializeField] private int energy_output;
    [SerializeField] private int metal_output;
    [SerializeField] private int food_output;

    [SerializeField] private int energy_cost;
    [SerializeField] private int maintenance_cost;

    [SerializeField] private int house_capacity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getHealth()
    {
        return health;
    }

    public int getEnergyProduction()
    {
        return energy_output;
    }

    public int getMetalProduction()
    {
        return metal_output;
    }

    public int getFoodProduction()
    {
        return food_output;
    }

    public int getEnergyCost()
    {
        return energy_cost;
    }

    public int getMaintenenceCost()
    {
        return maintenance_cost;
    }

    public int getCapacity()
    {
        return house_capacity;
    }
}
