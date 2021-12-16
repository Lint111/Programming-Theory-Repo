using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Plant : MonoBehaviour
{
    public float growthTime =5;
    public float sizeScale = 1;
    public GameObject fruit;
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
        Instantiate(fruit, transform.position, fruit.transform.rotation);
        Destroy(gameObject);
    }

    private void Grow()
    {
        timeGrown += Time.deltaTime;
        transform.localScale = Vector3.one * (timeGrown / growthTime) * sizeScale;
    }
}
