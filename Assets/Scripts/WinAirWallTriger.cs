using System.Collections;
using UnityEngine;
namespace Assets.Scripts
{
    public class WinAirWallTriger : MonoBehaviour
    {
       public GameObject g;
        public GameObject g2;
        private void Start()
        {
            g.SetActive(false);
        }
        public void OnTriggerEnter(Collider other)
        {
            g2.GetComponent<Rigidbody>().velocity = Vector3.zero;
            g.SetActive(true);
            
        }
     
    }
}