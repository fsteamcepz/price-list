using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    class Film : Material                   // Абстракція та Спадкування. Клас Film - абстрактний тип даних (має модифікатор доступу рublic)
    {
        // 1. Всі поля класу закриті (Інкапсуляція, доступ за доп. властивостей і методів)
        private string filmDirector;        // режисер фільму
        private string actor;               // актор на головну роль


        // 2. Конструктор з 7 параметрами (для створення об'єктів)
        public Film(int id, string name, string filmDirector, string actor, string recordingFormat, int yearOfRelease, int cost)
        {
            Id = id;
            Name = name;
            FilmDirector = filmDirector;
            Actor = actor;
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
        public string FilmDirector
        {
            get { return filmDirector; }
            set { filmDirector = value; }
        }
        public string Actor
        {
            get { return actor; }
            set { actor = value; }
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


        // ЯВНО (в класі) написаний конструктор для класа Film
        public Film() { }
    }
}