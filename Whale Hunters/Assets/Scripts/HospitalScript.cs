using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalScript : MonoBehaviour
{
    public GameObject[] hospitalpeople; //people assigned to heal in hospital
    public void hospitalHeal()
    {
        foreach (GameObject person in hospitalpeople)
        {
            person.GetComponent<PeopleScript>().curhealth = person.GetComponent<PeopleScript>().maxhealth;
        }
    }
}
