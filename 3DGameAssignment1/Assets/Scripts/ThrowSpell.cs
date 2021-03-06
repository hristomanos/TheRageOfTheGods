using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is including the shooting mechanic but also describes how a bullet should behave when shot.
public class ThrowSpell : MonoBehaviour
{

    [SerializeField] GameObject m_SpellPrefab;
    [SerializeField] Transform m_SpawinningPoint;
    [SerializeField] Animator m_WandAnimator;

    [SerializeField] Camera m_Cam;
    [SerializeField] float projectileSpeed;
    Vector3 m_Destination;
    [SerializeField] AudioSource m_FireBallShotAudioSource;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            // m_WandAnimator.Play("WandDown");
            //m_WandAnimator.SetBool("isWandDown", true);
            //m_WandAnimator.SetBool("isWandUp", false);
        }
        //} else if(Input.GetMouseButtonUp(0))
        //{
        //    m_WandAnimator.SetBool("isWandUp", true);
        //    m_WandAnimator.SetBool("isWandDown", false);
        //}
    }

    //Break shooting mechanic to two staget
    //One is chargeFireball when mouse is hold
    //Second is shoot when mouse is up
    //Which involves releasing the fireball

    //Player shoots a fireball towards the center of the camera.
    void Shoot()
    {
        //Cast a ray from the center of the camera
        Ray ray = m_Cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        //Set destination point for when something is hit or set default destination point 
        if (Physics.Raycast(ray, out hit))
        {
            m_Destination = hit.point;
        }
        else
            m_Destination = ray.GetPoint(1000);

        //Play wand gesture animation
        m_WandAnimator.Play("WandDown");

        //Play fireball shot sound FX
        m_FireBallShotAudioSource.Play();

        //Instantiate a fireball prefab at the spawnning position
        GameObject projectile =  Instantiate(m_SpellPrefab, m_SpawinningPoint.position, m_SpawinningPoint.rotation);

        //Set direction by getting the normalised vector from the destination
        //to the spawnning point and multiply by speed to make it move towards that direction
        projectile.GetComponent<Rigidbody>().velocity = (m_Destination - m_SpawinningPoint.position).normalized * projectileSpeed;
    }
}
