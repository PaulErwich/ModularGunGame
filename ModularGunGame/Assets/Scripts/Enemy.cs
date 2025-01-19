using UnityEngine;

public class Enemy : MonoBehaviour
{
    GunRandomiser gr;

    private Rigidbody rb;

    private gun gun;
    private float health;
    private float moveSpeed;

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
}
