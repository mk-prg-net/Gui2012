
//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 7.3.2012
//
//  Projekt.......: mkoItAsp
//  Name..........: BoBaseSessionState.cs
//  Aufgabe/Fkt...: Spezielle Ableitung von der Basisklasse SessionStateFilterAndSortEntities,
//                  mit der die Filter eines BoBaseSqlToLinq- Objektes vereinfacht gesetzt werden.
//
//
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;


namespace mkoIt.Asp
{
    [Serializable]
    public class BoSessionStateSortColumnDefs<TState, TEntity> : mkoIt.Db.BoBase<mkoIt.Db.SortColumnDef, string, mkoIt.Db.SortColumnDef>
        where TState : SessionStateFilterAndSortEntities<TEntity>
        where TEntity: class
    {
        TState state;

        public BoSessionStateSortColumnDefs() : base("") { }

        public void init(TState state)
        {
            this.state = state;
        }

        protected override Type[] AllEntityViewTypes()
        {
            return new Type[]{typeof(Db.SortColumnDef)};
        }

        protected override Type GetBoThatInclude(Type typeTEntityView)
        {
            return this.GetType();
        }

        protected override bool sortByDerivat(IQueryable<Db.SortColumnDef> tab, string ColName, bool desc, out IQueryable<Db.SortColumnDef> tabOrdered)
        {
            tabOrdered = tab;
            return false;
        }

        public override IQueryable<Db.SortColumnDef> EntityCollection
        {
            get { return state.SortJob.AsQueryable(); }
        }

        protected override Db.SortColumnDef CreateView(Db.SortColumnDef entity)
        {
            return (Db.SortColumnDef)entity.Clone();
        }

        public override Db.FilterFunctor<Db.SortColumnDef, string> CreateIdFilter(string Id)
        {
            throw new NotImplementedException();
        }

        public override void Insert(Db.SortColumnDef view)
        {
            state.SortJobAppend(view);
        }

        public override void Update(Db.SortColumnDef view)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Db.SortColumnDef view)
        {
            throw new NotImplementedException();
        }

        public override void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
