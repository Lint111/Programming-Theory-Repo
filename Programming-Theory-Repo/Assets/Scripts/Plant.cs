using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Plant : MonoBehaviour
{
    [SerializeField]
    private float growthTime =5;
    [SerializeField]
    private float sizeScale = 1;
    [SerializeField]
    private GameObject fruit;

    [SerializeField]
    private float xzRange = 5;
    [SerializeField]
    private float yRange = 10;

    
    private float timeGrown=0;      

    // Update is called once per frame
    void Update()
    {
        if(!IsFullyGrown())
        {
            Grow();
        }
    }    

    private void OnMouseDown()
    {
        if (IsFullyGrown())
        {
            Harvest();
        }
    }

    private bool IsFullyGrown()
    {
        return timeGrown > growthTime;
    }

    private void Harvest()
    {
        GameObject go = Instantiate(fruit, transform.position, fruit.transform.rotation);
        Vector3 spawnVelocity = new Vector3(Random.Range(-xzRange, xzRange), Random.Range(0, yRange), Random.Range(-xzRange, xzRange));
        go.GetComponent<Rigidbody>().AddForce(spawnVelocity, ForceMode.Impulse);
        Destroy(gameObject);
    }

    private void Grow()
    {
        timeGrown += Time.deltaTime;
        transform.localScale = Vector3.one * (timeGrown / growthTime) * sizeScale;

        if(IsFullyGrown())
        {
            //here will be all the sound and particle effect for a fully formed plant.
            Debug.Log($"{gameObject.name} is grown");
        }
    }
}
