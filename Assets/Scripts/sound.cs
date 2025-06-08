using UnityEngine;

public class sound : MonoBehaviour
{
    public AudioSource audio_source;
    void Start()
    {
        audio_source = gameObject.GetComponent<AudioSource>();
    }
    public void play_sound(AudioClip audio)
    {
        audio_source.PlayOneShot(audio);
    }
}
