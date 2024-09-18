using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int health;

    
    public GameManager gameManager;
    [SerializeField]private bool isDead;
    void Start()
    {
       health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0 && !isDead)
        {
            isDead = true;
            gameObject.SetActive(false);   
            gameManager.gameOver();
            Debug.Log("Player is Dead");
        }
    }

    
   
}
