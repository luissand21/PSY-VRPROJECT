using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    public string newScene = null;
    public void SceneChange()
    {
        SceneManager.LoadScene(newScene);
    }
}
