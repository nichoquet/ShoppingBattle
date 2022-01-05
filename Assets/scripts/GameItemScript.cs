using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Assets.scripts
{
    public class GameItemScript : MonoBehaviour
    {
        public virtual void deactivateAsPlayerItem()
        {
        }

        public virtual void activateAsPlayerItem()
        {
        }

        public virtual void OnFire(CallbackContext context) {
        }

        public virtual Vector3 GetTruePosition(Vector3 pos, Vector3 scale) {
            return pos;
        }
        public virtual Vector3 GetTrueScale(Vector3 pos, Vector3 scale) {
            return scale;
        }
    }
}
