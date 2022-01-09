using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Assets.scripts
{
    public class GameItemScript : MonoBehaviour
    {
        public virtual void deactivateAsPlayerItem(GameObject player, GameObject hand)
        {
        }

        public virtual void activateAsPlayerItem(GameObject player, GameObject hand)
        {
        }

        public virtual void ShowInHands(GameObject player, GameObject hand)
        {
        }

        public virtual void OnFire(CallbackContext context) {
        }

        public virtual Vector3 GetTruePosition(Vector3 pos, Vector3 scale, Vector3 rotation) {
            return pos;
        }
        public virtual Vector3 GetTrueScale(Vector3 pos, Vector3 scale, Vector3 rotation) {
            return scale;
        }

        public virtual Vector3 GetTrueRotation(Vector3 pos, Vector3 scale, Vector3 rotation)
        {
            return rotation;
        }
    }
}
