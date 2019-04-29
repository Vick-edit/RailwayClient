using System;
using Microsoft.EntityFrameworkCore;

namespace RailwayClient.DataAccess.SettingsEF
{
    /// <summary>
    ///     Интерфейс для взаимодействия с БД
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary> Сохранить изменения в БД </summary>
        void Commit();

        /// <summary> Совойства для доступа к сущностям БД </summary>
        /// <typeparam name="T">Тип сущности БД</typeparam>
        /// <returns>Объект для взаимодействия с сущностью из БД</returns>
        DbSet<T> Set<T>() where T : class;
    }
}