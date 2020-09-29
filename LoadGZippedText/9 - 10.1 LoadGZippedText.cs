using System;
using Xceed.Wpf.Toolkit;

namespace ConsoleApp1
{
    /// <summary>
    /// Загрузка данных из текстового файла, сжатого по методу GZIP, в RichTextBox.
    /// </summary>
    public class LoadGZippedText
    {
        private System.IO.FileStream sourceStream = null;
        private System.IO.Compression.GZipStream uncompressedStream = null;
        private System.IO.StreamReader textReader = null;
    
        /// <summary>
        /// Процедура загрузки данных из текстового файла, сжатого по методу GZIP, в RichTextBox.
        /// </summary>
        /// <param name="filename">Путь к файлу.</param>
        /// <param name="edit">RichTextBox, в который будут загружены текстовые данные.</param>
        public void LoadText(string filename, RichTextBox edit)
        {
            try
            {
                using (this.sourceStream = new System.IO.FileStream(filename,
                        System.IO.FileMode.Open, System.IO.FileAccess.Read,
                        System.IO.FileShare.Read))
                using (this.uncompressedStream = new System.IO.Compression.GZipStream(
                    sourceStream, System.IO.Compression.CompressionMode.Decompress, true))
                using (this.textReader = new System.IO.StreamReader(uncompressedStream, true))
                    edit.Text = textReader.ReadToEnd();
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw new LoadFileException(("Файл по пути {0} не найден. ", filename) + ex.Message, ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new LoadFileException(("Для файла {0} недостаточно прав доступа. ", filename) + ex.Message, ex);
            }
            finally
            {
                if (this.sourceStream != null)
                {
                    this.sourceStream = null;
                }
                if (this.uncompressedStream != null)
                {
                    this.uncompressedStream = null;
                }
                if (this.textReader != null)
                {
                    this.textReader = null;
                }
            }
            
        }
    }
}