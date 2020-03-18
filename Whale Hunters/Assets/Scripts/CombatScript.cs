using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    //Calculated in start, don't worry about adding these variables
    public PeopleScript person;
    public WeaponScript weapon;
    public int health;
    public int armor;
    //Temporary Variables.
    private Vector2 currentTargetVector;
    private GameObject currentTarget;
    private float speed = 1.0f;
    private float timeMult = 1.0f;
    private bool clickFind = false;
    private bool inClicking = false;
    // Start is called before the first frame update
    void Start()
    {
        person = gameObject.GetComponent<PeopleScript>();
        weapon = gameObject.GetComponent<WeaponScript>();
        health = gameObject.GetComponent<PeopleScript>().curhealth + weapon.end * 15;
        armor = person.strength + weapon.str;
        StartCoroutine(combatTurn());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator combatTurn()
    {
        
        while (true)
        {
            Attack(DetermineTarget(InRange()));
            yield return new WaitForSeconds(weapon.firerate);
            if (isDead())
            {
                Destroy(gameObject);
            }
        }

    }

    private IEnumerator nav()
    {

        
        while (Vector2.Distance(transform.position, currentTargetVector) > 0.01f)
        {
            yield return null;
            float step = speed * timeMult * Time.deltaTime; // calculate distance to move
            transform.position = Vector2.MoveTowards(transform.position, currentTargetVector, step);
            transform.LookAt(currentTargetVector);
        } 

        


    }

    private IEnumerator clickCheck()
    {

        yield return new WaitForSeconds(0.2f);
        
        
        while (clickFind)
        {
            yield return null;
            
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.GetComponent<CombatScript>() == null)
                    {
                        currentTargetVector = hit.point;
                    } else
                    {
                        currentTarget = hit.collider.gameObject;
                        currentTargetVector = hit.collider.gameObject.transform.position;
                    }
                }
                clickFind = false;
                inClicking = false;
                StartCoroutine(nav());

            }
        }
    }

    public int calculateAttackDamage()
    {
        return -1 * (weapon.damage + person.proficiency);
    }

    public int calculateDamageTaken(int damageinstance) //note damageinstance is a negative value
    {
        if( -1 * damageinstance < armor)
        {
            return -1; // -1 means 1 damage taken
        }
        else
        {
            return damageinstance + armor;
        }
    }

    public int calculateDefenseDamage()
    {
        return -1;
    }

    public void addHealth(int am)
    {
        health += am;
    }

    public bool isDead()
    {
        if (health < 0)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void Attack(GameObject other)
    {
        if (other != null)
        {
            Debug.Log("Attacking");
            if (other.GetComponent<CombatScript>() != null)
            {
                other.GetComponent<CombatScript>().addHealth(calculateAttackDamage());
            }
            else if (other.GetComponent<BuildingScript>() != null)
            {
                other.GetComponent<BuildingScript>().addHealth(-1);
            }
            else
            {
                Debug.Log("You shouldn't be here");
            }
        }
    }

    public GameObject DetermineTarget(GameObject[] targets)
    {
        if (targets != null) {
            float[] distances = new float[targets.Length];
            for (int i = 0; i < targets.Length; i++)
            {
                distances[i] = Vector2.Distance(targets[i].transform.position, gameObject.transform.position);
            }

            return targets[search(distances, Mathf.Min(distances))];
        } else
        {
            return null;
        }
        
    }

    public int search(float[] haystack, float key)
    {
        for (int i = 0; i < haystack.Length; i++)
        {
            if (haystack[i] == key)
            {
                return i;
            }
        }
        return -1;
    }

    public GameObject[] InRange()
    {
        GameObject[] enemies = new GameObject[0];
        int radius = weapon.range;
        Vector2 center = this.gameObject.transform.position;
        Collider2D [] hitColliders = Physics2D.OverlapCircleAll(center, radius);
        if (hitColliders.Length > 0)
        {
            for (int i = 0; i < hitColliders.Length; i++)
            {
                //Can replace with tag to make it more efficent. 
                if (hitColliders[i].gameObject.GetComponent<CombatScript>() != null || hitColliders[i].gameObject.GetComponent<BuildingScript>() != null)
                {
                    enemies = addToArray(enemies, hitColliders[i].gameObject);
                }
            }
            return enemies;
        }
        return null;
    }

    public GameObject[] addToArray(GameObject[] arr,GameObject other)
    {
        GameObject[] copy = new GameObject[arr.Length + 1];
        for (int i = 0;i < arr.Length;i++) {
            copy[i] = arr[i];
        }
        copy[arr.Length] = other;
        return copy;
    }

    void OnMouseDown()
    {
        if (!inClicking)
        {
            clickFind = true;
            inClicking = true;
            StartCoroutine(clickCheck());
        }
    }







}