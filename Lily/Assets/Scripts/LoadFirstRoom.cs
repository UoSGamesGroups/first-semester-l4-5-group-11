using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFirstRoom : MonoBehaviour
{
   public void ChangeScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}