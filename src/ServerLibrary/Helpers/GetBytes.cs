namespace ServerLibrary.Helpers
{
    public static class GetBytes
    {
        /// <summary>
        /// Асинхронный метод для получения <see cref="byte[]"/> из файла
        /// </summary>
        /// <param name="filePath">Путь до файла</param>
        /// <returns>Массив байтов <see cref="byte[]"/></returns>
        /// <exception cref="FileNotFoundException">Ошибка, говорящая, что файл не найден</exception>
        /// <exception cref="Exception">Ошибка чтения файла</exception>
        public static async Task<byte[]> GetArrayAsync(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException("File not found", filePath);

                return await File.ReadAllBytesAsync(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading file: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Метод для получения <see cref="byte[]"/> из файла
        /// </summary>
        /// <param name="filePath">Путь до файла</param>
        /// <returns>Массив байтов <see cref="byte[]"/></returns>
        /// <exception cref="FileNotFoundException">Ошибка, говорящая, что файл не найден</exception>
        /// <exception cref="Exception">Ошибка чтения файла</exception>
        public static byte[] GetArray(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException("File not found", filePath);

                return File.ReadAllBytes(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading file: {ex.Message}", ex);
            }
        }
    }
}
