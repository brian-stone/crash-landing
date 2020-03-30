using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Tooltip("collider to see what enemies are in detection range")]
    public Collider2D enemyDetect;
    [Tooltip("list of objects in det range")]
    public List<GameObject> detectedlist;
    public CombatScript cs;
    /*[Tooltip("collider to see what enemies are in attack range")]
    public Collider2D enemyinrange;
    [Tooltip("list of objects in det range")]
    public List<GameObject> rangelist;*/
    //targetposition is where we move to.

    private void Start()
    {
        detectedlist = new List<GameObject>();
    }
    private GameObject closestenemy(List<GameObject> detectedlist)
    {
        GameObject returned = gameObject;
        double mindist = double.MaxValue;
        foreach(GameObject enemy in detectedlist)
        {
            double dist = Vector2.Distance(enemy.transform.position, transform.position);
            if (mindist > dist)
            {
                mindist = dist;
                returned = enemy;
            }
        }
        return returned;
    }
    private void Update()
    {
        detectedlist = enemyDetect.GetComponent<EnemyColliderScript>().getlist();
        cs.currentTargetVector = closestenemy(detectedlist).transform.position;
    }
    
}
