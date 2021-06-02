using UnityEngine;

[RequireComponent(typeof(CustomSceneManager))]
public class DeveloperTools : MonoBehaviour
{
    private float prevVolume;
    private bool isMuted;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            DecreaseVolume(0.05f);
        else if (Input.GetKeyDown(KeyCode.K))
            IncreaseVolume(0.05f);
        else if (Input.GetKeyDown(KeyCode.M))
            ToggleMuteAudio();
        else if (Input.GetKeyDown(KeyCode.R))
            ReloadScene();

    }

    private void ToggleMuteAudio()
    {
        if (isMuted)
            UnmuteAudio();
        else
            MuteAudio();
    }

    private void MuteAudio()
    {
        prevVolume = AudioListener.volume;
        AudioListener.volume = 0.0f;
        isMuted = true;
    }

    private void UnmuteAudio()
    {
        AudioListener.volume = prevVolume;
        isMuted = false;
    }

    private void IncreaseVolume(float amount)
    {
        if (isMuted)
            UnmuteAudio();
        AudioListener.volume = Mathf.Min(AudioListener.volume + amount, 1.0f);
    }

    private void DecreaseVolume(float amount)
    {
        if (isMuted)
            UnmuteAudio();
        AudioListener.volume = Mathf.Max(AudioListener.volume - amount, 0.0f);
    }

    private void ReloadScene()
    {
        GetComponent<CustomSceneManager>().ReloadScene();
    }
}
