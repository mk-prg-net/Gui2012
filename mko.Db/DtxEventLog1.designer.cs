﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.17626
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mkoDb.EventLogDb
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="GblDb")]
	public partial class DtxEventLogDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definitionen der Erweiterungsmethoden
    partial void OnCreated();
    partial void InsertEventLogTypes(EventLogTypes instance);
    partial void UpdateEventLogTypes(EventLogTypes instance);
    partial void DeleteEventLogTypes(EventLogTypes instance);
    partial void InsertEventLog(EventLog instance);
    partial void UpdateEventLog(EventLog instance);
    partial void DeleteEventLog(EventLog instance);
    #endregion
		
		public DtxEventLogDataContext() : 
				base(global::mkoDb.Properties.Settings.Default.GblDbConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public DtxEventLogDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DtxEventLogDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DtxEventLogDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DtxEventLogDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<EventLogTypes> EventLogTypes
		{
			get
			{
				return this.GetTable<EventLogTypes>();
			}
		}
		
		public System.Data.Linq.Table<EventLog> EventLog
		{
			get
			{
				return this.GetTable<EventLog>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="mko.EventLogTypes")]
	public partial class EventLogTypes : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private EntitySet<EventLog> _EventLog;
		
    #region Definitionen der Erweiterungsmethoden
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    #endregion
		
		public EventLogTypes()
		{
			this._EventLog = new EntitySet<EventLog>(new Action<EventLog>(this.attach_EventLog), new Action<EventLog>(this.detach_EventLog));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(1000) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="EventLogTypes_EventLog", Storage="_EventLog", ThisKey="id", OtherKey="EventLogType_id")]
		public EntitySet<EventLog> EventLog
		{
			get
			{
				return this._EventLog;
			}
			set
			{
				this._EventLog.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_EventLog(EventLog entity)
		{
			this.SendPropertyChanging();
			entity.EventLogTypes = this;
		}
		
		private void detach_EventLog(EventLog entity)
		{
			this.SendPropertyChanging();
			entity.EventLogTypes = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="mko.EventLog")]
	public partial class EventLog : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _EventLogType_id;
		
		private System.DateTime _created;
		
		private string _author;
		
		private System.Xml.Linq.XElement _log;
		
		private EntityRef<EventLogTypes> _EventLogTypes;
		
    #region Definitionen der Erweiterungsmethoden
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnEventLogType_idChanging(int value);
    partial void OnEventLogType_idChanged();
    partial void OncreatedChanging(System.DateTime value);
    partial void OncreatedChanged();
    partial void OnauthorChanging(string value);
    partial void OnauthorChanged();
    partial void OnlogChanging(System.Xml.Linq.XElement value);
    partial void OnlogChanged();
    #endregion
		
		public EventLog()
		{
			this._EventLogTypes = default(EntityRef<EventLogTypes>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventLogType_id", DbType="Int NOT NULL")]
		public int EventLogType_id
		{
			get
			{
				return this._EventLogType_id;
			}
			set
			{
				if ((this._EventLogType_id != value))
				{
					if (this._EventLogTypes.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnEventLogType_idChanging(value);
					this.SendPropertyChanging();
					this._EventLogType_id = value;
					this.SendPropertyChanged("EventLogType_id");
					this.OnEventLogType_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_created", DbType="DateTime NOT NULL")]
		public System.DateTime created
		{
			get
			{
				return this._created;
			}
			set
			{
				if ((this._created != value))
				{
					this.OncreatedChanging(value);
					this.SendPropertyChanging();
					this._created = value;
					this.SendPropertyChanged("created");
					this.OncreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_author", DbType="NVarChar(1000) NOT NULL", CanBeNull=false)]
		public string author
		{
			get
			{
				return this._author;
			}
			set
			{
				if ((this._author != value))
				{
					this.OnauthorChanging(value);
					this.SendPropertyChanging();
					this._author = value;
					this.SendPropertyChanged("author");
					this.OnauthorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[log]", Storage="_log", DbType="Xml NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public System.Xml.Linq.XElement log
		{
			get
			{
				return this._log;
			}
			set
			{
				if ((this._log != value))
				{
					this.OnlogChanging(value);
					this.SendPropertyChanging();
					this._log = value;
					this.SendPropertyChanged("log");
					this.OnlogChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="EventLogTypes_EventLog", Storage="_EventLogTypes", ThisKey="EventLogType_id", OtherKey="id", IsForeignKey=true)]
		public EventLogTypes EventLogTypes
		{
			get
			{
				return this._EventLogTypes.Entity;
			}
			set
			{
				EventLogTypes previousValue = this._EventLogTypes.Entity;
				if (((previousValue != value) 
							|| (this._EventLogTypes.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._EventLogTypes.Entity = null;
						previousValue.EventLog.Remove(this);
					}
					this._EventLogTypes.Entity = value;
					if ((value != null))
					{
						value.EventLog.Add(this);
						this._EventLogType_id = value.id;
					}
					else
					{
						this._EventLogType_id = default(int);
					}
					this.SendPropertyChanged("EventLogTypes");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
