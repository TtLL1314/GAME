using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Assets.Scripts
{
    public class Restart : MonoBehaviour
    {
        public void OnStartButtonClick()
        {
   
            SceneManager.LoadScene("SampleScene");
        }

    }
}