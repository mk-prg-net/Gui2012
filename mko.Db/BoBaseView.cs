//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 4.10.2012
//
//  Projekt.......: mkoIt.Db
//  Name..........: BoBaseView
//  Aufgabe/Fkt...: Implementierung eines View, bei der die Aktualisierung auf die tatsächlich geänderten 
//                  Werte beschränkt wird. Dabei werden von den Settern Jobs in eine Queue eingestellt. Die 
//                  Jobs sind als schöngefinkelte Lambdaausdrücke realisert, die die Zuweisung des neuen Wertes an die 
//                  zugrundeliegende Entity- Eigenschaft beschreiben. 
//
//
//<unit_environment>
//------------------------------------------------------------------
//  Zielmaschine..: PC 
//  Betriebssystem: Windows XP mit .NET 2.0
//  Werkzeuge.....: Visual Studio 2005
//  Autor.........: Martin Korneffel (mko)
//  Version 1.0...: 
//
// </unit_environment>
//
//<unit_history>
//------------------------------------------------------------------
//
//  Version.......: 1.1
//  Autor.........: Martin Korneffel (mko)
//  Datum.........: 
//  Änderungen....: 
//
//</unit_history>
//</unit_header>        
        
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mko.Algo.FunctionalProgramming;
using System.Diagnostics;

namespace mkoIt.Db
{
    public abstract class BoBaseView<TEntity, TEntityId> : IEntityView<TEntity, TEntityId>
        where TEntity : class
    {
        /// <summary>
        /// True, wenn View für ein leeres, neues Geschäftsobjekt steht
        /// </summary>
        public bool IsDummyView
        {
            get
            {
                return Id.Equals(DummyId);
            }
        }

        public TEntityId DummyId
        {
            get { 
                return GetDummyId(); 
            }
        }

        /// <summary>
        /// Überschreibung in abgeleiteter Klasse liefert die Id des Dummys. Der Dummy dient zur Implementierung 
        /// einer leeren Tabellenzeile in einer GridView, in dem ein neuer 
        /// </summary>
        /// <returns></returns>
        protected abstract TEntityId GetDummyId();

        // Referenz auf das Entity, auf das die View aufgebaut wird (für die Getter)
        public TEntity Entity
        {
            get
            {
                return _Entity;
            }
        }

        TEntity _Entity;        

        protected Nullable<T> GetEntityPropertyStructValue<T>(Func<TEntity, T> getPropertyValue)
            where T : struct
        {
            return Entity != null ? new Nullable<T>(getPropertyValue(Entity)) : new Nullable<T>();
        }

        protected Nullable<T> GetEntityPropertyNullableValue<T>(Func<TEntity, Nullable<T>> getPropertyValue)
            where T : struct
        {
            return Entity != null ? getPropertyValue(Entity) : new Nullable<T>();
        }

        protected T GetEntityPropertyRefValue<T>(Func<TEntity, T> getPropertyValue)
            where T : class
        {
            return Entity != null ? getPropertyValue(Entity) : null;
        }


        public BoBaseView()
        {
            _Entity = null;
        }

        public BoBaseView(TEntity entity)
        {
            SetEntity(entity);
        }

        // Liste aller Updatefunktionen, die beim nächsten update abzuarbeiten sind
        public Queue<Action<TEntity>> UpdateJobs = new Queue<Action<TEntity>>();

        /// <summary>
        /// Fügt einen Updatejob hinzu. Ein Updatejob besteht aus dem neuen Wert und einem 
        /// Lambda- Ausdruck, der die Zuweisung des Wertes an das Datenbankentity beschreibt.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="Value"></param>
        /// <param name="UpdateFunction"></param>
        public void pushUpdateJob<TValue>(TValue Value, Action<TValue, TEntity> UpdateFunction)
        {
            // Schönfinkeln des Lambdaausdruckes mit dem neuen Wert 
            var job = UpdateFunction.Curry(Value);
            UpdateJobs.Enqueue(job);
        }

        public void pushUpdateJobNullable<T>(Nullable<T> Value, Action<T, TEntity> UpdateFunction)
            where T : struct
        {
            if (Value.HasValue)
            {
                // Schönfinkeln des Lambdaausdruckes mit dem neuen Wert 
                var job = UpdateFunction.Curry(Value.Value);
                UpdateJobs.Enqueue(job);
            }
        }


        // Implementierung der auf Update- Jobs basierenden updates
        public void ExecUpdateJobs(TEntity entity)
        {
            while (UpdateJobs.Any())
            {
                // Der schnöngefinkelte Lambdaausdruck wird ausgeführt, wodurch die Aktualisierung der 
                // Entity- Eigenschaft implementiert wird
                UpdateJobs.Dequeue()(entity);
            }
        }


        /// <summary>
        /// Zugriff auf die ID des Entities
        /// </summary>
        public TEntityId Id
        {
            get
            {
                if (_Entity != null)
                    return GetEntityId(_Entity);
                else
                    return DummyId;
            }
            set
            {
                Debug.WriteLineIf(_Entity == null, "Die Entityid von " + GetType().FullName + " wird nicht gesetzt, da View ein Dummy ist");
                if(_Entity != null)
                    SetEntityId(value, _Entity);
            }
        }

        /// <summary>
        /// Überschreibung in abgeleiteter Klasse liefert den Schlüssel eines Entity
        /// </summary>
        /// <param name="Entity">Entity</param>
        /// <returns>Schlüssel</returns>
        protected abstract TEntityId GetEntityId(TEntity Entity);


        /// <summary>
        /// Überschreibung in abgeleiteter Klasse setzt den Schlüssel eines Entity
        /// </summary>
        /// <param name="id">neuer Schlüssel</param>
        /// <param name="Entity">Entity</param>
        protected abstract void SetEntityId(TEntityId id, TEntity Entity);
        

        /// <summary>
        /// Aktualisert die View mit neuen Entity- Daten
        /// </summary>
        /// <param name="entity"></param>
        public void SetEntity(TEntity entity)
        {
            _Entity = entity;
        }

        /// <summary>
        /// Aktualisert das Entiy mit neuen View- Daten
        /// </summary>
        public void UpdateEntity()
        {
            while (UpdateJobs.Any())
            {
                // Der schnöngefinkelte Lambdaausdruck wird ausgeführt, wodurch die Aktualisierung der 
                // Entity- Eigenschaft implementiert wird
                UpdateJobs.Dequeue()(_Entity);
            }
        }

    }
}
