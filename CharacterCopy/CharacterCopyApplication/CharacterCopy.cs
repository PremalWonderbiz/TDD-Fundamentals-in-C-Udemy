namespace CharacterCopyApplication
{
    public class CharacterCopy
    {
        private IDestination _destination;
        private ISource _source;

        public CharacterCopy(ISource source, IDestination destination)
        {
            _destination = destination;
            _source = source;
        }

        public void Copy()
        {
            var flag = true;
            while (flag)
            {
                var currentChar = _source.ReadChar();
                if (currentChar == '\n')
                    break;
                _destination.WriteChar(currentChar);
            }
        }
    }

    public interface IDestination
    {
        void WriteChar(char v);
    }

    public interface ISource
    {
        char ReadChar();
    }
}
