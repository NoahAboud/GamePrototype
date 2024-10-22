using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockShooting : MonoBehaviour
{
    public GameObject Rock;
    public Transform rockPos;
    public bool gameOver;
    public PlayerHealth playerHealth;
    AudioManager audioManager;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if (timer > 2)
        {
            timer = 0;
            shoot();
        }
        
    }

    void shoot()
    {
        Instantiate(Rock, rockPos.position, Quaternion.identity);
        audioManager.PlaySFX(audioManager.Summon);

    }
}
