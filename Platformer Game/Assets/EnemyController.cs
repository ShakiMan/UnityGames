using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    public GameObject attack;

    private const float ShotTimePeriod = 3f;

    private void OnEnable()
    {
        StartCoroutine(StartShooting());
    }

    private IEnumerator StartShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(ShotTimePeriod);
            Instantiate(
                attack,
                firePoint.position,
                quaternion.identity,
                GameObject.FindGameObjectWithTag("Level").transform);
        }
    }
}
