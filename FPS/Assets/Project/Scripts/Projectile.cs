using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 12f;
    private float lifeTime = 3f;
    private float timepiece;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        timepiece = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        timepiece -= Time.deltaTime;
        if (timepiece <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
