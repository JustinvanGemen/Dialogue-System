using UnityEngine;

namespace _Scripts
{
    public class PlayerMovement : MonoBehaviour
    {

        private bool _canMove = true;

        public bool CanMove
        {
            get { return _canMove; }
            set { _canMove = value; }
        }

        private void FixedUpdate()
        {
            if (!_canMove) return;
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                Debug.Log(_canMove);
                transform.Translate(5f * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.Translate(-5f * Time.deltaTime, 0, 0);
            }
        }
    }
}
    