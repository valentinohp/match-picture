namespace MatchPicture.Message
{
    public struct TileClickMessage
    {
        public int TileObjectId;
        public int TileObjectType;

        public TileClickMessage(int tileObjectId, int tileObjectType)
        {
            TileObjectId = tileObjectId;
            TileObjectType = tileObjectType;
        }
    }
}