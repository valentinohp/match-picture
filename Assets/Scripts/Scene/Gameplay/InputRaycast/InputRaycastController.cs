using System.Collections;
using Agate.MVC.Base;
using MatchPicture.Gameplay.TileObject;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MatchPicture.Gameplay.InputRaycast
{
    public class InputRaycastController : BaseController<InputRaycastController>
    {
        private InputActionManager _inputActionManager = new InputActionManager();
        private Camera cam;

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            _inputActionManager.Player.Enable();
            _inputActionManager.Player.Touchscreen.started += OnMoveInput;
            _inputActionManager.Player.Touchscreen.canceled += OnMoveInput;

            cam = Camera.main;
        }

        private void OnMoveInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Vector2 pos = context.ReadValue<Vector2>();
                Vector3 screenCoordinates = new Vector3(pos.x, pos.y, cam.transform.position.z);
                Vector3 worldCoordinates = cam.ScreenToWorldPoint(screenCoordinates);
                worldCoordinates.z = 0;
                RaycastHit2D hit = Physics2D.Raycast(-worldCoordinates, Vector3.forward);

                if (hit.collider != null && hit.collider.tag == "TileObject")
                {
                    hit.collider.GetComponent<TileObjectView>().OnTileClick();
                }
            }
        }
    }
}