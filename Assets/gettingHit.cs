using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gettingHit : MonoBehaviour
{
    public int maxHealth = 100;
    int health;
    GameObject bulletGameObject;
    public GameObject healthBar;
    float healthUnit;

    Vector3 ChangeVector;


    // Start is called before the first frame update
    void Start()
    {
        healthUnit = healthBar.transform.localScale.x / maxHealth;

        health = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            bulletGameObject = other.gameObject;
            int damage = bulletGameObject.GetComponent<bullet>().damage;
            
            health = health - damage;
            Destroy(other.gameObject);

            ChangeVector = new Vector3(healthUnit*damage, 0f, 0f);
            healthBar.transform.localScale -= ChangeVector;
            healthBar.transform.position -= ChangeVector;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
