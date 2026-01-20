using UnityEngine;
using FMODUnity;

public class FireplaceInteract : MonoBehaviour, IInteractable
{
    [HeaderAttribute("Ognisko")]
    [SerializeField] private GameObject ognisko;
    [Header("Sounds")]
    [SerializeField] private EventReference fireplaceStart;
    [SerializeField] private EventReference fireplaceStop;
    [Header("State")]
    [SerializeField] private bool isActive = true;
    public void Interact()
    {
        isActive= !isActive;
        if(ognisko != null)
        {
            ognisko.SetActive(isActive);
            PlayInteractSound();
        }
    }

    private void PlayInteractSound()
    { 
        if (isActive)
        {
            RuntimeManager.PlayOneShot(fireplaceStart);
        }
        else
        {
            RuntimeManager.PlayOneShot(fireplaceStop);
        }
    }
}