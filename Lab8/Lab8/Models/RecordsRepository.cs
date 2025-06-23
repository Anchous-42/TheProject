using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lab8.Models
{
    /// <summary>
    /// Репозиторий для работы с записями данных
    /// </summary>
    /// <typeparam name="T">Тип хранимых данных</typeparam>
    internal class RecordsRepository<T>
    {
        private int _idCounter = 0; // Счетчик для генерации ID записей
        private List<Record<T>> _records; // Коллекция хранимых записей
        private readonly string _savePath; // Путь для сохранения данных

        /// <summary>
        /// Конструктор для десериализации JSON
        /// </summary>
        /// <param name="idCounter">Текущее значение счетчика ID</param>
        /// <param name="records">Список записей</param>
        [JsonConstructor]
        public RecordsRepository(int idCounter, List<Record<T>> records)
        {
            _idCounter = idCounter;
            _records = records ?? new List<Record<T>>(); // Защита от null
        }

        /// <summary>
        /// Основной конструктор репозитория
        /// </summary>
        /// <param name="savePath">Путь к файлу сохранения</param>
        /// <exception cref="ArgumentNullException">Если путь не указан</exception>
        public RecordsRepository(string savePath)
        {
            _savePath = savePath ?? throw new ArgumentNullException(nameof(savePath));
            _records = new List<Record<T>>();
            LoadFromFile(_savePath); // Загружаем данные при создании
        }

        /// <summary>
        /// Загружает данные из файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        private void LoadFromFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    var jsonString = File.ReadAllText(path);
                    var options = GetJsonSerializerOptions();
                    var repo = JsonSerializer.Deserialize<RecordsRepository<T>>(jsonString, options);

                    _records = repo._records ?? new List<Record<T>>();
                    _idCounter = repo._idCounter;
                }
                else
                {
                    // Инициализация нового репозитория, если файл не существует
                    _records = new List<Record<T>>();
                    _idCounter = 0;
                    SaveToFile(); // Создаем новый файл
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок десериализации
                Console.WriteLine($"Ошибка загрузки из файла: {ex.Message}");
                _records = new List<Record<T>>();
                _idCounter = 0;
            }
        }

        /// <summary>
        /// Сохраняет данные в файл
        /// </summary>
        /// <exception cref="Exception">При ошибках сохранения</exception>
        public void SaveToFile()
        {
            try
            {
                var options = GetJsonSerializerOptions();
                var jsonString = JsonSerializer.Serialize(this, options);

                // Создаем директорию, если ее нет
                var directory = Path.GetDirectoryName(_savePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllText(_savePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения в файл: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Возвращает настройки сериализации JSON
        /// </summary>
        private JsonSerializerOptions GetJsonSerializerOptions()
        {
            return new JsonSerializerOptions
            {
                WriteIndented = true, // Форматированный вывод
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // camelCase для свойств
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull // Пропуск null
            };
        }

        // Свойства для сериализации

        /// <summary>
        /// Текущее значение счетчика ID (только для сериализации)
        /// </summary>
        [JsonInclude]
        public int IdCounter => _idCounter;

        /// <summary>
        /// Коллекция записей (только для сериализации)
        /// </summary>
        [JsonInclude]
        public List<Record<T>> Records => _records;

        /// <summary>
        /// Возвращает текущее значение счетчика ID
        /// </summary>
        public int GetIdCounter()
        {
            return _idCounter;
        }

        /// <summary>
        /// Возвращает все записи
        /// </summary>
        public IEnumerable<Record<T>> GetRecords() => _records;

        /// <summary>
        /// Находит запись по ID
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <returns>Найденная запись</returns>
        /// <exception cref="ArgumentException">Если запись не найдена</exception>
        public Record<T> GetById(int id)
        {
            var record = _records.Find(r => r.Id == id);
            return record ?? throw new ArgumentException($"Запись с id {id} не найдена");
        }

        /// <summary>
        /// Добавляет новую запись
        /// </summary>
        /// <param name="value">Данные для сохранения</param>
        /// <returns>ID новой записи</returns>
        public int Add(T value)
        {
            _idCounter += 1;
            _records.Add(new Record<T>(_idCounter, value));
            return _idCounter;
        }

        /// <summary>
        /// Удаляет запись по ID
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <exception cref="ArgumentException">Если запись не найдена</exception>
        public void RemoveById(int id)
        {
            int removed = _records.RemoveAll(r => r.Id == id);
            if (removed == 0)
            {
                throw new ArgumentException($"Запись с id {id} не найдена");
            }
        }

        /// <summary>
        /// Обновляет данные записи
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <param name="value">Новые данные</param>
        public void UpdateById(int id, T value)
        {
            var record = GetById(id); // Используем существующую валидацию
            record.Data = value;
        }
    }
}