using System.Collections.Generic;
using System.Xml;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomSoundPlayer : MonoBehaviour {
    [SerializeField]
    private List<AudioClip> sounds; 

    [SerializeField]
    [Tooltip("Should go from 0 to 100, with steps, because of reasons. Laziness, mostly. Example: First item is 20, second item is 80 (so 60% chances) and last one 100 (so 20% chances).")]
    private List<float> chancesToBeChosenPercentage;
    private AudioSource source;

    void Start()
    {
        if (sounds.Count != chancesToBeChosenPercentage.Count)
        {
            Debug.LogError("The two Lists should be of equal size");
        }
        source = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if (source.isPlaying)
        {
            return;
        }
        var rand = Random.Range(0, 100);
        source.clip = sounds[0];
        for (int i = 0; i < sounds.Count; i++)
        {
            if (chancesToBeChosenPercentage[i] <= rand)
            {
                source.clip = sounds[i];
            }
        }
        source.Play();
    }
}
