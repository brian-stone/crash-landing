using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderScript : MonoBehaviour
{
    public List<GameObject> retlist;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playercombatunit" || collision.gameObject.tag == "hospital" || collision.gameObject.tag == "factory" || collision.gameObject.tag == "mine" || collision.gameObject.tag == "farm" || collision.gameObject.tag == "generator")
        {
            retlist.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (retlist.Contains(collision.gameObject))
        {
            retlist.Remove(collision.gameObject);
        }
    }

    private void updatelist()
    {
        foreach (GameObject exists in retlist)
        {
            if (exists == null)
            {
                retlist.Remove(exists);
            }
        }
    }

    public List<GameObject> getlist()
    {
        updatelist();
        return retlist;
    }
}
