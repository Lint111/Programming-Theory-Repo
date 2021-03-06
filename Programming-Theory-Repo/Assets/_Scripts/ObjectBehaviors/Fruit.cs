using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField]
    private int pointsValue = 5;

    private Rigidbody rb;
    private HighScoreManager HSManager;

    const float scaler = 0.1f;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        HSManager = GameObject.Find("Canvas").GetComponent<HighScoreManager>();
    }
    private void FixedUpdate()
    {
        AddDrag();
    }

    //adding drag and preventing the fruit from rolling for ever.
    private void AddDrag()
    {
        rb.inertiaTensorRotation = new Quaternion(0.01f, 0.01f, 0.01f, 1f);
        rb.AddTorque(-rb.angularVelocity * scaler);
    }
    //handeling the trading of fruits for points.
    public void Sell()
    {
        HSManager.AddScore(pointsValue);
        Destroy(gameObject);
    }
}
