using UnityEngine;


namespace Bricks
{
    public class Breakable : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}
