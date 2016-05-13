namespace Assets.Scripts
{
    public class Tuple<X,Y>
    {

        private X fst;
        private Y snd;

        public Tuple (X fst, Y snd)
        {
            this.fst = fst;
            this.snd = snd;
        }

        public X Fst ()
        {
            return fst;
        }

        public Y Snd ()
        {
            return snd;
        }
    }
}

