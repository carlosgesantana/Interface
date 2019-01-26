namespace QuePerigo.Estoque.Models
{
    public class Info
    {
        public Info(bool naoNulo)
        {
            NaoNulo = naoNulo;
        }

        public Info(int maxLength)
        {
            MaxLength = maxLength;
        }

        public Info(int maxLength, bool naoNulo)
        {
            NaoNulo = naoNulo;
            MaxLength = maxLength;
        }

        public bool NaoNulo { get; private set; }
        public int MaxLength { get; private set; }
    }
}