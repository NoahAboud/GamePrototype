using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Slider healthBar;
    public int health;
    public GameObject boss;
    public GameObject victoryScreenUI;
    public GameObject player;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;

        if (health == 100)
        {
            audioManager.PlaySFX(audioManager.Explosion);
        }
    }
  
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 100)
        {
            GetComponent<Animator>().SetBool("Second Phase", true);
            boss.GetComponent<RockShooting>().enabled = false;
         
        }

   



        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
            victoryScreenUI.SetActive(true);
            player.GetComponent<playercontroller>().enabled = false;
        }

       
    }

 



}
