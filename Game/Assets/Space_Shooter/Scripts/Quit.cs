using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{   
    public void QuitGame() {
#if UNITY_ED�TOR
        Application.Quit();
#else
        UnityEditor.EditorApplication.isPlaying = false;

#endif

    }
}
