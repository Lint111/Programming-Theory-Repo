using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBed : MonoBehaviour
{
    public GameObject Plant;

    private bool plotBusy = false;

    private void FixedUpdate()
    {
        plotBusy = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fruit") && !plotBusy)
        {
            plotBusy = true;
            Destroy(other.gameObject);            
            Instantiate(Plant, transform.position + new Vector3(0, 0.1f, 0), Plant.transform.rotation);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Plant"))
            plotBusy = true;
    }
}
