using UnityEngine;

public class Enemy : MonoBehaviour
{
    GunRandomiser gr;

    private Rigidbody rb;

    private gun gun;
    private float health;

    private void Start()
    {
        NewGun();
        health = 100;
    }

    private void NewGun()
    {
        gun = gr.RequestGun();
    }
}
