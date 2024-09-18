using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRockScript : MonoBehaviour
{
    private GameObject rockTrajectory;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    public PlayerHealth player;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rockTrajectory = GameObject.FindGameObjectWithTag("RockTrajectory");

        Vector3 direction = rockTrajectory.transform.position - transform.position; 
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 4)
        {
            Destroy(gameObject);
        }
 
    }

     void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.CompareTag("Player"))
        {
          Debug.Log("HitPlayer");
          

           PlayerHealth pHealth = other.gameObject.GetComponent<PlayerHealth>();
           pHealth.TakeDamage(damage);

            Destroy(gameObject);
        }


    
    }
   
}
