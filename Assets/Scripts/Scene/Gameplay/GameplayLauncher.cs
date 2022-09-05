using Agate.MVC.Base;
using Agate.MVC.Core;
using MatchPicture.Boot;
using MatchPicture.Gameplay.InputRaycast;
using MatchPicture.Gameplay.TileGroup;
using System.Collections;
using UnityEngine;

namespace MatchPicture.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName => "Gameplay";

        private TileGroupController _tileGroup;

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]
            {
                new TileGroupConnector(),
            };
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new InputRaycastController(),
                new TileGroupController(),
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _view.SetCallbacks(OnClickBackButton);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            _tileGroup.SetView(_view.TileGroupView);
            yield return null;
        }

        private void OnClickBackButton()
        {
            SceneLoader.Instance.LoadScene("Home");
        }
    }
}


