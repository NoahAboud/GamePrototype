using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int health;
    public Animator animator;

    
    public GameManager gameManager;
    [SerializeField]private bool isDead;
    void Start()
    {
       health = maxHealth;
       
    }

    private void Update()
    {
       
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0 && !isDead)
        {
            isDead = true;
             
            gameManager.gameOver();
            Debug.Log("Player is Dead");
            animator.SetBool("IsDead", true);
        }
    }

    
   
}
