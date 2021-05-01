using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool isHitted;

    private PlayerCotroller player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerCotroller>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    void OnTriggerEnter(Collider colliderHit)
    {
        if (colliderHit.GetComponent<Projectile>() != null && !isHitted && colliderHit.tag != "Enemy")
        {
            isHitted = true;
            Projectile projectile = colliderHit.GetComponent<Projectile>();
            projectile.gameObject.SetActive(false);
            ParticleSystem system = this.GetComponentInChildren<ParticleSystem>();
            AudioSource source = GetComponent<AudioSource>();
            transform.position += new Vector3(0, 0.5f, 0);
            agent.enabled = false;
            system.Play();
            source.Play();
            Destroy(gameObject, system.duration);
        }
    }

    public void GetHit()
    {
        if (isHitted)
        {
            isHitted = true;
            ParticleSystem system = this.GetComponentInChildren<ParticleSystem>();
            AudioSource source = GetComponent<AudioSource>();
            transform.position += new Vector3(0, 0.5f, 0);
            agent.enabled = false;
            system.Play();
            source.Play();
            Destroy(gameObject, system.duration);
        }
    }
}