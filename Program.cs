using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Zvarych_Maryana_54558
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\tWektory: \tw = (1, 2, 3); \tw1 =  (2, 1, 0);");
            //1
            Wektor w = new Wektor(1, 2, 3);
            Wektor w1 = new Wektor(2, 1, 0);
            //2
            Console.WriteLine("\n\n\n\tDługość wektora w: {0}",w.Długość);
            Console.WriteLine("\n\tDługość wektora w1: {0}",w1.Długość);
            //3
            Wektor w2 = w + w1;
            Console.WriteLine("\n\tOperator + (dwuargumentowy): ");
            w2.Wypisz(w2);
            Wektor w3 = w - w1;
            Console.WriteLine("\tOperator - (dwuargumentowy): ");
            w3.Wypisz(w3);
            w3 = -w3;
            Console.WriteLine("\tOperator - (jednoargumentowy): ");
            w3.Wypisz(w3);
            //4
            Console.WriteLine("\tOperator ==\tw = w1: " + (w == w1));
            Console.WriteLine("\n\tOperator !=\tw != w1: " + (w != w1));
            Console.WriteLine("\n\tMetoda Equals\tw = w1: " + w.Equals(w1));
            Console.WriteLine("\n\tMetoda GetHashCode\tHash: " + w.GetHashCode());
            //5
            Wektor.Dot(w, w1);
            Wektor.Cross(w, w1);
            //6
            Wektor w4 = (w * 2);
            Console.WriteLine("\n\tOperator * (wektor na int): ");
            w4.Wypisz(w4);
            Wektor w5 = (3 * w);
            Console.WriteLine("\tOperator * (int na wektor): ");
            w5.Wypisz(w5);
            Wektor w6 = (w / 2);
            Console.WriteLine("\tOperator /: ");
            w6.Wypisz(w6);
            //7
            Console.WriteLine("\tCzy wektory sa prostopadłe?\tProstopadłość: " + Wektor.Prostopadłość(w, w1));
            //8
            Console.WriteLine("\n\tMetoda ComrapeTo:\tCompareTo: " + w.CompareTo(w1));
            Console.WriteLine("\n\n\n\tNaciśnij dowolny klawisz żeby zakończyć działanie programu...");
            Console.ReadLine();
        }
    }

                                                                        //PUNKT 1
    public struct Wektor : IComparable {
        private double X, Y, Z;

        public Wektor(double x, double y, double z) {
            X = x;
            Y = y;
            Z = z;
        }
        public void Wypisz(Wektor w) {
            Console.WriteLine("\t({0}, {1}, {2}) \n", w.X, w.Y, w.Z);
        }

                                                                        //PUNKT 2 
        public double Długość {
            get {
                double długość = Math.Sqrt((Math.Pow(X, 2))+ (Math.Pow(Y, 2)) + (Math.Pow(Z, 2)));
                return długość; 
            }
        }
        
                                                                        //PUNKT 3
        public static Wektor operator +(Wektor w1, Wektor w2) {
            double Suma1 = w1.X + w2.X;
            double Suma2 = w1.Y + w2.Y;
            double Suma3 = w1.Z + w2.Z;
            Wektor w3 = new Wektor(Suma1, Suma2, Suma3);
            return w3;
        }

        public static Wektor operator -(Wektor w1, Wektor w2) {
            double Różn1 = w1.X - w2.X;
            double Różn2 = w1.Y - w2.Y;
            double Różn3 = w1.Z - w2.Z;
            Wektor w3 = new Wektor(Różn1, Różn2, Różn3);
            return w3;
        }

        public static Wektor operator -(Wektor w1) {
            Wektor w2 = new Wektor(-w1.X, -w1.Y, -w1.Z);
            return w2;
        }

                                                                          //PUNKT 4
        public static bool operator ==(Wektor w1, Wektor w2) {
            if ((w1.X == w2.X) && (w1.Y == w2.Y) && (w1.Z == w2.Z)) {
                return true;
            }
            else {
                return false;
            }
        }

        public static bool operator !=(Wektor w1, Wektor w2) {
            if ((w1.X != w2.X) || (w1.Y != w2.Y) || (w1.Z != w2.Z)) {
                return true;
            }
            else {
                return false;
            }
        }

        public override bool Equals(object obj) {
            if (obj.GetType() != this.GetType()) 
                return false;

            Wektor w1 = (Wektor)obj;
            return (this.X == w1.X && this.Y == w1.Y && this.Z == w1.Z);
        }

        public override int GetHashCode() {
            int hash = (int)X + (int)Y + (int)Z;
            return hash;
        }

                                                                           //PUNKT 5
        public static void Dot(Wektor w1, Wektor w2) //iloczyn skalarny
        {
            double Skalarny = ((w1.X * w2.X) + (w1.Y * w2.Y) + (w1.Z * w2.Z));
            Console.WriteLine("\n\tIloczyn skalarny tych dwóch wektorów wynosi: {0}", Skalarny);
        }

        public static void Cross(Wektor U, Wektor W) //iloczyn wektorowy
        {
            double Wekt1 = U.Y * W.Z - U.Z * W.Y;
            double Wekt2 = U.Z * W.X - U.X * W.Z;
            double Wekt3 = U.X * W.Y - U.Y * W.X;
            Console.WriteLine("\n\tIloczyn wektorowy tych dwóch wektorów wynosi: ({0}, {1}, {2})", Wekt1, Wekt2, Wekt3);
        }
                                                                           //PUNKT 6
        public static Wektor operator *(Wektor w1, int i) {
            double Suma1 = (w1.X * i);
            double Suma2 = (w1.Y * i);
            double Suma3 = (w1.Z * i);
            Wektor w2 = new Wektor(Suma1, Suma2, Suma3);
            return w2;
        }

        public static Wektor operator *(int i, Wektor w1) {
            double Suma1 = i * w1.X;
            double Suma2 = i * w1.Y;
            double Suma3 = i * w1.Z;
            Wektor w2 = new Wektor(Suma1, Suma2, Suma3);
            return w2;
        }

        public static Wektor operator /(Wektor w1, int i) {
            double Dziel1 = w1.X / i;
            double Dziel2 = w1.Y / i;
            double Dziel3 = w1.Z / i;
            Wektor w2 = new Wektor(Dziel1, Dziel2, Dziel3);
            return w2;
        }

                                                                           //PUNKT 7
        public static bool Prostopadłość(Wektor w1, Wektor w2) {
            if ((w1.Długość != 0) && (w2.Długość != 0)) {
                double Skalarny = ((w1.X * w2.X) + (w1.Y * w2.Y) + (w1.Z * w2.Z));
                if (Skalarny == 0) {
                    return true;
                }
            }
            return false;
        }

        //PUNKT 8
        public int CompareTo(Wektor w) {
            int ret = -1;
            if (Długość < w.Długość)
                ret = -1;
            else if (Długość > w.Długość)
                ret = 1;
            else if (Długość == w.Długość)
                ret = 0;
            return ret;
        }
    }

    public interface IComparable {}

}
