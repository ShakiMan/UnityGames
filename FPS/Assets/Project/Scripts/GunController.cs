using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Camera cam;
    private float range = 100f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // Shoot();
        }
    }

    void Shoot()
    {
        Debug.DrawRay(transform.parent.position, 3 * transform.parent.forward, Color.blue, 5.0f);
        Debug.Log("sterzla");
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Enemy")
            {
                EnemyController enemy = hit.transform.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    Debug.Log("trafił");
                    enemy.GetHit();
                }
            }
        }
    }
}