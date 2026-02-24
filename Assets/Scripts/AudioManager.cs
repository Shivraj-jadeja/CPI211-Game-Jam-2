using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
            return;
        }

            // DontDestroyOnLoad(this.gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "MainMenu") {
            Play("Theme_Menu");
        } else if (currentScene.name == "DesertLand") {
            Play("Theme_Main");
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) {
            Debug.LogWarning("Souhnd: " + name + " not found!");
            return;
        }

        s.source.Play();

        // to-do
        // Add this line into the script that ur calling the sound from
        // FindObjectOfType<AudioManager>().Play("SoundName");
    }
}
