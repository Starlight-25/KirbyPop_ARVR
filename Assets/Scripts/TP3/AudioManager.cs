using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip PopSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void TriggerPopSound()
    {
        transform.GetComponent<AudioSource>().clip = PopSound;
        transform.GetComponent<AudioSource>().Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
