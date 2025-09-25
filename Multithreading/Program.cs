using System;
using System.IO;
using System.Threading;

public class Multithreading
{
    public static void MyThread()
    {
        int a;
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine($"Id thread  MyThread()  :   {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);///  1с
        }
        Console.WriteLine($"Завершает работу {Thread.CurrentThread.ManagedThreadId} поток!");
    }

    public static void ThreadParam(object obj)///200, "ok"
    {
        ///unboxin

        (int,string) delay = (   (int, string)   )obj ;////  explicit

        Console.WriteLine($"tuple item1: {delay.Item1}");//200
        Console.WriteLine($"tuple item2: {delay.Item2}");//"ok"

        // int delay=(int)obj;


        /////Варіанти розпаковки////////////////////////////////////

        //try
        //{
        //    Person p = (Person)obj;//////  explicit  може викликати виключення
        //}
        //catch (Exception e) { }


        // Person? p1 = obj as Person;

        //if (obj is Person)
        //    Person p2 = (Person)obj;


        Thread t = Thread.CurrentThread;

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Работает " + t.Name + " поток!");
            Thread.Sleep(delay.Item1);
        }
        Console.WriteLine("Завершает работу " + t.Name + " поток!");

        Console.WriteLine("Имя потока: {0}", t.Name);
        Console.WriteLine("Запущен ли поток: {0}", t.IsAlive);
        Console.WriteLine("Приоритет потока: {0}", t.Priority);
        Console.WriteLine("Статус потока: {0}", t.ThreadState);
    }

    public static void  Func()
    {
        for (int i = 0; i < 5; i++)
        {
            
            Console.WriteLine($"Id thread Func:   {Thread.CurrentThread.ManagedThreadId}   Priority {Thread.CurrentThread.Priority}");
            Thread.Sleep(1000);///  1с
        }
    }

   static void TestBackground()
    {
 
        Thread th= new Thread(Func);
        Console.WriteLine("TestBackground  create thread");
        th.Priority= ThreadPriority.Highest;
        th.IsBackground = false;  ////основний
        Console.WriteLine("TestBackground make thread  th.IsBackground = false; ");

        th.Start();
        Console.WriteLine("TestBackground  start thread");
    }

    public static void Main()
    {
        ///////////////////////////////////////////////////
        //////1. Запуск методів без параметрів

        //  Thread fon = new Thread(new ThreadStart(TestBackground));
        ////  fon.IsBackground = true;/// фоновий
        //  fon.Start();
        //  Thread.Sleep(1000);


        //////////////////////////////////////////////////////

        //Func();/// синхронний виклик методу, поки цей метод не виконається далі код Main не виконується


        //Thread fon = new Thread(new ThreadStart(Func));
        //fon.IsBackground = true;/// фоновий
        //fon.Start();

        ////fon.IsBackground = false;/// основний, значення за замовчуванням

        //for (int i = 0; i < 5; i++)
        //{
        //    Console.WriteLine($"MainThread Id: {Thread.CurrentThread.ManagedThreadId}");
        //    Thread.Sleep(500);
        //}


        ////////////////////////////////////////////////////
        //// / Главный поток Main
        //// /
        //Thread t = Thread.CurrentThread;

        //Console.WriteLine("Имя потока: {0}", t.Name);
        //t.Name = "Метод Main";
        //Console.WriteLine("Имя потока: {0}", t.Name);

        //Console.WriteLine("Запущен ли поток: {0}", t.IsAlive);
        //Console.WriteLine("Приоритет потока: {0}", t.Priority);
        //Console.WriteLine("Статус потока: {0}", t.ThreadState);///Enum
        //Console.WriteLine("Id потока  main: {0}", t.ManagedThreadId);

        // Func();////  основний головний потік

        /////////////////////////////////////////////////////
        //// Як змусити основний потік чекати фоновий
        ///  - не дати закритися Main()  Console.ReadLine(); or Form() не закриваємо форму тоді фонові встигають завершитися
        ///  - join


        //Thread th1 = new Thread(new ThreadStart(MyThread));
        //th1.IsBackground = true;////  фоновый
        //Console.WriteLine("Имя потока: {0}", th1.Name);
        //Console.WriteLine("Запущен ли поток: {0}", th1.IsAlive);
        //Console.WriteLine("Статус потока: {0}", th1.ThreadState);
        //th1.Start();


        //fon.Join();
        //th1.Join();//// обращение к главному потоку с просьбой подождать  завершения th    БЛОКИРУЮЩИЙ

        //Console.WriteLine("After Join");


        //Thread.Sleep(2000);
        //th.Abort();

        /////////////////////////////////////////////////////////////////////////////

        Thread th1 = new Thread(new ParameterizedThreadStart(ThreadParam));
        th1.IsBackground = true;
        th1.Name = "second";
        th1.Start((200, "ok"));

        ////Thread th2 = new Thread(new ParameterizedThreadStart(ThreadParam));
        ////th2.IsBackground = true;
        ////th2.Name = "третий";
        ////th2.Start(80);

        Console.ReadKey();

        //Console.WriteLine("Имя потока: {0}", th.Name);
        //Console.WriteLine("Запущен ли поток: {0}", th.IsAlive);
        //Console.WriteLine("Статус потока: {0}", th.ThreadState);
        ///

        //Console.ReadLine();////основний потіе=к не закриється поки не натиснемо Enter

    }

    /*
       Поток является либо фоновым, либо основным (по умолчанию).
       Они отличаются по принципу действия. 
       Если работает фоновый поток и происходит закрытие приложения, поток также выгружается из памяти. 
       Основной же поток при закрытии приложения останется в памяти.
       Если все основные потоки, принадлежащие процессу, завершились, общеязыковая среда выполнения завершает процесс, 
       вызывая метод Abort для всех фоновых потоков, которые еще действуют.
        
       public Thread(
       ThreadStart start – делегат, который указывает на потоковую функцию.
       );
       public delegate void ThreadStart();

       public Thread(ParameterizedThreadStart start - делегат, который ссылается на потоковую функцию с 
                           параметром. 
       );

       public delegate void ParameterizedThreadStart(
       object obj – объект, который будет передаваться в потоковую функцию.
       );  
       */
}
