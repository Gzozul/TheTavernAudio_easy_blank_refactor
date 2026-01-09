using UnityEngine;
using UnityEngine.UI;

public class VCAControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private FMOD.Studio.VCA vca;
    private Slider slider;
    [SerializeField] private float vcaVolume;
    void Start()
    {
        vca = FMODUnity.RuntimeManager.GetVCA(path:"vca:/Music");
        vca.getVolume(out vcaVolume);
    }

    public void SetVolume(float volume)
    {
        vca.setVolume(volume);
    }
}
