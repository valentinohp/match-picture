using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;

namespace MatchPicture.Gameplay.TileObject
{
    public class TileObjectView : BaseView
    {
        private UnityAction OnClick;

        public void SetCallbacks(UnityAction onClick)
        {
            OnClick += onClick;
        }

        public void OnTileClick()
        {
            Debug.Log("clicked " + gameObject.name);
            OnClick?.Invoke();
        }
    }
}