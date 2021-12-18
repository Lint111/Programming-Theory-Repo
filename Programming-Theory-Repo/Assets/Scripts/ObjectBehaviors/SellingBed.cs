using UnityEngine;

public class SellingBed : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fruit"))
        {
            other.gameObject.GetComponent<Fruit>().Sell();
        }
    }
}
