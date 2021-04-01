using Newtonsoft.Json;
using System;
using System.IO;

namespace NoteApp.DataAccess
{
	/// <summary>
	/// Класс <see cref="ProjectManager"/>,
	/// реализующий метод для сохранения объекта класса Project в файл
	/// </summary>
	public static class ProjectManager
	{
        /// <summary>
        /// Хранит путь к файлу для записи
        /// </summary>
		public static string DefaultPath { get; private set; } =
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + 
				"\\NoteApp\\NoteApp.note";

		/// <summary>
		/// Метод, сохраняющий объекты класса Note
		/// </summary>
		public static void SaveToFile(Project project, string filename)
        {
			string defaultDirectory = Path.GetDirectoryName(DefaultPath);

			if (!Directory.Exists(defaultDirectory))
			{
				Directory.CreateDirectory(defaultDirectory);
			}

			JsonSerializer serializer = new JsonSerializer();

			using (StreamWriter sw = new StreamWriter(filename))
			{
				using (JsonWriter writer = new JsonTextWriter(sw))
				{
					serializer.Serialize(writer, project);
				}
			}
        }

		/// <summary>
		/// Метод, загружающий объекты класса Note
		/// </summary>
		public static Project LoadFromFile(string filename)
		{
			try
			{
				if (!File.Exists(filename))
				{
					return new Project();
				}
				
				JsonSerializer serializer = new JsonSerializer();
				using (StreamReader sr = new StreamReader(filename))
				{
					using (JsonReader reader = new JsonTextReader(sr))
					{
						return serializer.Deserialize<Project>(reader);
					}
				}
			}
			catch(JsonException)
            {
                return new Project();
			}
		}
	}
}
