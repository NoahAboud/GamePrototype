using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public Health playerHealth;
    List<HealthHearts> hearts = new List<HealthHearts>();

    private void Start()
    {
        DrawHearts();
    }
    public void DrawHearts()
    {
        ClearHearts();
        float maxHealthRemainder = playerHealth.maxHealth % 2;
        int heartsToMake = (int)((playerHealth.maxHealth / 2) + maxHealthRemainder);
        for(int i =0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }
    }


    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthHearts heartComponent = newHeart.GetComponent<HealthHearts>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }

    public void ClearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHearts>();
    }
}
