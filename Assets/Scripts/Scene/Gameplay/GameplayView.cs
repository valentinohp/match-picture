using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using MatchPicture.Gameplay.TileGroup;

namespace MatchPicture.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Camera _destroyCameraWhenStart;
        [SerializeField] private TileGroupView _tileGroupView;

        public Button BackButton => _backButton;
        public TileGroupView TileGroupView => _tileGroupView;

        private void Start()
        {
            // Show camera in scene editor only, destroy when game is started
            Destroy(_destroyCameraWhenStart.gameObject);
        }

        public void SetCallbacks(UnityAction onClickBackButton)
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(onClickBackButton);
        }
    }
}

