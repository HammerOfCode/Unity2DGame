using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Animator animator;
    
    public int health = 100;
    public GameObject deathEffect;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
            
        }
       
    }
    void Die() {
        ScoreScript.scoreValue += 1000;
       Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
   
       
            
    }
}
