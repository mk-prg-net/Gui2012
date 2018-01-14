using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mkoDb
{
    public class BoEventLog : mkoIt.Db.BoBaseSqlToLinq<EventLogDb.DtxEventLogDataContext, EventLogDb.EventLog, int, BoEventLog.View>
    {
        public BoEventLog() : base(new EventLogDb.DtxEventLogDataContext(), "created") { }

        public class View
        {
            public View() { }

            public View(EventLogDb.EventLog entity)
            {
                Id = entity.id;
                Autor = entity.author;
                VerfasstAm = entity.created;
                Typ = entity.EventLogTypes.name;

                Log = entity.log.Value;
            }

            [mkoIt.Db.MapPropertyToColName("id")]
            public int Id { get; set; }

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
            public string Autor { get; set; }

            [mkoIt.Db.MapPropertyToColName("created")]
            public DateTime VerfasstAm { get; set; }

            [mkoIt.Db.MapPropertyToColName("DerivatTyp")]
            public string Typ { get; set; }

            public string Log { get; set; }

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

        protected override BoEventLog.View CreateView(EventLogDb.EventLog entity)
        {
            return new View(entity);
        }


        public override void Insert(BoEventLog.View view)
        {
            throw new NotImplementedException();
        }

        public override void Update(BoEventLog.View view)
        {
            throw new NotImplementedException();
        }





        public override mkoIt.Db.FilterFunctor<EventLogDb.EventLog, int> CreateIdFilter(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
