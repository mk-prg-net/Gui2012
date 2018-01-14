using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mkoIt.Db
{
    public interface IEntityView<TEntity, TEntityId>
        where TEntity : class
    {
        TEntityId Id
        {
            get;
            set;
        }

        TEntityId DummyId
        {
            get;
        }

        /// <summary>
        /// Liefert das Entity, dessen Inhalt die View darstellt
        /// </summary>
        TEntity Entity
        {
            get;
        }

        /// <summary>
        /// Aktualisiert den Inhalt der View mit den im Entity geänderten Daten
        /// </summary>
        /// <param name="entity"></param>
        void SetEntity(TEntity entity);

        /// <summary>
        /// Aktualisiert das entity mit den in der View geänderten Daten
        /// </summary>
        /// <param name="entity"></param>
        void UpdateEntity();

        /// <summary>
        /// True, wenn View für ein leeres, neues Geschäftsobjekt steht
        /// </summary>
        bool IsDummyView
        {
            get;
        }

    }
}
