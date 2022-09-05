using Agate.MVC.Base;
using MatchPicture.Message;

namespace MatchPicture.Gameplay.TileGroup
{
    public class TileGroupConnector : BaseConnector
    {
        private TileGroupController _tileGroup;
        
        protected override void Connect()
        {
            Subscribe<TileClickMessage>(_tileGroup.TryMatchClickedTiles);
        }

        protected override void Disconnect()
        {
            Unsubscribe<TileClickMessage>(_tileGroup.TryMatchClickedTiles);
        }
    }
}