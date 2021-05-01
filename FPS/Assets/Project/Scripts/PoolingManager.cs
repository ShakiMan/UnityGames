using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    private static PoolingManager instance;
    private int projectilesAmount = 22;
    private List<GameObject> projectiles;
    
    public GameObject projectilePrefab;
    public static PoolingManager Instance => instance;

    void Awake()
    {
        instance = this;
        projectiles = new List<GameObject>();
        for (int i = 0; i < projectilesAmount; i++)
        {
            GameObject prefab = Instantiate(projectilePrefab);
            prefab.transform.SetParent(transform);
            prefab.SetActive(false);
            projectiles.Add(prefab);
        }
    }

    public GameObject GetProjectile()
    {
        foreach (var projectile in projectiles)
        {
            if (!projectile.activeInHierarchy)
            {
                projectile.SetActive(true);
                return projectile;
            }
        }

        GameObject prefab = Instantiate(projectilePrefab);
        prefab.transform.SetParent(transform);
        projectiles.Add(prefab);
        return prefab;
    }
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}