using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScenes : MonoBehaviour
{
    public void Map1()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
