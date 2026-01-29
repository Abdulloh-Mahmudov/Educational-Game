using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _source;
    [SerializeField] private float _pitch;


    public void PlayKey()
    {
        _source.pitch = _pitch;
        _source.PlayOneShot(_clip);
    }
}
