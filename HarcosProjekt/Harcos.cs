using System;
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

        public string Nev 
        {
            get => nev; 
            set => nev = value;
        }
        public int Szint
        {
            get => szint;
            set
            {
                this.szint = value;

            }
        }
        public int Tapasztalat
        {
            get => tapasztalat;
            set
            {
                if (this.Eletero == 0)
                {
                    this.Tapasztalat = 0;
                }
                if (this.Tapasztalat == this.SzintLepeshez())
                {
                    this.Tapasztalat -= this.SzintLepeshez();
                    this.Szint++;
                    this.Eletero = this.MaxEletero();
                }
            }
        }
        public int Eletero 
        { 
            get => eletero;
            
            set
            {
                if(this.Eletero>this.MaxEletero())
                {
                    this.Eletero = this.MaxEletero();
                }
            }
            
        }

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
            return String.Format("{0,-15} - LVL: {1,3} - EXP: {2,3}/{3,3} - HP: {4,3}/{5,3} - DMG: {6,3}",
                this.nev,this.szint,this.tapasztalat,this.SzintLepeshez(),
                this.eletero,this.MaxEletero(),Sebzes());
        }

        public void Megkuzd(Harcos masikHarcos)
        {
            if (this.nev==masikHarcos.nev)
            {
                Console.WriteLine("Hiba, nem tud magával harcolni");
                return;
            }
            if (this.Eletero==0||masikHarcos.Eletero==0)
            {
                Console.WriteLine("Ha bármely harcos életereje 0, nem tudnak harcolni");
                return;
            }
            else
            {
                masikHarcos.Eletero -= this.Sebzes();
            }
            if (masikHarcos.Eletero>0)
            {
                this.Eletero -= masikHarcos.Sebzes();
            }
            if (this.Eletero>0||masikHarcos.Eletero>0)
            {
                this.Tapasztalat += 5;
                masikHarcos.Tapasztalat += 5;
            }
            else if(this.Eletero==0)
            {
                masikHarcos.Tapasztalat += 10;
            }
            else if (masikHarcos.Eletero == 0)
            {
                this.Tapasztalat += 5;
            }

        }
        public void Gyogyul()
        {
            if (this.Eletero == 0)
            {
                this.Eletero = this.MaxEletero();
            }
            else
            {
                this.Eletero += this.Szint + 3;
            }
        }
        
    }
}
