using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioClip[] musicTracks;
    private AudioSource audioSource;

    private int currentTrackIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (musicTracks.Length > 0)
        {
            PlayMusicTrack(currentTrackIndex);
        }
        else
        {
            Debug.LogError("No music tracks assigned to the MusicController!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            PlayNextTrack();
        }
    }
    public void PlayMusicTrack(int trackIndex)
    {
    if (trackIndex >= 0 && trackIndex < musicTracks.Length)
        {
            audioSource.Stop();

            audioSource.clip = musicTracks[trackIndex];
            audioSource.Play();

            currentTrackIndex = trackIndex;
        }
    else
        {
            Debug.LogWarning("Invalid track index!");
        }
    }
    public void PlayNextTrack()
    {
        int nextTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;

        PlayMusicTrack(nextTrackIndex);
    }
    public void MusicStop()
    {
        audioSource.Stop();
    }
}
