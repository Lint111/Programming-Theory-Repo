using UnityEngine;


public class Plant : MonoBehaviour
{
    [SerializeField]
    private float growthTime =5;
    [SerializeField]
    private float sizeScale = 1;
    [SerializeField]

    private GameObject fruit;       
    private GameObject Inventory;
    [SerializeField]
    private ParticleSystem dirtSparkle;
    [SerializeField]
    private ParticleSystem GreenSparkle;

    [SerializeField]
    private float xRange = 1;
    [SerializeField]
    private float zRange = 0.3f;

    private const float yPos = 0.5f;

    
    private float timeGrown=0;

    private void Awake()
    {
        Inventory = GameObject.Find("Inventory");        
    }
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

    // cheacking if the plant is fully grown.
    private bool IsFullyGrown()
    {
        return timeGrown > growthTime;
    }

    //releasing a plantbed to be used again, spawning fruit and partical effects.
    //destroying the plant.
    private void Harvest()
    {
        //free the plant bed to be used again.
        transform.parent.GetComponent<PlantBed>().FreeBed();
        SpawnFruit(3);
        PlayParticleEffect(dirtSparkle);
        Destroy(gameObject);

    }

    //encreasing the size of the plant over time.
    private void Grow()
    {
        timeGrown += Time.deltaTime;
        transform.localScale = Vector3.one * (timeGrown / growthTime) * sizeScale;

        if(IsFullyGrown())
        {
            //here will be all the sound and particle effect for a fully formed plant.
            PlayParticleEffect(GreenSparkle);
        }
    }
    //spawning random amount of fruits with the minimum amount as 1.
    private void SpawnFruit(int maxRandomFruits)
    {
        int numberOfFruits = Random.Range(1, maxRandomFruits);
        for (int i=0; i < numberOfFruits; i++)
        {
            //Set the fruit spwan position in the inventory and spawn it.
            Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), Random.Range(0, yPos), Random.Range(-zRange, zRange));
            Instantiate(fruit, Inventory.transform.position + spawnPos, fruit.transform.rotation);
        }
    }

    //handeling the spawning playing and destroying of particle effects.
    private void PlayParticleEffect(ParticleSystem PS)
    {
        ParticleSystem ParticalEffect = Instantiate(PS, transform.position, PS.transform.rotation);
        ParticalEffect.Play();
        Destroy(ParticalEffect,ParticalEffect.main.duration);
    }
}
