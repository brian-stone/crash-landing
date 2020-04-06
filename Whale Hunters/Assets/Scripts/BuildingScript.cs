using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] public List<PeopleScript> workersinbuilding; //list of workers in each sector.

    [SerializeField] private int energy_output;
    [SerializeField] private int metal_output;
    [SerializeField] private int food_output;

    [SerializeField] private int energy_cost;
    [SerializeField] private int maintenance_cost;

    [SerializeField] private int house_capacity;

    private GameScript gameScript;

    // Start is called before the first frame update
    void Start()
    {
        //TODO: gameScript = ??? need singleton function
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

    public void addHealth(int am)
    {
        health += am;
    }

    public void hospitalHeal()
    {
        foreach (PeopleScript person in workersinbuilding)
        {
            person.curhealth = person.maxhealth;
        }
    }

    public void buildWeapon(string weapontype)
    {
        //(I'm assuming different weapons cost different metals/energy), using 50 as placeholder for now
        if (weapontype == "sword" && gameScript.metal >= (50) && gameScript.energy >= (50))
        {
            gameScript.weapons.Add("sword");
            gameScript.subtractMetal(50);
            gameScript.subtractEnergy(50);
        }
        if (weapontype == "gun" && gameScript.metal >= (50) && gameScript.energy >= (50))
        {
            gameScript.weaponlist.add("gun");
            gameScript.subtractMetal(50);
            gameScript.subtractEnergy(50);
        }
        if (weapontype == "rifle" && gameScript.metal >= (50) && gameScript.energy >= (50))
        {
            gameScript.weaponlist.add("rifle");
            gameScript.subtractMetal(50);
            gameScript.subtractEnergy(50);
        }
        if (weapontype == "spear" && gameScript.metal >= (50) && gameScript.energy >= (50))
        {
            gameScript.weaponlist.add("spear");
            gameScript.subtractMetal(50);
            gameScript.subtractEnergy(50);
        }
        if (weapontype != "sword" && weapontype != "gun" && weapontype != "rifle" && weapontype != "spear")
        {
            //Not sure how "print()" works here
            gameScript.WriteLine("What are you trying to build?");
        }
        else
        {
            gameScript.WriteLine("Not enough resources");
        }
    }
    
    //Alternative, delete if unused:
    //public void buildWeapon(int i, int f) #i=gamescript.metal, f=gamescript.energy <- probably unneeded
    //{
    //    (4 weapons, sword, gun, rifle, spear)
    //    gamescript checks if resources are enough??? -> so I guess gamescript checks resources and if resources are enough run buildWeapon(), not sure how different kinds of weapons are made though...
    //    gamescript.weaponlist.add('name');
    //    ^I'm guessing "name" is supposed to be one of the 4 weapon types
    //    gamescript.subtractMetal(50);
    //    gamescript.subtractEnergy(50);
    //}
    
    public void tagcheck()
    {
        //what is this supposed to return? Are we clicking on a building to get the building's name or something?
        gameObject.getTag();
    }
    
    public void populate(PeopleScript person)
    {
        if (workersinbuilding.Count < house_capacity) //Alternatively "if len(workersinbuilding)<house_capacity", but that will change some code below.
        {
            workersinbuilding.Add(person);
            //TODO: flip person's in_building flag (not sure if this has been created yet)
        }
        else
        {
            gameScript.WriteLine('Building is full, find somewhere else.');
        }
    }

    public void depopulate(PeopleScript person)
    {
        workersinbuilding.Remove(person);
    }
}
