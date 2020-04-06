using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scouting : MonoBehaviour
{
    public GameScript gs;
    public List<GameObject> scouts;
    private int totalagi = 0;
    public bool waveinfo = false;
    public int gainmetal;
    public int gainenergy;
    public int gainfood;
    public string retstate = "";
    private int probableoutcomes;
    private bool goodoutcome = false;
    private bool badoutcome;
    public bool gotweapon;
    public int addweapon = 99;
    public int progression = 0;
    public bool progressed;
    public bool keytrigger = false;

    public string scoutcomes()
    {
        addweapon = 99;
        gotweapon = false;
        goodoutcome = false;
        retstate = "";
        totalagi = 0;
        gainmetal = 0;
        gainfood = 0;
        gainenergy = 0;
        probableoutcomes = 0;
        progressed = false;
        foreach (GameObject scout in scouts)
        {
            totalagi += scout.GetComponent<PeopleScript>().agility;
        }
        if (totalagi >= 7 + gs.day)
        {
            waveinfo = true;
        }
        gainmetal = Random.Range(0, 3) * totalagi;
        gainenergy = Random.Range(0, 2) * totalagi;
        gainfood = Random.Range(0, 3) * totalagi;
        probableoutcomes = Random.Range(0, totalagi);
        if (probableoutcomes > 1 * gs.day + 3)
        {
            goodoutcome = true;
        }
        
        if (goodoutcome)
        {
            int choice = Random.Range(1, 101);
            if (choice < 5)
            {
                gs.addPerson();
                gs.addPerson();
                retstate += "Two people returned with your scouting party.";
            } else if (choice < 13)
            {
                gs.addPerson();
                retstate += "Your scouting party saved a stranded person";
            }
            else if (choice < 23)
            {
                gainmetal += 20;
            }
            else if (choice < 33)
            {
                gainfood += 20;
            }else if (choice < 43)
            {
                gainenergy += 15;
            }else if (choice < 47)
            {
                gotweapon = true;
                addweapon = 0;
                retstate += "Your scouting party found a sword";
            } else if (choice < 51)
            {
                gotweapon = true;
                addweapon = 1;
                retstate += "Your scouting party found a gun";
            } else if (choice < 55)
            {
                gotweapon = true;
                addweapon = 2;
                retstate += "Your scouting party found a rifle";
            } else if (choice < 59)
            {
                gotweapon = true;
                addweapon = 3;
                retstate += "Your scouting party found a spear";
            } else if (choice < 66)
            {
                foreach (GameObject scout in scouts)
                {
                    scout.GetComponent<PeopleScript>().agility += 1;
                }
                retstate += "Your scouts have become better at navigating the terrain";
            } else if (choice < 71)
            {
                foreach (GameObject scout in scouts)
                {
                    scout.GetComponent<PeopleScript>().strength += Random.Range(0, 2);
                    scout.GetComponent<PeopleScript>().proficiency += Random.Range(0, 2);
                    scout.GetComponent<PeopleScript>().endurance += Random.Range(0, 2);
                }
                retstate += "Your scouts have gained valuable experiences";
            } else if (choice < 72)
            {
                keytrigger = true;
                retstate += "Schematics, maps, and texts were found, but of what.";
            }
            {
                progressed = true;
                progression += 1; //total of 8 progressions to reach game complete
                retstate += "Your scouts have found a piece of your ship that broke, this should help the repair effort. You have found" + progression + "out of 8 pieces";
            }
        }
        else
        {
            int choice = Random.Range(1, 101);
            if (choice < 25)
            {
                foreach (GameObject scout in scouts)
                {
                    scout.GetComponent<PeopleScript>().curhealth -= Random.Range(0, 9) * scout.GetComponent<PeopleScript>().maxhealth / 10;
                }
                retstate += "Your scouts have come back beaten and bruised.";
            }
            else if (choice < 50)
            {
                foreach (GameObject scout in scouts)
                {
                    scout.GetComponent<PeopleScript>().agility -= Random.Range(0, 3);
                }
                retstate += "Your scouts have been weakened by some sort of magic";
            }
            else if (choice < 53)
            {
                foreach (GameObject scout in scouts)
                {
                    scout.GetComponent<PeopleScript>().strength -= 1;
                    scout.GetComponent<PeopleScript>().endurance -= 1;
                    scout.GetComponent<PeopleScript>().proficiency -= 1;
                    if (scout.GetComponent<PeopleScript>().strength == 0 || scout.GetComponent<PeopleScript>().endurance == 0 || scout.GetComponent<PeopleScript>().proficiency == 0)
                    {
                        scout.GetComponent<PeopleScript>().agility -= 1;
                    }
                }
                retstate += "Your scouts have been weakened by some sort of magic";
            }
            else if (choice < 70)
            {
                gainenergy = 0;
                gainmetal = 0;
                gainfood = 0;
                retstate += "Forced to flee for their lives, your scouts got nothing";
            }
        }
        retstate += " You have acquired " + gainenergy + " energy, " + gainfood + " food, " + gainmetal + " metal.";
        return retstate;
    }
    
}
