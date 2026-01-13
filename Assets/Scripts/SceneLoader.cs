using UnityEngine;
using UnityEngine.SceneManagement;  
public class SceneLoader : MonoBehaviour
{
    [Header("Scene")]
    [SerializeField] private Object scene;
    public void LoadScene()
    {
        if (scene != null)
        {
            SceneManager.LoadScene(scene.name);
        }
        else
        {
            Debug.LogError(message:"Scene is not added.");
        }
    }
}
