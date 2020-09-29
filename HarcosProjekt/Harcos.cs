﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProjekt
{
    class Harcos
    {
        string nev;
        int szint;
        int tapasztalat;
        int eletero;
        int alapEletero;
        int alapSebzes;

        public Harcos(string nev, int statuszSablon)
        {
            this.nev = nev;
            this.szint = 1;
            this.tapasztalat = 0;
            if (statuszSablon == 1)
            {
                this.alapEletero = 15;
                this.alapSebzes = 3;
            }
            else if (statuszSablon == 2)
            {
                this.alapEletero = 12;
                this.alapSebzes = 4;
            }
            else if(statuszSablon==3)
            {
                this.alapEletero = 8;
                this.alapSebzes = 5;
            }
            this.eletero = MaxEletero();
        }

        public string Nev { get => nev; set => nev = value; }
        public int Szint { get => szint; set => szint = value; }
        public int Tapasztalat { get => tapasztalat; set => tapasztalat = value; }
        public int Eletero { get => eletero; set => eletero = value; }

        public int Sebzes()
        {
            return this.alapSebzes + this.szint;
        }
        public int SzintLepeshez()
        {
            return 10 + this.szint * 5;
        }
        public int MaxEletero()
        {
            return this.alapEletero + this.szint * 3;
        }

        public override string ToString()
        {
            return String.Format("{0} - LVL: {1} - EXP: {2} - HP: {3} - DMG: {4}",this.nev,this.szint,this.tapasztalat/SzintLepeshez(),this.eletero/MaxEletero(),Sebzes());
        }
    }
}
