using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript2 : MonoBehaviour
{
    public GameScript gs;
    
    //Put the different building types in here, named correctly.
    public BuildingScript[] bs;
    public WeaponScript[] weaponTypes;

    //Text Variables
    public Text gsOutput;
    public Text combatOutput;

    //Menu Variables
    public GameObject buildingMenu;
    public GameObject combatMenu;
    public GameObject weaponProductionMenu;

    //Building variables
    
    Dictionary<string, BuildingScript> buildingTypes = new Dictionary<string, BuildingScript>();
    Dictionary<string, WeaponScript> wT = new Dictionary<string, WeaponScript>();
    public BuildingScript building_temp;
    public bool placing_building = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (BuildingScript b in bs)
        {
            buildingTypes.Add(b.name, b);

        }

        foreach (WeaponScript w in weaponTypes)
        {
            wT.Add(w.name, w);

        }
        StartCoroutine(updateGameVars());

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && placing_building)
        {
            placing_building = false;
        }
        //Closes combat Menu
        if(Input.GetKeyDown(KeyCode.O))
        {
            combatMenu.SetActive(false);
        }
    }

    IEnumerator updateGameVars()
    {
        while (true)
        {
            updateGSOutput();
            yield return new WaitForSeconds(2.0f);
        }
    }
    //Output Displays and menu reveals
    public void updateGSOutput()
    {
        string output = "Energy: " + gs.energy + "  Metals: " + gs.metal + "    Food: " + gs.food+ "    Population: "+gs.people+"   Day: "+gs.day;
        gsOutput.text = output;
    }

    public void displayCombatOutput(WeaponScript wp)
    {
        string output = "   Armor: " + wp.armor + "\n  Damage: " + wp.damage + "\n    Fire Rate: " + wp.firerate + "\n    Range: " + wp.range + "\n   Health: " + wp.health;

        if (combatMenu.activeSelf == false)
        {

            combatMenu.SetActive(true);
        }
        else
        {
            combatMenu.SetActive(false);
        }
        combatOutput.text = output;
    }

    public void revealBuildingMenu()
    {

        if (buildingMenu.activeSelf == false)
        {

            buildingMenu.SetActive(true);
        }
        else
        {
            buildingMenu.SetActive(false);
        }
        
    }

    public void revealWeaponProductionMenu()
    {

        if (weaponProductionMenu.activeSelf == false)
        {

            weaponProductionMenu.SetActive(true);
        }
        else
        {
            weaponProductionMenu.SetActive(false);
        }

    }

    public void buildWeapon(string type)
    {
        WeaponScript weapon = wT[type];
        gs.add_weapons(weapon.gameObject);
        gs.subtractMetal(weapon.metal_cost);
    }

    //3 functions below places a building
    public void build(string type)
    {
        placeBuilding(buildingTypes[type]); 
    }

    public void placeBuilding(BuildingScript building_type)
    {
        building_temp = Instantiate(building_type);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //firstPoint = hit.point;
            //Debug.DrawLine (ray.origin, hit.point);
            //Instantiate ();
            if (hit.collider.gameObject != building_temp)
            {
                building_temp.transform.position = hit.point;
            }
        }
        placing_building = true;
        StartCoroutine(placingBuilding());
    }

    IEnumerator placingBuilding()
    {
        //Debug.Log("start");
        while (placing_building)
        {
            Debug.Log("Inside");
            yield return new WaitForSeconds(0.2f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //Physics.Ra
            //RaycastHit temp;
            if (Physics.Raycast(ray, out hit))
            {
                //firstPoint = hit.point;
                //Debug.DrawLine (ray.origin, hit.point);
                //Instantiate ();
                if (hit.collider.gameObject != building_temp)
                {
                    building_temp.transform.position = hit.point;
                }
                else
                {
                    
                }
                
            }


        }

        //Debug.Log("Button clicked");
        building_temp.gamescript = gs;
        gs.subtractMetal(building_temp.metal_cost);
        gs.add_building(building_temp.gameObject);
        //revealBuildingMenu(); //Uncomment to disable building menu after building a building.
    }
}
