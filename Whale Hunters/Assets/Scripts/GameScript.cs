using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    //Variables for storing total energy, metal, and food amount.
    public int energy;
    public int metal;
    public int food;

    //Keeps track of number of people + initial number of people at the beginning.
    public int people;

    //Lists of different objects. 
    public List<PeopleScript> Persons = new List<PeopleScript>(); 
    public List<BuildingScript> buildings = new List<BuildingScript>();
    public List<WeaponScript> weapons = new List<WeaponScript>();
    public List<EnemyAI> enemyAIs = new List<EnemyAI>();
    public List<WeaponScript> friendlies = new List<WeaponScript>();

    //Keeps track of enemy waves, i=Each Night/wave, j=Enemy gameobjects spawned of time tracked in enemyGameObjects.
    public int[][] enemyNumbers;
    public GameObject[] enemyGameObjects;

    public float time;
    public int day = 0;
    public float timestep = 1.0f;
    public double populationGrowthRate = 0.2; //Population growth in decimal form.
    public int foodConsumption = 1; //Food Consumption per person
    // Start is called before the first frame update
    void Start()
    {
        for (int i =0; i < people;i++)
        {
            addPerson();
        }
        newDayCycle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newDayCycle()
    {
        day++;
        getResources();
        peopleMaintenance();
        managePopulationGrowth();
    }

    public void newNightCycle()
    {
        for (int i =0;i<enemyNumbers[day].Length;i++)
        {
            for (int j=0;j<enemyNumbers[day][i];j++)
            {
                GameObject g = enemyGameObjects[j];
                g = Instantiate(g);
                enemyAIs.Add(g.GetComponent<EnemyAI>());
            }
        }
    }

    private IEnumerator checkForNightCycleEnd()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            if (countEnemies() == 0 || countFriendly() == 0)
            {
                newDayCycle();
            } 

        }
    }

    private int countEnemies()
    {
        int count = 0;
        foreach (EnemyAI enemy in enemyAIs)
        {
            if (enemy != null)
            {
                count++;
            }
        }
        return count;
    }

    private int countFriendly()
    {
        int count = 0;
        foreach (WeaponScript friendly in friendlies)
        {
            if (friendly != null)
            {
                count++;
            }
        }
        return count;
    }
    private void getResources()
    {
        foreach(BuildingScript b in buildings)
        {
            energy += b.getEnergyProduction();
            food += b.getFoodProduction();
            metal += b.getMetalProduction();
            if (energy > 0)
            {
                energy -= b.getMaintenenceCost();
            } else
            {
                //b.inoperable();
            }
        }

    }

    private void peopleMaintenance()
    {
        for (int i=0;i<people;i++) 
        {
            food -= foodConsumption;
        }
    }

    private void managePopulationGrowth()
    {
        int difference = (int)(people *populationGrowthRate);
        people = difference + people;
        for (int i=0;i<difference;i++) {
            addPerson();
        }
    }

    

    public void addPerson()
    {
        PeopleScript p = new PeopleScript();
        p = Instantiate(p);
        p.randomizerstats();
        Persons.Add(p);
    }

    public void remove_person(GameObject g)
    {
        if (g.GetComponent<PeopleScript>() != null && g.GetComponent<BuildingScript>() == null)
        {
            people -= 1;
            Persons.Remove(g.GetComponent<PeopleScript>());
        }
    }

    public void add_building(GameObject b)
    {
        b = Instantiate(b);
        
        if (b.GetComponent<PeopleScript>() != null && b.GetComponent<BuildingScript>() != null) {
            buildings.Add(b.GetComponent<BuildingScript>());
            //b.GetComponent<PeopleScript>().buildingstats();
            //b.GetComponent<BuildingScript>().initializeBuilding();
        }
        
    }

    //Adder/subtracter Functions
    public void subtractMetal(int am)
    {
        metal -= am;
    }

    public void addFood(int am)
    {
        food += am;
    }
    public void addEnergy(int am)
    {
        energy += am;
    }
    public void addMetal(int am)
    {
        metal += am;
    }




}
