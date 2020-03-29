using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] public GameObject[] workersinbuilding; //list of workers in each sector.

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

    public void addHealth(int am)
    {
        health += am;
    }

    public void hospitalHeal()
    {
        foreach (GameObject person in workersinbuilding)
        {
            person.GetComponent<PeopleScript>().curhealth = person.GetComponent<PeopleScript>().maxhealth;
        }
    }

    public void buildWeapon(string weapontype)
    {
        #(I'm assuming different weapons cost different metals/energy), using 50 as placeholder for now
        if weapontype == 'sword' and gamescript.metal >= (50) and gamescript.energy >= (50)
        {
            gamescript.weaponlist.add('sword');
            gamescript.subtractMetal(50);
            gamescript.subtractEnergy(50);
        }
        if weapontype == 'gun' and gamescript.metal >= (50) and gamescript.energy >= (50)
        {
            gamescript.weaponlist.add('gun');
            gamescript.subtractMetal(50);
            gamescript.subtractEnergy(50);
        }
        if weapontype == 'rifle' and gamescript.metal >= (50) and gamescript.energy >= (50)
        {
            gamescript.weaponlist.add('rifle');
            gamescript.subtractMetal(50);
            gamescript.subtractEnergy(50);
        }
        if weapontype == 'spear' and gamescript.metal >= (50) and gamescript.energy >= (50)
        {
            gamescript.weaponlist.add('spear');
            gamescript.subtractMetal(50);
            gamescript.subtractEnergy(50);
        }
        if weapontype != 'sword' and weapontype!='gun' and weapontype!='rifle' and weapontype != 'spear':
        {
            #Not sure how "print()" works here
            gamescript.WriteLine('What are you trying to build?');
        }
        else:
        {
            gamescript.WriteLine("Not enough resources");
        }
    }
    
    #Alternative, delete if unused:
    #public void buildWeapon(int i, int f) #i=gamescript.metal, f=gamescript.energy <- probably unneeded
    #{
        #(4 weapons, sword, gun, rifle, spear)
        #gamescript checks if resources are enough??? -> so I guess gamescript checks resources and if resources are enough run buildWeapon(), not sure how different kinds of weapons are made though...
        #gamescript.weaponlist.add('name');
        #^I'm guessing "name" is supposed to be one of the 4 weapon types
        #gamescript.subtractMetal(50);
        #gamescript.subtractEnergy(50);
    #}
    
    
    
    public void tagcheck():
    {
        #what is this supposed to return? Are we clicking on a building to get the building's name or something?
        gameobject.getTag();
    }
    
    
    public void populate(gameobject[])
    {
        if house_capacity > 0 #Alternatively "if len(workersinbuilding)<house_capacity", but that will change some code below.
        {
            workersinbuilding.add(gameobject[]); #not too sure how this works...
            house_capacity-=1;
            #I'm assuming house_capacity is a number > 0 that shows how many people can fit into house
            #is there a list of people (similar to workersinbuilding) of people not in buildings? Form my understanding people not in buildings do work.
            #workersnotinbuilding.remove(gameobject[])
        }
        if house_capacity<=0 #else
        {
            gamescript.WriteLine('Building is full, find somewhere else.');
        }
    }
    
    public void depopulate(gameobject[])
    {
        if len(workersinbuilding) == 0      #redundant???
        {
            gamescript.WriteLine("No one's here...");
        }
        else
        {
            workersinbuilding.remove(gameobject[]);
            #workersnotinbuilding.add(gameobject[]);
            house_capacity+=1;
        }
    }
    
}
