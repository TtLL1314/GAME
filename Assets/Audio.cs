using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class Audio : MonoBehaviour
{
    void Start()
    {

    }

    public enum EngineAudioOptions
    {
        Simple,
        FourChannel
    }

    public EngineAudioOptions engineSoundStyle = EngineAudioOptions.Simple;
    public AudioClip lowAccelClip;                                              
    public AudioClip lowDecelClip;                                              
    public AudioClip highAccelClip;                                             
    public AudioClip highDecelClip;                                             
    public float pitchMultiplier = 1f;                                          // Used for altering the pitch of audio clips
    public float lowPitchMin = 1f;                                              // The lowest possible pitch for the low sounds
    public float lowPitchMax = 6f;                                              // The highest possible pitch for the low sounds
    public float highPitchMultiplier = 0.25f;                                   // Used for altering the pitch of high sounds
    public float maxRolloffDistance = 500;                                      // The maximum distance where rollof starts to take place
    public float dopplerLevel = 1;                                              // The mount of doppler effect used in the audio
    public bool useDoppler = true;                                              // Toggle for using doppler

    private AudioSource m_LowAccel; // Source for the low acceleration sounds
    private AudioSource m_LowDecel; // Source for the low deceleration sounds
    private AudioSource m_HighAccel; // Source for the high acceleration sounds
    private AudioSource m_HighDecel; // Source for the high deceleration sounds
    private bool m_StartedSound; // flag for knowing if we have started sounds
                                 //private CarController m_CarController; // Reference to car we are controlling
    public CarController m_CarController;

    private void StartSound()
    {
        m_HighAccel = SetUpEngineAudioSource(highAccelClip);
        m_StartedSound = true;
    }


    private void StopSound()
    {
        foreach (var source in GetComponents<AudioSource>())
        {
            Destroy(source);
        }

        m_StartedSound = false;
    }


    // Update is called once per frame
   void Update()
    {
        float camDist = (Camera.main.transform.position - transform.position).sqrMagnitude;

        if (m_StartedSound && camDist > maxRolloffDistance * maxRolloffDistance)
        {
            StopSound();
        }

        if (!m_StartedSound && camDist < maxRolloffDistance * maxRolloffDistance)
        {
            StartSound();
        }

        if (m_StartedSound)
        {
            m_HighAccel.dopplerLevel = useDoppler ? dopplerLevel : 0;
            m_HighAccel.volume = 1;
        }
    }


    // sets up and adds new audio source to the gane object
    private AudioSource SetUpEngineAudioSource(AudioClip clip)
    {
        // create the new audio source component on the game object and set up its properties
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = 0;
        source.spatialBlend = 1;
        source.loop = true;

        // start the clip from a random point
        source.time = Random.Range(0f, clip.length);
        source.Play();
        source.minDistance = 5;
        source.maxDistance = maxRolloffDistance;
        source.dopplerLevel = 0;
        return source;
    }


    // unclamped versions of Lerp and Inverse Lerp, to allow value to exceed the from-to range
    private static float ULerp(float from, float to, float value)
    {
        return (1.0f - value) * from + value * to;
    }
}

