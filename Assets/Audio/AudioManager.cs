using UnityEngine.Audio;
using System;
using UnityEngine;

using Random = UnityEngine.Random;


public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public static AudioManager instance;

	// Use this for initialization
	void Awake ()
    {
        if(instance == null)
             instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}

    void Start()
    {
       Play("bso_1");
        LazerOFF();
    }
	
	public void Play (string name )
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s==null)
        {
            Debug.LogWarning("Sound:" + name + "no se encuentra");
            return;
        }

        s.source.Play();
    }
    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "no se encuentra");
            return;
        }

        s.source.Pause();
    }

    public void silenceBso(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "no se encuentra");
            return;
        }
        s.volume = 0;
    }

    public void LazerON()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Enemy_Laser_1");
        Sound s2 = Array.Find(sounds, sound => sound.name == "Enemy_Laser_2");
        s.volume = 0.8f;
        s2.volume = 1f;
    }
    public void LazerOFF()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Enemy_Laser_1");
        Sound s2 = Array.Find(sounds, sound => sound.name == "Enemy_Laser_2");
        s.volume = 0;
        s2.volume = 0;
    }

    public void changeBSO(int i)//0 day/night - 1 night/day
    {
        if(i ==0)
        {
            //Pause("bso_2");
            //Play("bso_1");
            //       silenceBso("bso_1");
            Pause("bso_1");
            Play("bso_2");
        }
        if ( i== 1)
        {
       //     silenceBso("bso_2");
            Pause("bso_2");
            Play("bso_1");

        }
    }


    public void PlayRandAudio(string name, string name2, string name3)
    {
        int i = Random.Range(0, 3);

        switch (i)
        {
            case 1:
                Play(name);
                break;
            case 2:
                Play(name2);
                break;
            case 0:
                Play(name3);
                break;
        }
    }
    public void PlayRandAudio2(string name, string name2, string name3, string name4)
    {
        int i = Random.Range(0, 4);

        switch (i)
        {
            case 1:
                Play(name);
                break;
            case 2:
                Play(name2);
                break;
            case 3:
                Play(name3);
                break;
            case 0:
                Play(name4);
                break;
        }
    }
}

//FindObjectOfType<AudioManager>().Play("audio para reproducir");