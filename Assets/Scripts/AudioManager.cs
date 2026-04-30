using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    string mixerName;
    public AudioMixer mixer;

    public void HoldMixerName(string name)
    {
        mixerName = name;
    }
    public void UpdateMixerValue(float value)
    {
        mixer.SetFloat(mixerName, value);
    }

    /////// can't do this bc unity event, do the ones above
    
    public void ExpectedFunction(string name, float value)
    {
        mixer.SetFloat(name,value);
    }
}
