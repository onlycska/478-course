using System;
using Xceed.Wpf.Toolkit;
using System.IO;

namespace ConsoleApp1
{
    /// <summary>
    /// Загрузка данных из текстового файла, сжатого по методу GZIP, в RichTextBox.
    /// </summary>
    public class LoadGZippedText
    {
        
    
        /// <summary>
        /// Процедура загрузки данных из текстового файла, сжатого по методу GZIP, в RichTextBox.
        /// </summary>
        /// <param name="filename">Путь к файлу.</param>
        /// <param name="edit">RichTextBox, в который будут загружены текстовые данные.</param>
        public void LoadText(string filename, RichTextBox edit)
        {
            FileStream sourceStream = null;
            System.IO.Compression.GZipStream uncompressedStream = null;
            StreamReader textReader = null;
            
            try
            {
                sourceStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                uncompressedStream = new System.IO.Compression.GZipStream(
                    sourceStream, System.IO.Compression.CompressionMode.Decompress, true);
                textReader = new StreamReader(uncompressedStream, true);
                edit.Text = textReader.ReadToEnd();
            }
            catch (FileNotFoundException ex)
            {
                throw new LoadFileException(("Файл по пути {0} не найден. ", filename) + ex.Message, ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new LoadFileException(("Для файла {0} недостаточно прав доступа. ", filename) + ex.Message, ex);
            }
            finally
            {
                if (sourceStream != null)
                {
                    sourceStream.Dispose();
                    sourceStream = null;
                }
                if (uncompressedStream != null)
                {
                    uncompressedStream.Dispose();
                    uncompressedStream = null;
                }
                if (textReader != null)
                {
                    textReader.Dispose();
                    textReader = null;
                }
            }
        }
    }
}