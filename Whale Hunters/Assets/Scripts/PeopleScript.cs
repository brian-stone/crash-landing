using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleScript : MonoBehaviour
{
    #region characterstats
    [Tooltip("strength = armor and mining")]
    public int strength;
    [Tooltip("endurance = health and farming")]
    public int endurance;
    [Tooltip("agility = movespeed and scouting effects")]
    public int agility;
    [Tooltip("proficiency = damage and energy production")]
    public int proficiency;
    [Tooltip("Current hp")]
    public int curhealth;
    [Tooltip("basehp for people")]
    public int basehp = 100;
    [Tooltip("maximum health")]
    public int maxhealth;
    #endregion
    #region statfunctions
    public void randomizerstats()
    {
        strength = 1;
        endurance = 1;
        agility = 1;
        proficiency = 1;
        int distributablestats = 6;
        float v1 = Random.Range(0f, 1f);
        float v2 = Random.Range(0f, 1f);
        float v3 = Random.Range(0f, 1f);
        float v4 = Random.Range(0f, 1f);
        strength += (int)((distributablestats + 1) * v1);
        endurance += (int)((distributablestats + 1) * v2);
        agility += (int)((distributablestats + 1) * v3);
        proficiency += (int)((distributablestats + 1) * v4);
        curhealth = strength * 15 + basehp;
        maxhealth = curhealth;
    }
    public void changestats(string s, int i)
    {
        if (s == "str")
        {
            strength += i;
            if (i > 0)
            {
                curhealth += 5 * i;
                maxhealth += 5 * i;
            }
            else
            {
                maxhealth -= 5 * i;
                if (curhealth > maxhealth)
                {
                    curhealth = maxhealth;
                }
            }
        }
        if (s == "agi")
        {
            agility += i;
        }
        if (s == "end")
        {
            endurance += i;
            if (i > 0)
            {
                curhealth += 15 * i;
                maxhealth += 15 * i;
            }
            else
            {
                maxhealth -= 15 * i;
                if (curhealth > maxhealth)
                {
                    curhealth = maxhealth;
                }
            }
        }
        if (s == "prof")
        {
            proficiency += i;
        }
    }
    #endregion
}
