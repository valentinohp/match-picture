using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace MatchPicture.Theme
{
    public class ThemeView : BaseSceneView
    {
        [SerializeField] private Button _backButton;
        
        public Button BackButton => _backButton;

        public void SetCallbacks(UnityAction onClickBackButton)
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(onClickBackButton);
        }
    }
}

