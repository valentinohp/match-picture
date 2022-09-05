using System.Collections;
using Agate.MVC.Base;
using UnityEngine;
using MatchPicture.Message;

namespace MatchPicture.Gameplay.TileObject
{
    public class TileObjectController : ObjectController<TileObjectController, TileObjectModel, TileObjectView>
    {
        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
        }

        public void Init(TileObjectModel model, TileObjectView view)
        {
            _model = model;
            SetView(view);
            _view.SetCallbacks(OnClick);
        }

        public void SetObjectId(int objectId)
        {
            _model.ObjectId = objectId;
        }

        public void SetObjectType(int objectType)
        {
            _model.ObjectType = objectType;
        }

        private void OnClick()
        {
            Publish<TileClickMessage>(new TileClickMessage(_model.ObjectId, _model.ObjectType));
        }

        public void RemoveTileObject()
        {
            _view.gameObject.SetActive(false);
        }

        public void PlaceRandomPosition(Vector2 pos)
        {
            _view.transform.position = pos;
        }
    }
}