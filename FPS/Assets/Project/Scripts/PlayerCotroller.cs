using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCotroller : MonoBehaviour
{
    public Camera fpCamera;

    private int lifes = 3;
    public int Lifes => lifes;
    private bool isAttacked;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectileObj = PoolingManager.Instance.GetProjectile();
            projectileObj.transform.position = fpCamera.transform.position + fpCamera.transform.forward;
            projectileObj.transform.forward = fpCamera.transform.forward;
        }
    }

    void OnTriggerEnter(Collider colliderHit)
    {
        if (colliderHit.GetComponent<EnemyController>() != null)
        {
            if (!isAttacked)
            {
                lifes--;
                if (lifes == 0)
                {
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                }

                isAttacked = true;
                StartCoroutine(AttackedRoutine(2f));
            }
        }
    }

    IEnumerator AttackedRoutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isAttacked = false;
    }
}