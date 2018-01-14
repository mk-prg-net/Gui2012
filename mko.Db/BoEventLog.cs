using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mkoDb
{
    public class BoEventLog : mkoIt.Db.BoBaseSqlToLinq<EventLogDb.DtxEventLogDataContext, EventLogDb.EventLog, int, BoEventLog.View>
    {
        public BoEventLog() : base(new EventLogDb.DtxEventLogDataContext(), "created") { }

        public class View : mkoIt.Db.BoBaseView<EventLogDb.EventLog, int>
        {
            public View() { }

            public View(EventLogDb.EventLog entity)
                : base(entity)
            {                
            }   

            public class IdFilter : mkoIt.Db.FilterFunctor<EventLogDb.EventLog, int>{
                public IdFilter()
                {
                }

                public override IQueryable<EventLogDb.EventLog> filterImpl(IQueryable<EventLogDb.EventLog> srcTab)
                {
                    return srcTab.Where(r => r.id == RValue);
                }
            }

            

            [mkoIt.Db.MapPropertyToColName("author")]
            public string Autor {
                get
                {
                    return GetEntityPropertyRefValue(e => e.author);
                }
                set
                {
                    pushUpdateJob(value, (val, entity) => entity.author = val);
                }
            }

            [mkoIt.Db.MapPropertyToColName("created")]
            public DateTime? VerfasstAm { 
                get {
                    return GetEntityPropertyStructValue(e => e.created);
                }
                set
                {
                    pushUpdateJobNullable(value, (val, entity) => entity.created = val);
                }
            }

            [mkoIt.Db.MapPropertyToColName("DerivatTyp")]
            public string Typ
            {
                get
                {
                    return GetEntityPropertyRefValue(e => e.EventLogTypes.name);
                }
                set { }
            }


            public string Log {
                get
                {
                    return Entity.log.ToString();
                }
                set {
                } 
            }


            protected override int GetDummyId()
            {
                return -1;
            }

            protected override int GetEntityId(EventLogDb.EventLog Entity)
            {
                return Entity.id;
            }

            protected override void SetEntityId(int id, EventLogDb.EventLog Entity)
            {
                Entity.id = id;
            }
        }

        protected override Type[] AllEntityViewTypes()
        {
            return new Type[] { typeof(View) };
        }

        protected override Type GetBoThatInclude(Type typeTEntityView)
        {
            return typeof(BoEventLog);
        }

        protected override bool sortByDerivat(IQueryable<EventLogDb.EventLog> tab, string ColName, bool desc, out IQueryable<EventLogDb.EventLog> tabOrdered)
        {
            tabOrdered = null;

            switch (ColName)
            {
                case "DerivatTyp":
                    tabOrdered = sortHlp(tab, desc, r => r.EventLogTypes.name);
                    return true;
                default: ;
                    break;
            }

            return false;
        }



        public override void Delete(View view)
        {
            Delete(view.Id);
        }

        public override void Delete(int id)
        {
            try
            {
                var entity = ORMContext.EventLog.Where(r => r.id == id).First();

                ORMContext.EventLog.DeleteOnSubmit(entity);

                ORMContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw BoBaseException.Create("delete", ex);
            }
        }


        public void deleteAll()
        {
            try
            {
                var all = ORMContext.EventLog;

                ORMContext.EventLog.DeleteAllOnSubmit(all);

                ORMContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw BoBaseException.Create("deleteAll", ex);
            }

        }

        public override IQueryable<EventLogDb.EventLog> EntityCollection
        {
            get { return ORMContext.EventLog; }
        }

        public override BoEventLog.View CreateView()
        {
            return new View();
        }

        protected override BoEventLog.View CreateView(EventLogDb.EventLog entity)
        {
            return new View(entity);
        }


        public override void Insert(BoEventLog.View view)
        {
            throw new NotImplementedException();
        }

        public override mkoIt.Db.FilterFunctor<EventLogDb.EventLog, int> CreateIdFilter(int Id)
        {
            return new View.IdFilter() { RValue = Id };
        }

        public override void AddEntityToEntityCollection(EventLogDb.EventLog entity)
        {
            throw new NotImplementedException();
        }

        public override EventLogDb.EventLog CreateEntity()
        {
            return new EventLogDb.EventLog();
        }
        
    }
}
