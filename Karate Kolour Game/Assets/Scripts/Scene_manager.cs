using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_manager : MonoBehaviour
{
    public void loadscene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void kill_game()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
