﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lode
{
    public partial class Policko : UserControl
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        // Loď na políčku
        public Lod Lod { get; private set; }
        public bool JeStrelena { get; private set; }

        // Vlastnik políčka
        public Hrac Hrac { get; private set; }

        public Action<Policko> OnPolickoKliklo;

        public Policko(int X, int Y, Lod lod, Hrac hrac) : this()
        {
            this.X = X;
            this.Y = Y;
            this.Lod = lod;
            this.Hrac = hrac;
        }
        private Policko()
        {
            InitializeComponent();
        }

        private void Policko_MouseClick(object sender, MouseEventArgs e)
        {
            if(OnPolickoKliklo != null)
                OnPolickoKliklo?.Invoke(this);
        }
    }
}
