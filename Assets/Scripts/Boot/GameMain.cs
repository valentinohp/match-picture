using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MatchPicture.Boot
{
    public class GameMain : BaseMain<GameMain>, IMain
    {
        protected override IConnector[] GetConnectors()
        {
            return new IConnector[]
            {
                
            };
        }

        protected override IController[] GetDependencies()
        {
            return new IController[]
            {

            };
        }

        protected override IEnumerator StartInit()
        {
            CreateEventSystem();
            CreateCamera();
            yield return null;
        }
        private void CreateEventSystem()
        {
            GameObject obj = new("Event System");
            obj.AddComponent<EventSystem>();
            obj.AddComponent<StandaloneInputModule>();

            GameObject.DontDestroyOnLoad(obj);
        }

        private void CreateCamera()
        {
            GameObject obj = new("Camera");
            obj.tag = "MainCamera";
            obj.AddComponent<Camera>();
            obj.AddComponent<AudioListener>();
            obj.transform.Translate(Vector3.back * 12);

            GameObject.DontDestroyOnLoad(obj);
        }


    }
}
