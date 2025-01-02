using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource soundSource;

    public void PlaySound()
    {
        soundSource.Play();
    }
}
