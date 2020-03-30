using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    //TODO: make this is a singleton class

    bool day = true; //eventually we'll link this to the game controller

    [SerializeField]
    private GameObject UIVillagerPrefab;
    [SerializeField]
    private float entryHeight;

    List<GameObject> villagers = new List<GameObject>();

    public void AddVillager(string name)
    {
        GameObject villager = Instantiate(UIVillagerPrefab, new Vector3(0, -(villagers.Count + 1) * entryHeight, 0), Quaternion.identity);
        Text nametext = villager.GetComponent<Text>();
        nametext.text = name;

        villagers.Add(villager);
    }

    public void RemoveVillager(string name)
    {
        GameObject villager = villagers.Find(obj => matches(name, obj));
        villagers.Remove(villager);
    }

    private bool matches(string name, GameObject obj)
    {
        return name == obj.GetComponent<Text>().text;
    }

    public void guard(Text name)
    {

    }

    public void mine(Text name)
    {

    }

    public void generate(Text name)
    {

    }

    public void scout(Text name)
    {

    }

    public void farm(Text name)
    {

    }

    public void hospital(Text name)
    {

    }
}
