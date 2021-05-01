using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [FormerlySerializedAs("Source")] public AudioSource backgroundAudio;
    [SerializeField] 
    public AudioSource jumpAudio;
    
    [SerializeField]
    private Slider Slider;
    
    private static float _currentVolume = -1f;
    

    // Start is called before the first frame update
    void Start()
    {
        if (backgroundAudio != null)
        {
            backgroundAudio.Play();
            if (_currentVolume == -1f)
            {
                _currentVolume = 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Slider != null)
        {
            if (Slider.value != _currentVolume)
            {
                Slider.value = _currentVolume;
            }

            backgroundAudio.volume = _currentVolume;
            jumpAudio.volume = _currentVolume;
        }
    }

    public void UpdateVolume(float volume)
    {
        _currentVolume = volume;
    }

    public void PlayJumpSound()
    {
        jumpAudio.Play();
    }
}
