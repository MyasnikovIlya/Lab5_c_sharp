using System;
using System.IO;

namespace Lab5
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string path;
            Console.WriteLine("Введите путь к файлу (чтобы проверить работу при существующем файле введите '../../../../input.txt')");
            path = Console.ReadLine();
            IStudent student = StudentFromFile(path);
            student.study();
            student.study();
            student.study();

        }
        /// <summary>
        /// Считывает из файла данные и создает на их основе, объект реализуюший интерфейс IStudent
        /// </summary>
        /// <param path="Путь к файлу"></param>
        static IStudent StudentFromFile(string path)
        {
            IStudent result = new NullStudent();
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
                {
                    string name = sr.ReadLine();
                    result = new Student(name);
                }
            }
            catch (Exception) { }

            return result;
        }
    }
    /// <summary>
    /// Интерфейс студента
    /// </summary>
    interface IStudent
    {
        public void study();
    }
    /// <summary>
    /// Студент
    /// </summary>
    class Student : IStudent
    {
        /// <summary>
        /// Имя студента
        /// </summary>
        string name;
        /// <summary>
        /// Конструктор студента
        /// </summary>
        /// <param name="Имя студента"></param>
        public Student(string name)
        {
            this.name = name;
        }
        /// <summary>
        /// Функция которая что-то делает
        /// </summary>
        public void study() { Console.WriteLine(name + " учится..."); }
    }
    /// <summary>
    /// Null object реализующий интерфейс IStudent
    /// </summary>
    class NullStudent : IStudent
    {
        public NullStudent() { }
        /// <summary>
        /// Функция которая ничего не делает
        /// </summary>
        public void study() { }
    }
}
