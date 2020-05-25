using System;
using System.Text.RegularExpressions;

/*Am ales ca temă de proiect ,Tema numărul 3:
 *ALgoritmi divide et impera, Evaluarea expresilor aritmetice prin DC
 *vs metodele clasice Shuning Yard si RPN
 **/
/* Printre cei mai faimoși algoritmi de tip DivideConquer sunt
 * căutarea binara, Quicksort (algoritm de sortare ), Merge Sort
 * Acesti algoritmi ii vom trata și în următorul program
 * */


namespace DivideConquer
{
    class Program
    {
        
        

        
        //Functie de back pentru meniu
        public static void back()
        {
            int opt;
            Console.WriteLine("\nAlegeti optiune:");
            Console.WriteLine("1) Meniu Principal");
            Console.WriteLine("2) Iesire Program");
            Console.Write("\r\nOptiune Selectata: ");
            string strSelection = Console.ReadLine();
            opt = VerOpt(strSelection);
            if (opt == 2)
                Environment.Exit(0);
            else if (opt == 1)
                Console.Clear();
            else
            {
                Console.Clear();
                Console.WriteLine("Optiunea Selectata nu este valida!");
                back();
            }
        }
        //Functie de afisare vectori
        public static void Write(int[] arr, int n)
        {
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");

            Console.Write("\n");
            
        }
        //Functie de citire de la tastatura in consola
        //a unui vector de *d* dimensiune
        public static void Read(int[] v, int d)
        {
            Console.WriteLine("dimensiunea este :{0}", d);
            int i = d;
            Console.Write("\n\nCiteste si afiseaza elementele unui vector:\n");
            Console.Write("-----------------------------------------\n");

            Console.Write("Introduceti elementele vectorului\n");
            for (i = 0;i <d; i++)
            {
                Console.Write("element - {0} : ", i+1);
                v[i] = Convert.ToInt32(Console.ReadLine());
            }

        }
        //Functie de pregatire a stringului cu 
        //expresia aritmetica pentru a fi folosita
        public static string ReglementSTR(string str)
        {
            str = str.Replace(" ", String.Empty);
            str = str.Insert(str.Length, " ");
           for (int i = 1; i < str.Length; i++)
            {
                if (!Char.IsDigit(str[i]))
                {
                    str = str.Insert(i, " ");
                    i++;
                }
            }
            for (int i = 1; i < str.Length-1; i++)
            {
                if (Char.IsWhiteSpace(str[i])&& !Char.IsWhiteSpace(str[i+1]))
                {
                    str = str.Insert(i+2, " ");
                    i++;
                }
            }

            return str;

        }
        
        //Functie de Tratare erori pentru optiunile meniu
        private static int VerOpt(string input)
        {
            try
            {
                int opt = int.Parse(input);
                return opt;
            }
            catch (FormatException)
            {
                Console.Clear();
                return 'l';
                back();
                
                
            }

        }
        
