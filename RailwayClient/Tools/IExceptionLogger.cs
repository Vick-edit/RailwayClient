using System;

namespace RailwayClient.Tools
{
    /// <summary>
    ///     Интерфейс логера ошибок, выполняет простое логирование
    /// </summary>
    public interface IExceptionLogger
    {
        /// <summary> Залогировать сообщение об ошибке </summary>
        /// <param name="error">Ошибка, сведения о которой будут сохранены</param>
        /// <param name="additionalInfo">Дополнительная информация</param>
        void Log(Exception error, string additionalInfo = null);
    }
}