using UnityEngine;
using  UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]private string sceneName = "";

    public void ChangeScene(string _name)
    {
        SceneManager.LoadScene(_name);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
