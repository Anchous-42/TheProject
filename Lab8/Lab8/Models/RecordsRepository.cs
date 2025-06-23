using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lab8.Models
{
    internal class RecordsRepository<T>
    {
        private int _idCounter = 0;
        private List<Record<T>> _records;
        private readonly string _savePath;

        // Add JsonConstructor attribute for proper deserialization
        [JsonConstructor]
        public RecordsRepository(int idCounter, List<Record<T>> records)
        {
            _idCounter = idCounter;
            _records = records ?? new List<Record<T>>();
        }

        public RecordsRepository(string savePath)
        {
            _savePath = savePath ?? throw new ArgumentNullException(nameof(savePath));
            _records = new List<Record<T>>();
            LoadFromFile(_savePath);
        }

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
                    // Initialize new repository if file doesn't exist
                    _records = new List<Record<T>>();
                    _idCounter = 0;
                    SaveToFile();
                }
            }
            catch (Exception ex)
            {
                // Handle deserialization errors
                Console.WriteLine($"Error loading from file: {ex.Message}");
                _records = new List<Record<T>>();
                _idCounter = 0;
            }
        }

        public void SaveToFile()
        {
            try
            {
                var options = GetJsonSerializerOptions();
                var jsonString = JsonSerializer.Serialize(this, options);

                // Ensure directory exists
                var directory = Path.GetDirectoryName(_savePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllText(_savePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
                throw;
            }
        }

        private JsonSerializerOptions GetJsonSerializerOptions()
        {
            return new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
        }

        // Add JsonInclude attributes for serialization
        [JsonInclude]
        public int IdCounter => _idCounter;

        [JsonInclude]
        public List<Record<T>> Records => _records;

        public int GetIdCounter()
        {
            return _idCounter;
        }
        public IEnumerable<Record<T>> GetRecords() => _records;

        public Record<T> GetById(int id)
        {
            var record = _records.Find(r => r.Id == id);
            return record ?? throw new ArgumentException($"Cannot find record with id {id}");
        }

        public int Add(T value)
        {
            _idCounter += 1;
            _records.Add(new Record<T>(_idCounter, value));
            return _idCounter;
        }

        public void RemoveById(int id)
        {
            int removed = _records.RemoveAll(r => r.Id == id);
            if (removed == 0)
            {
                throw new ArgumentException($"Cannot find record with id {id}");
            }
        }

        public void UpdateById(int id, T value)
        {
            var record = GetById(id); // Reuses existing validation
            record.Data = value;
        }
    }
}