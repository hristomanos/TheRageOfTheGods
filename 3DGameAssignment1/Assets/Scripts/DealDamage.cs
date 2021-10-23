using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is about adding functionality to when a projectile collides with something
public class DealDamage : MonoBehaviour
{
   [SerializeField] GameObject m_ImpactVFX;
    [SerializeField] float m_TimeAlive;

    private void Start()
    {
        Destroy(gameObject, m_TimeAlive);
    }

    bool collided = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Player" && !collided)
        {
            collided = true;

            GameObject impact = Instantiate(m_ImpactVFX, collision.contacts[0].point, Quaternion.identity);

            Destroy(impact, 1);
            Destroy(gameObject);
        }
    }
    






}