using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{
    private static Soundmanager instance;
    public static Soundmanager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singletonObject = new GameObject();
                instance = singletonObject.AddComponent<Soundmanager>();
                singletonObject.name = typeof(Soundmanager).ToString() + " (Singleton)";
                DontDestroyOnLoad(singletonObject);
            }
            return instance;
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    
    public AudioSource Sound;
    public AudioClip in_btn;
    public AudioClip out_btn;
    public AudioClip next_talk;
    public AudioClip money;
    public AudioClip drum;
    public AudioClip coin;
    public AudioClip book;
    public AudioClip die;
    public AudioClip respwan;



    public string sound_name;

    public void Playsound(string n){
        sound_name = n;
        switch(sound_name){
            case "in_btn":
                Sound.clip = in_btn;
                break;
            case "out_btn":
                Sound.clip = out_btn;
                break;
            case "next_talk":
                Sound.clip = next_talk;
                break;
            case "money":
                Sound.clip = money;
                break;
            case "drum":
                Sound.clip = drum;
                break;
            case "coin":
                Sound.clip = coin;
                break;
            case "book":
                Sound.clip = book;
                break;
            case "die":
                Sound.clip = die;
                break;
            case "respwan":
                Sound.clip = respwan;
                break;
        }
        Sound.Play();
    }
}