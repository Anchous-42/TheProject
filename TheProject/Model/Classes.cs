using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TheProject.Model.Geometry;

namespace TheProject.Model
{
    /// <summary>
    /// Модель данных авиарейса с информацией о маршруте и длительности
    /// </summary>
    public class Flight
    {
        private string _departurePoint = "Undefined";
        /// <summary>
        /// Аэропорт вылета
        /// </summary>
        public string DeparturePoint
        {
            get => _departurePoint;
            set => _departurePoint = value;
        }

        private string _destinationPoint = "Undefined";
        /// <summary>
        /// Аэропорт назначения
        /// </summary>
        public string DestinationPoint
        {
            get => _destinationPoint;
            set => _destinationPoint = value;
        }

        private int _durationFlight = 0;
        /// <summary>
        /// Длительность полета в минутах (должна быть > 0)
        /// </summary>
        public int DurationFlight
        {
            get => _durationFlight;
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(DurationFlight));
                _durationFlight = value;
            }
        }

        /// <summary>
        /// Создает новый рейс с указанными параметрами
        /// </summary>
        public Flight(string departurePoint, string destinationPoint, int durationFlight)
        {
            DeparturePoint = departurePoint;
            DestinationPoint = destinationPoint;
            DurationFlight = durationFlight;
        }

        /// <summary>
        /// Создает рейс с параметрами по умолчанию
        /// </summary>
        public Flight() { }
    }

    /// <summary>
    /// Модель данных фильма с основной информацией
    /// </summary>
    public class Film
    {
        private string _nameFilm = "Undefined";
        /// <summary>
        /// Название фильма
        /// </summary>
        public string NameFilm
        {
            get => _nameFilm;
            set => _nameFilm = value;
        }

        private int _durationFilm = 0;
        /// <summary>
        /// Длительность в минутах (1-9999)
        /// </summary>
        public int DurationFilm
        {
            get => _durationFilm;
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(DurationFilm));
                _durationFilm = value;
            }
        }

        private int _yearOfFilm = 0;
        /// <summary>
        /// Год выпуска (0-9999)
        /// </summary>
        public int YearOfFilm
        {
            get => _yearOfFilm;
            set
            {
                Validator.AssertValueInRange(value, 0, 9999, nameof(YearOfFilm));
                _yearOfFilm = value;
            }
        }

        private string _genreFilm = "Undefined";
        /// <summary>
        /// Жанровая принадлежность
        /// </summary>
        public string GenreFilm
        {
            get => _genreFilm;
            set => _genreFilm = value;
        }

        private int _ratingFilm = 0;
        /// <summary>
        /// Оценка (1-10)
        /// </summary>
        public int RatingFilm
        {
            get => _ratingFilm;
            set
            {
                if (value < 1 || value > 10)
                    throw new ArgumentException("Рейтинг должен быть от 1 до 10");
                _ratingFilm = value;
            }
        }

        /// <summary>
        /// Создает фильм с указанными параметрами
        /// </summary>
        public Film(string nameFilm, int durationFilm, int yearOfFilm, string genreFilm, int ratingFilm)
        {
            NameFilm = nameFilm;
            DurationFilm = durationFilm;
            YearOfFilm = yearOfFilm;
            GenreFilm = genreFilm;
            RatingFilm = ratingFilm;
        }

        /// <summary>
        /// Создает фильм с параметрами по умолчанию
        /// </summary>
        public Film() { }
    }

    /// <summary>
    /// Модель временных данных (часы, минуты, секунды)
    /// </summary>
    public class Time
    {
        private int _timeHour = 0;
        /// <summary>
        /// Часы (0-24)
        /// </summary>
        public int TimeHour
        {
            get => _timeHour;
            set
            {
                Validator.AssertValueInRange(value, 0, 24, nameof(TimeHour));
                _timeHour = value;
            }
        }

        private int _timeMinute = 0;
        /// <summary>
        /// Минуты (0-59)
        /// </summary>
        public int TimeMinute
        {
            get => _timeMinute;
            set
            {
                Validator.AssertValueInRange(value, 0, 59, nameof(TimeMinute));
                _timeMinute = value;
            }
        }

        private int _timeSecond = 0;
        /// <summary>
        /// Секунды (0-59)
        /// </summary>
        public int TimeSecond
        {
            get => _timeSecond;
            set
            {
                Validator.AssertValueInRange(value, 0, 59, nameof(TimeSecond));
                _timeSecond = value;
            }
        }

        /// <summary>
        /// Создает время с указанными значениями
        /// </summary>
        public Time(int timeHour, int timeMinute, int timeSecond)
        {
            TimeHour = timeHour;
            TimeMinute = timeMinute;
            TimeSecond = timeSecond;
        }

        /// <summary>
        /// Создает время 00:00:00
        /// </summary>
        public Time() { }
    }

    /// <summary>
    /// Модель контактных данных персоны
    /// </summary>
    public class Contact
    {
        private string _contactName = "Undefined";
        /// <summary>
        /// Имя (только буквы)
        /// </summary>
        public string ContactName
        {
            get => _contactName;
            set
            {
                AssertStringContainsOnlyLetters(value, nameof(ContactName));
                _contactName = value;
            }
        }

        private string _contactSurname = "Undefined";
        /// <summary>
        /// Фамилия (только буквы)
        /// </summary>
        public string ContactSurname
        {
            get => _contactSurname;
            set
            {
                AssertStringContainsOnlyLetters(value, nameof(ContactSurname));
                _contactSurname = value;
            }
        }

        private int _contactNumber = 0;
        /// <summary>
        /// Номер телефона (10 цифр)
        /// </summary>
        public int ContactNumber
        {
            get => _contactNumber;
            set
            {
                Validator.AssertValueInRange(value, 1000000000, 1999999999, nameof(ContactNumber));
                _contactNumber = value;
            }
        }

        private string _contactNotes = "Undefined";
        /// <summary>
        /// Дополнительные заметки
        /// </summary>
        public string ContactNotes
        {
            get => _contactNotes;
            set => _contactNotes = value;
        }

        /// <summary>
        /// Создает новый контакт
        /// </summary>
        public Contact(string contactName, string contactSurname, int contactNumber, string contactNotes)
        {
            ContactName = contactName;
            ContactSurname = contactSurname;
            ContactNumber = contactNumber;
            ContactNotes = contactNotes;
        }

        /// <summary>
        /// Создает пустой контакт
        /// </summary>
        public Contact() { }

        private void AssertStringContainsOnlyLetters(string value, string propertyName)
        {
            if (string.IsNullOrEmpty(value) || !value.All(char.IsLetter))
                throw new ArgumentException($"{propertyName} должен содержать только буквы");
        }
    }

    /// <summary>
    /// Модель музыкальной композиции
    /// </summary>
    public class Song
    {
        private string _songName = "Undefined";
        /// <summary>
        /// Название трека
        /// </summary>
        public string SongName
        {
            get => _songName;
            set => _songName = value;
        }

        private int _songYear = 0;
        /// <summary>
        /// Год выпуска (0-9999)
        /// </summary>
        public int SongYear
        {
            get => _songYear;
            set
            {
                Validator.AssertValueInRange(value, 0, 9999, nameof(SongYear));
                _songYear = value;
            }
        }

        private int _songDuration = 0;
        /// <summary>
        /// Длительность в секундах (0-9999)
        /// </summary>
        public int SongDuration
        {
            get => _songDuration;
            set
            {
                Validator.AssertValueInRange(value, 0, 9999, nameof(SongDuration));
                _songDuration = value;
            }
        }

        /// <summary>
        /// Создает новую песню
        /// </summary>
        public Song(string songName, int songYear, int songDuration)
        {
            SongName = songName;
            SongYear = songYear;
            SongDuration = songDuration;
        }

        /// <summary>
        /// Создает пустую песню
        /// </summary>
        public Song() { }
    }

    /// <summary>
    /// Модель учебной дисциплины
    /// </summary>
    public class Discipline
    {
        private string _disciplineName = "Undefined";
        /// <summary>
        /// Название предмета
        /// </summary>
        public string DisciplineName
        {
            get => _disciplineName;
            set => _disciplineName = value;
        }

        private string _disciplineDescription = "Undefined";
        /// <summary>
        /// Описание курса
        /// </summary>
        public string DisciplineDescription
        {
            get => _disciplineDescription;
            set => _disciplineDescription = value;
        }

        private int _disciplineGrade = 2;
        /// <summary>
        /// Оценка (2-5)
        /// </summary>
        public int DisciplineGrade
        {
            get => _disciplineGrade;
            set
            {
                Validator.AssertValueInRange(value, 2, 5, nameof(DisciplineGrade));
                _disciplineGrade = value;
            }
        }

        /// <summary>
        /// Создает новую дисциплину
        /// </summary>
        public Discipline(string disciplineName, string disciplineDescription, int disciplineGrade)
        {
            DisciplineName = disciplineName;
            DisciplineDescription = disciplineDescription;
            DisciplineGrade = disciplineGrade;
        }

        /// <summary>
        /// Создает пустую дисциплину
        /// </summary>
        public Discipline() { }
    }
}