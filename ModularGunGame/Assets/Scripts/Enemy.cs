using UnityEngine;

public class Enemy : MonoBehaviour
{
    GunRandomiser gr;

    private Rigidbody rb;

    private gun gun;
    private float health;

    private void Awake()
    {
        NewGun();
        health = 100;
    }

    private void NewGun()
    {
        gun = gr.RequestGun();
        // Makes the enemies have worse accuracy otherwise they would have aimbot sometimes
        gun.accuracy += 2;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TakeDamage();
    }

    private void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    private void Shoot()
    {

    }

    private void Move()
    {
        
    }
}
