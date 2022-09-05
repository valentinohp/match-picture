using Agate.MVC.Base;
using Agate.MVC.Core;
using MatchPicture.Boot;
using System.Collections;
using UnityEngine;

namespace MatchPicture.Home
{
    public class HomeLauncher : SceneLauncher<HomeLauncher, HomeView>
    {
        public override string SceneName => "Home";

        protected override IConnector[] GetSceneConnectors()
        {
            return null;
        }

        protected override IController[] GetSceneDependencies()
        {

            return null;
        }

        protected override IEnumerator InitSceneObject()
        {
            _view.SetCallbacks(OnClickPlayButton, OnClickThemeButton);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }

        private void OnClickPlayButton()
        {
            SceneLoader.Instance.LoadScene("Gameplay");
        }
        private void OnClickThemeButton()
        {
            SceneLoader.Instance.LoadScene("Theme");
        }
    }
}


