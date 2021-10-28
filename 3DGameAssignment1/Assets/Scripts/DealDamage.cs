using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is about adding functionality to when a projectile collides with something
public class DealDamage : MonoBehaviour
{
   [SerializeField] GameObject m_ImpactVFX;
   [SerializeField] float m_TimeAlive;
   [SerializeField] int m_Damage;
   [SerializeField] string m_Shooter;
   [SerializeField] string m_Receiver;

    private void Start()
    {
        Destroy(gameObject, m_TimeAlive);
    }

    bool collided = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != m_Shooter && !collided)
        {
            collided = true;

            //if Enemy, Call AI script and call TakeDamage()
            if (collision.gameObject.CompareTag(m_Receiver))
            {
                switch(m_Receiver)
                {
                    case "Enemy":
                        collision.gameObject.GetComponent<AI>().TakeDamage(m_Damage);
                        break;
                    case "Player":
                        collision.gameObject.GetComponentInChildren<Player>().TakeDamage(m_Damage);
                        break;
                }
               
            }

            GameObject impact = Instantiate(m_ImpactVFX, collision.contacts[0].point, Quaternion.identity);

            Destroy(impact, 1);
            Destroy(gameObject);
        }
    }
    






}