        //Functie pentru gestionare Meniu consola si apelare a functionalitatilor
        private static void MainMenu()
        {
            string infix = "Nu a fost introdusa o expresie";
            string postfix="Nu a fost introdusa o expresie INFIX";
            decimal result;
            int d = 0;
            int[] myNumbers = new int[99];
            bool showMenu = true;

            while (showMenu)
            {
                char opt;
                Console.Clear();
                Console.WriteLine("---------MENIU PRINCIPAL--------:");
                Console.WriteLine("1) Creare Vector");
                Console.WriteLine("2) Afisare Vector existent"); 
                Console.WriteLine("3) Introducere Expresie Aritmetică");
                Console.WriteLine("4) Afisare Expresie Aritmetică Introdusă");
                Console.WriteLine("5) Căutare binară(Vector Sortat Crescător)");
                Console.WriteLine("6) Sorteaza Vectorul prin QuickSort");
                Console.WriteLine("7) Sorteaza Vectorul prin MergeSort");
                Console.WriteLine("8) Creare Expresie de tip RPN(Shunting-Yard)");
                Console.WriteLine("9) Evaluează Expresie Aritmetică de Tip RPN");
                Console.WriteLine("x) Iesire Program");

                Console.Write("\r\nOptiune Selectata: ");
                string strSelection = Console.ReadLine();
                opt=strSelection[0];


                switch (opt)
                {
                    case '1':
                        Console.Clear();
                        Console.Write("Introduceti dimensiunea:");
                        strSelection = Console.ReadLine();
                        if (VerOpt(strSelection) != 'l')
                        {
                            d = VerOpt(strSelection);
                            Read(myNumbers,d);
                        }
                        else
                        {
                            Console.WriteLine("Dimensiune Invalida!!");
                            back();
                        }
                        break;
                    case '2':
                        Console.Clear();
                        if (d != 0)
                        {
                            Console.Write("\nElementele vectorului sunt: ");
                            Write(myNumbers, d);
                            back();
                        }
                        else
                        {
                            Console.Write("Vectorul nu a fost creat!");
                            back();
                        }
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Introduceti Expresia dorita:");
                        string insert = Console.ReadLine();
                        if (Regex.IsMatch(insert, @"[0-9^&*()[/\]+\-{}]+(pow)*(ln)*(sqrt)*"))
                        {
                            infix = insert;
                            infix = ReglementSTR(infix);
                            postfix = infix.ToPostfix();
                        }

                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Expresia Introdusa nu a fost valida!");
                            back();
                        }
                        break;
                    case '4':
                        Console.Clear();
                        if (infix=="Nu a fost introdusa o expresie") 
                            Console.WriteLine(infix);
                        else 
                        Console.WriteLine("Expresia aritmetica actuala este:  " + infix.Replace(" ", String.Empty));
                        back();
                        break;
                    case '5':
                        if (d!=0  && Sortari.arraySortedOrNot(myNumbers,d))
                        {
                            Console.Clear();
                            Console.Write("Introduceti Elementul cautat:");
                            strSelection = Console.ReadLine();
                            if (VerOpt(strSelection) != 'l')
                            {
                                Console.Clear();
                                int binKey = int.Parse(strSelection);
                                int poz = Sortari.BinarySearch(myNumbers, binKey, 0, d) + 1;
                                Console.Write("Elementul *" + binKey + "* se afla pe pozitia " + poz);
                                back();

                            }
                            else
                            {
                                Console.WriteLine("Element Invalid sau Vector Nonxistent!");
                                back();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Vectorul nu este sortat sau nu exista!");
                            back();
                        }

                        break;
                    case '6':
                        Console.Clear();
                        if (d != 0)
                        {
                            Sortari.QuickSort(myNumbers, 0, d - 1, d);
                            Console.Write("\nElementele au fost SORTATE!:\n");
                            Write(myNumbers, d);
                            back();

                        }

                        else
                        {
                            Console.Write("Vectorul nu a fost creat!\n");
                            back();
                        }
                        break;
                    case '7':
                        Console.Clear();
                        if (d != 0)
                        {
                            Sortari.MergeSort(myNumbers, 0, d - 1, d);
                            Console.Write("\nElementele au fost SORTATE!:\n");
                            Write(myNumbers, d);
                            back();

                        }

                        else
                        {
                            Console.Write("Vectorul nu a fost creat!\n");
                            back();
                        }

                        break;
                    case '8':
                        Console.Clear();
                        if (infix == "Nu a fost introdusa o expresie")
                        Console.WriteLine(postfix);
                        else
                        {
                            postfix = infix.ToPostfix();
                            Console.Write(postfix);
                        }
                        back();
                        break;
                    case '9':
                        Console.Clear();
                        if (infix == "Nu a fost introdusa o expresie")
                            Console.WriteLine(postfix);
                        else
                        {
                            result = RPNEvaluator.CalculateRPN(postfix);
                            Console.WriteLine("Rezultatul expresiei este= " + result);
                        }
                        back();
                        break;
                    case 'x':
                        showMenu = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("OPTIUNE NONEXISTENTA!: \r\n" );
                        back();
                        continue;
                }
            }

        }
        //Functie de tratare erori globale
        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
            Environment.Exit(0);
        }

        //Functia Main care doar face apel la Meniu
        static void Main(string[] args)
        {

            MainMenu();
        }
    }

}



   

