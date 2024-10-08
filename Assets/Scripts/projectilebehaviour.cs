using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilebehaviour : MonoBehaviour
{
    public float Speed = 4.5f;

    void Start()
    {
        
    }

   
    private void Update()
    {
        transform.position += -transform.right * Time.deltaTime * Speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<BossDamage>().TakeDamage(1);
        }
        Destroy(gameObject);
    }
}
