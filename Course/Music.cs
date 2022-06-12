using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    class Music : Material                      // Абстракція та Спадкування. Клас Music - абстрактний тип даних
    {
        // 1. Всі поля класу закриті (Інкапсуляція)
        private string composer;                // автор пісні
        private string executor;                // виконавець пісні
        private string duration;                // тривалість пісні


        // 2. Конструктор класу з 8 параметрами (для створення об'єктів)
        public Music(int id, string name, string composer, string executor, string duration, string recordingFormat, int yearOfRelease, int cost)
        {
            Id = id;
            Name = name;
            Composer = composer;
            Executor = executor;
            Duration = duration;
            RecordingFormat = recordingFormat;
            YearOfRelease = yearOfRelease;
            Cost = cost;
        }

        // 3. Властивості (для підтримки інкапсуляції)
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Composer
        {
            get { return composer; }
            set { composer = value; }
        }
        public string Executor
        {
            get { return executor; }
            set { executor = value; }
        }
        public string Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        public string RecordingFormat
        {
            get { return recordingFormat; }
            set { recordingFormat = value; }
        }
        public int YearOfRelease
        {
            get { return yearOfRelease; }
            set { yearOfRelease = value; }
        }
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }


        // ЯВНО (в класі) написаний конструктор для класа Music
        public Music() { }
    }
}