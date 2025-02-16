﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Updater.Common
{
    public static class Global
    {
        /// <summary>
        /// Игра запущена в данный момент.
        /// </summary>
        public static bool IsGameStarted() => Process.GetProcessesByName("game").Any(x => x.MainWindowTitle == "WONDER");

        /// <summary>
        /// Location of updater file.
        /// </summary>
        public static string ExecutableLocation => Process.GetCurrentProcess().MainModule?.FileName ??
                                                   throw new InvalidOperationException("Executable location is null");

        /// <summary>
        /// Current executable file directory.
        /// </summary>
        public static string ClientPath => Path.GetDirectoryName(ExecutableLocation);


        private static readonly string[] SiteUrls =
        {
            "https://api.shaiyawonder.com/",
            //"https://api.shaiya-inferno.com/",
            //"https://api.shaiya-end.com/",
            //"https://api.shaiya-universe.com/",
            //"https://localhost:44313/"
        };

        /// <summary>
        /// Путь к сайту
        /// </summary>
        public static string SiteUrl => SiteUrls.First();

        
        /// <summary>
        /// Путь к дата файлу без расширения
        /// </summary>
        public static readonly string DataPath = Path.Combine(ClientPath, Properties.Resources.Data);
        
        /// <summary>
        /// Расширение sah файла
        /// </summary>
        private const string SAH_EXTENSION = ".sah";

        /// <summary>
        /// Расширение saf файла
        /// </summary>
        private const string SAF_EXTENSION = ".saf";

        /// <summary>
        /// Path to SAH file.
        /// </summary>
        public static readonly string SahPath = DataPath + SAH_EXTENSION;

        /// <summary>
        /// Path to SAF file.
        /// </summary>
        public static readonly string SafPath = DataPath + SAF_EXTENSION;


        /// <summary>
        /// Файлы, необходимые для запуска.
        /// </summary>
        public static string[] ClientFiles;


        /// <summary>
        /// Path to updater temp file.
        /// </summary>
        public static string TempUpdaterPath => Path.Combine(ClientPath, TEMP_UPDATER_FILENAME);

        /// <summary>
        /// 
        /// </summary>
        public static string NOTIFIER_FILENAME = "discord-helper.exe";

        /// <summary>
        /// 
        /// </summary>
        public const string SERVER_NAME = "SHAIYA WONDER";

        /// <summary>
        /// Название файла апдейтера
        /// </summary>
        public const string UPDATER_FILENAME = "Updater.exe";

        /// <summary>
        /// Название файла апдейтера для замены
        /// </summary>
        public const string TEMP_UPDATER_FILENAME = "UpdaterTemp.exe";
    }
}
