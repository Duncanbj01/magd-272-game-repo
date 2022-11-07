using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Collided with {collision.gameObject.name}");
            collision.gameObject.GetComponent<HealthDemo>().takeDamage(10); 
        }
    }
}
