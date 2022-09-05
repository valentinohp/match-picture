using Agate.MVC.Base;
using Agate.MVC.Core;
using MatchPicture.Boot;
using System.Collections;
using UnityEngine;

namespace MatchPicture.Theme
{
    public class ThemeLauncher : SceneLauncher<ThemeLauncher, ThemeView>
    {
        public override string SceneName => "Theme";

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
            _view.SetCallbacks(OnClickBackButton);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }

        private void OnClickBackButton()
        {
            SceneLoader.Instance.LoadScene("Home");
        }
    }
}


