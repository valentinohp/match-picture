using System.Collections;
using System;
using Agate.MVC.Base;
using UnityEngine;
using MatchPicture.Gameplay.TileObject;
using MatchPicture.Message;
using System.Collections.Generic;

namespace MatchPicture.Gameplay.TileGroup
{
    public class TileGroupController : ObjectController<TileGroupController, TileGroupView>
    {
        [SerializeField] private GameObject _tileObjectPrefab;
        private TileObjectController[] _tileObjects = new TileObjectController[30];
        private Sprite[] _sprites;
        private int _lastId = -1;
        private int _lastType = -1;

        private static System.Random rng = new System.Random();

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            _tileObjectPrefab = Resources.Load<GameObject>(@"Prefabs/TileObject");
            _sprites = Resources.LoadAll<Sprite>(@"Sprites/fruit");
        }

        public override void SetView(TileGroupView view)
        {
            base.SetView(view);
            for (int i = 0; i < _tileObjects.Length; i++)
            {
                _tileObjects[i] = CreateTileObject(i % 15);
            }

            Shuffle(_tileObjects);

            for (int i = 0; i < _tileObjects.Length; i++)
            {
                Vector2 pos = new Vector2();
                pos.x = ((i % 5) * 1.2f) - 2.4f;
                pos.y = ((i / 5) * -1.2f) + 2.4f;
                _tileObjects[i].PlaceRandomPosition(pos);
                _tileObjects[i].SetObjectId(i);
            }
        }

        public TileObjectController CreateTileObject(int type)
        {
            TileObjectModel tileObjectModel = new TileObjectModel();
            GameObject tileObject = GameObject.Instantiate(_tileObjectPrefab);
            tileObject.name += " " + type;
            TileObjectView tileObjectView = tileObject.GetComponent<TileObjectView>();
            tileObjectView.GetComponent<SpriteRenderer>().sprite = _sprites[type % _sprites.Length];
            TileObjectController tileObjectController = new TileObjectController();
            InjectDependencies(tileObjectController);
            tileObjectController.Init(tileObjectModel, tileObjectView);
            tileObjectController.SetObjectType(type % _sprites.Length);

            return tileObjectController;
        }

        public void TryMatchClickedTiles(TileClickMessage message)
        {
            Debug.Log($"Last ID = {_lastId}, Last Type = {_lastType}");
            Debug.Log($"New ID = {message.TileObjectId}, New Type = {message.TileObjectType}");

            if (_lastId == -1)
            {
                _lastId = message.TileObjectId;
                _lastType = message.TileObjectType;
            }
            else if (_lastType == message.TileObjectType && _lastId != message.TileObjectId)
            {
                _tileObjects[_lastId].RemoveTileObject();
                _tileObjects[message.TileObjectId].RemoveTileObject();
                _lastId = -1;
                _lastType = -1;
            }
            else
            {
                _lastId = message.TileObjectId;
                _lastType = message.TileObjectType;
            }
        }

        public void Shuffle(object[] list)
        {
            int n = list.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}