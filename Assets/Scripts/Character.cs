using UnityEngine;

namespace DefaultNamespace
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1;
        private void Update()
        {
            
        }
        public void Move(float moveX, float moveZ)
        {
            transform.position += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;
        }
    }
}