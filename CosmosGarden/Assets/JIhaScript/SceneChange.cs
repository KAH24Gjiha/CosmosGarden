using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public string SceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Changed()
    { 
        SceneManager.LoadScene(SceneName);
    }
    public void Quit()
    {
        DataManager.Instance.SaveGameData();
        Application.Quit();
    }

}
