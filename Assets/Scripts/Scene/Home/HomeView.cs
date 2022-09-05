using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace MatchPicture.Home
{
    public class HomeView : BaseSceneView
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _themeButton;
        
        public Button PlayButton => _playButton;
        public Button LeaderboardButton => _themeButton;

        public void SetCallbacks(UnityAction onClickPlayButton, UnityAction onClickThemeButton)
        {
            _playButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(onClickPlayButton);
            _themeButton.onClick.RemoveAllListeners();
            _themeButton.onClick.AddListener(onClickThemeButton);
        }
    }
}

