using UnityEngine;

public class PlantBed : MonoBehaviour
{
    public GameObject Plant;

    private bool plotBusy = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fruit") && !plotBusy)
        {
            plotBusy = true;
            Destroy(other.gameObject);            
            GameObject go = Instantiate(Plant, transform.position + new Vector3(0, 0.1f, 0), Plant.transform.rotation);
            go.transform.parent = this.transform;
        }
    }
    
    public void FreeBed()
    {
        plotBusy = false;
    }
}
