using System;
using System.Windows.Forms;

namespace Tamagochi
{
    internal class Program
    {

        static System.Timers.Timer timer = new System.Timers.Timer(3000);
        static Random rnd = new Random();
        static Dog dog = new Dog(0);
        static DateTime dt;
        static void Main(string[] args)
        {

            //MessageBox.Show("");

            timer.Elapsed += Timer_Elapsed;

            timer.Enabled = true;
            dt = DateTime.Now;
            dt= dt.AddMinutes(3);

            Console.ReadLine();
        }
        static private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            if (!dog.LivesDog()&& DateTime.Now<dt)
            {
                if (DateTime.Now > dt)
                {
                    timer.Stop();
                    Console.WriteLine("Собака выжила в ваших руках");

                }



                Console.WriteLine(e.SignalTime);
                timer.Interval = rnd.Next(1000, 10000);
                int action = rnd.Next(1, 6);
                dog.Wanna("Хочу играть");

                switch (action)
                {
                    case 1: dog.Wanna("Хочу есть"); break;
                    case 2: dog.Wanna("Хочу спать"); break;
                    case 3: dog.Wanna("Хочу в туалет"); break;
                    case 4: dog.Wanna("Хочу играть");break;
                    default: MessageBox.Show("Пёсика похитили!!!"); break;
                }


            }
            else
            {
                timer.Stop();
            }
        }

        class Dog
        {
            int _state;
            int _live = 3;
            bool _dead = false;

            public Dog(int state)
            {
                _state = state;
            }
            public bool LivesDog()
            {
                return _dead;
            }
            public void Wanna(string wish)
            {
                DialogResult dr;
                dr = MessageBox.Show("ГАВ! " + wish, wish, MessageBoxButtons.OKCancel);
                if (DialogResult.OK == dr)
                {
                    if (_live < 3)
                    {
                        _live++;
                    }
                    Console.Clear();
                    Calm();
                }
                if (DialogResult.Cancel == dr)
                {
                    Console.Clear();
                    Sad();
                    _live--;
                }
                if (_live == 0)
                {
                    Console.WriteLine("Песик умер");
                }
            }
            public void Calm()
            {
                Console.WriteLine("  /\\____/\\  ");
                Console.WriteLine(" (          ) ");
                Console.WriteLine("(  /\\  /\\   )");
                Console.WriteLine("(  \\/  \\/   )");
                Console.WriteLine("(           )");
                Console.WriteLine("(     ()    )");
                Console.WriteLine("(    ____   )");
                Console.WriteLine(" (   |___| ) ");
                Console.WriteLine("   (______)  ");
            }

            public void Sad()
            {
                Console.WriteLine("  /\\____/\\  ");
                Console.WriteLine(" (          ) ");
                Console.WriteLine("(  /\\  /\\   )");
                Console.WriteLine("(  \\/  \\/   )");
                Console.WriteLine("(    '   '   )");
                Console.WriteLine("(   ' () '  )");
                Console.WriteLine("(    ____   )");
                Console.WriteLine(" (   |___| ) ");
                Console.WriteLine("   (______)  ");
            }

        }
    }
}
