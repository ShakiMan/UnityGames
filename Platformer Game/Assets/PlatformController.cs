using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private const float _speed = 1.25f; 
    public Transform start, end;
    Vector3 _nextPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        _nextPosition = start.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position == start.position)
        {
            _nextPosition = end.position;
        }
        if (transform.position == end.position)
        {
            _nextPosition = start.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, _nextPosition, _speed * Time.deltaTime);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(start.position, end.position);
    }
}
