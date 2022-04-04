using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour
{
    private AudioSource soundeffect;
    Movement movement;
    EnemyAnimation eanimation;
    private void Start()
    {
        soundeffect = gameObject.GetComponent<AudioSource>();
        eanimation = gameObject.GetComponent<EnemyAnimation>();
        movement = gameObject.GetComponent<Movement>();
        if (eanimation != null)
        {
            eanimation.Attack += PlaySound;
        }
        if (movement != null)
        {
            movement.onMove += PlaySound;
        }
    }
    void PlaySound()
    {
        soundeffect.Play();
    }

}
