using UnityEngine;
using UnityEngine.UI;

public class VCAControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private FMOD.Studio.VCA vca;
    private Slider slider;

    [Header("settings FMOD")]
    [SerializeField] private string vcaPath;
    [SerializeField] private string saveKey;

    [Header("Sound Level")]
    [SerializeField] private float vcaVolume;
    void Start()
    {
        slider = GetComponent<Slider>();
        //vca = FMODUnity.RuntimeManager.GetVCA(path:"vca:/Music");
        vca = FMODUnity.RuntimeManager.GetVCA(vcaPath);

        float saveVolume = PlayerPrefs.GetFloat(saveKey, defaultValue: 1);
        vca.getVolume(out vcaVolume);
    }

    public void SetVolume(float volume)
    {
        vca.setVolume(volume);

        PlayerPrefs.SetFloat(saveKey, volume);
    }
}
