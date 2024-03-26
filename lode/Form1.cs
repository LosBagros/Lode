namespace lode
{
    public partial class Form1 : Form
    {
        Hrac hrac1;
        Hrac hrac2;

        Hrac aktualniHrac;

        public Hrac AktualniHrac
        {
            get => aktualniHrac;
            set
            {
                aktualniHrac = value;
                // Vizualizace aktuálního hráče
            }
        }

        public Form1()
        {
            InitializeComponent();
            VytvorHru();
        }

        private void VytvorHru()
        {
            // Vytvoření hráčů
            hrac1 = new Hrac("Apep");
            hrac2 = new Hrac("Limiřob");

            AktualniHrac = Random.Shared.Next(0, 2) == 0 ? hrac1 : hrac2;

            // Vytvoření poliček
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    Policko polickoHrace1 = new Policko(j, i, null, hrac1);
                    polickoHrace1.OnPolickoKliklo += OnPolickoKliklo;
                    flowLayoutPanel2.Controls.Add(polickoHrace1);
                    Policko polickoHrace2 = new Policko(j, i, null, hrac2);
                    polickoHrace2.OnPolickoKliklo += OnPolickoKliklo;
                    flowLayoutPanel3.Controls.Add(polickoHrace2);
                }
            }

            // Start hry
        }


        private Policko nakliknutePolicko = null;
        private void OnPolickoKliklo(Policko policko)
        {
            if (policko.Hrac != AktualniHrac)
                return;

            // kontrola ze neni lod
            if (nakliknutePolicko == null)
            {
                nakliknutePolicko = policko;
                return;
            }

            if (nakliknutePolicko == policko)
            {
                nakliknutePolicko = null;
                return;
            }

            int smerX = policko.X - nakliknutePolicko.X;
            int smerY = policko.Y - nakliknutePolicko.Y;

            if(Math.Abs(smerX) + Math.Abs(smerY) > 1)
            {
                MessageBox.Show("AAAAAAAAAA");
                return;
            }

            Point zacatekLode = new Point(nakliknutePolicko.X, nakliknutePolicko.Y);
            for(int i = 0; i < 1; i++)
            {
                zacatekLode.Offset(smerX, smerY);
            }


        }
    }
}