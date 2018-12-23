using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LearnGameManajer : MonoBehaviour {
    [SerializeField]
    private AudioSource AudioSrc;

    private void Awake()
    {
        if (AudioSrc == null)
            AudioSrc = GetComponent<AudioSource>();
    }
}
