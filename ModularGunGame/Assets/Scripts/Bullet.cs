using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rbody;

    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rbody = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SetupBullet(Vector3 direction)
    {
        rbody.linearVelocity = direction * speed;
    }
}
