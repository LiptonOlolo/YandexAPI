namespace YandexAPI.Linguistics.Dictionary.Response
{
    public class Lookup
    {
        public Def[] def;
    }

    public class Def
    {
        public string text;
        public string pos;
        public Tr[] tr;
    }

    public class Tr
    {
        public string text;
        public string pos;
        public Syn[] syn;
    }

    public class Syn
    {
        public string text;
        public string pos;
    }
}
