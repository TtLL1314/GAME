using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Assets.Scripts
{
    public class Back : MonoBehaviour
    {

        public void OnStartButtonClick()
        {

            SceneManager.LoadScene("StartScene");
        }

    }
}