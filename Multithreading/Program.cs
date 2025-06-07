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
            Console.WriteLine($"Id thread:   {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);///  1с
        }
        Console.WriteLine($"Завершает работу {Thread.CurrentThread.ManagedThreadId} поток!");
    }

    public static void ThreadParam(object obj)///200
    {

        (int,string) delay = (   (int, string)   )obj ;////  unboxin
         
    
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

    public static void Main()
    {

        ///Главный поток
        ///
        Thread t = Thread.CurrentThread;

        Console.WriteLine("Имя потока: {0}", t.Name);
        t.Name = "Метод Main";
        Console.WriteLine("Имя потока: {0}", t.Name);

        Console.WriteLine("Запущен ли поток: {0}", t.IsAlive);
        Console.WriteLine("Приоритет потока: {0}", t.Priority);
        Console.WriteLine("Статус потока: {0}", t.ThreadState);

        Thread th = new Thread(new ThreadStart(MyThread));//// 
        th.IsBackground = true;////  фоновый, то основний його не чекає, якщо завершиться основний потік, він закриє фоновий

        ///за замовчуванням foreground, це означає що основний потік почекає його завершення

        Console.WriteLine("Имя потока: {0}", th.Name);
        Console.WriteLine("Запущен ли поток: {0}", th.IsAlive);
        Console.WriteLine("Статус потока: {0}", th.ThreadState);
        th.Start();


        //Thread th1 = new Thread(new ThreadStart(MyThread));
        //th1.IsBackground = true;////  фоновый
        //Console.WriteLine("Имя потока: {0}", th1.Name);
        //Console.WriteLine("Запущен ли поток: {0}", th1.IsAlive);
        //Console.WriteLine("Статус потока: {0}", th1.ThreadState);
        //th1.Start();



        //th.Join();//// обращение к главному потоку с просьбой подождать  завершения th    БЛОКИРУЮЩИЙ

        //Console.WriteLine("After Join");


        //Thread.Sleep(2000);




        //Thread th1 = new Thread(new ParameterizedThreadStart(ThreadParam));
        //th1.IsBackground = true;
        //th1.Name = "второй";
        //th1.Start((200,"tuple"));

        //Thread th2 = new Thread(new ParameterizedThreadStart(ThreadParam));
        //th2.IsBackground = true;
        //th2.Name = "третий";
        //th2.Start(80);

        //Console.ReadKey();

        //Console.WriteLine("Имя потока: {0}", th.Name);
        //Console.WriteLine("Запущен ли поток: {0}", th.IsAlive);
        //Console.WriteLine("Статус потока: {0}", th.ThreadState);
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
