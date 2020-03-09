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
    }
    public void changestats(string s, int i)
    {
        if (s == "str")
        {
            strength += i;
        }
        if (s == "agi")
        {
            agility += i;
        }
        if (s == "end")
        {
            endurance += i;
        }
        if (s == "prof")
        {
            proficiency += i;
        }
    }
    #endregion
}
