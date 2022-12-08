using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Assets.Scripts
{
    public class Restart : MonoBehaviour
    {
        public void OnStartButtonClick()
        {
            Debug.Log("Sadsadsadsadsadsaadsa");
            SceneManager.LoadScene("SampleScene");
        }

    }
}