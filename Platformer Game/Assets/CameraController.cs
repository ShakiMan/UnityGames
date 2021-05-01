using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        Keyboard keyboard = InputSystem.GetDevice<Keyboard>();
        
        if (keyboard.qKey.isPressed)
        {
            _audioSource.volume = (_audioSource.volume * 100 - 1) / 100;
        }
        if (keyboard.eKey.isPressed)
        {
            _audioSource.volume = (_audioSource.volume * 100 + 1) / 100;
        }
        
        // if(Input.GetKey(KeyCode.Q))
        // {
        //     _audioSource.volume = (_audioSource.volume * 100 - 1) / 100;
        // }
        // else if(Input.GetKey(KeyCode.E))
        // {
        //     _audioSource.volume = (_audioSource.volume * 100 + 1) / 100;
        // }
    }
}
