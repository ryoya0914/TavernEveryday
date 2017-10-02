using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour
{
    [SerializeField]
    UnityEngine.Audio.AudioMixer mixer;

	void Start () {
	
	}
	
	void Update () {
	
	}

    public float masterVolume
    {
        set { mixer.SetFloat("masterVolume", Mathf.Lerp(-30, 20, value)); }
    }
}
