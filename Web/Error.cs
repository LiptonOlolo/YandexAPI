namespace YandexAPI.Linguistics.Response
{
    class Error
    {
        public short code;
        public string message;

        public static implicit operator bool(Error err) => err.code == 0 || err.code == 200;
    }
}
