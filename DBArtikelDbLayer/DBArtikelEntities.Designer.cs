﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM-Beziehungsmetadaten

[assembly: EdmRelationshipAttribute("DBArtikelModel", "FKeyLieferenaten", "Lieferanten", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(DBArtikelDbLayer.Lieferanten), "Artikel", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(DBArtikelDbLayer.Artikel), true)]
[assembly: EdmRelationshipAttribute("DBArtikelModel", "FKeyProdukte", "Produkte", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(DBArtikelDbLayer.Produkte), "Artikel", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(DBArtikelDbLayer.Artikel), true)]

#endregion

namespace DBArtikelDbLayer
{
    #region Kontexte
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    public partial class DBArtikelEntities : ObjectContext
    {
        #region Konstruktoren
    
        /// <summary>
        /// Initialisiert ein neues DBArtikelEntities-Objekt mithilfe der in Abschnitt 'DBArtikelEntities' der Anwendungskonfigurationsdatei gefundenen Verbindungszeichenfolge.
        /// </summary>
        public DBArtikelEntities() : base("name=DBArtikelEntities", "DBArtikelEntities")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialisiert ein neues DBArtikelEntities-Objekt.
        /// </summary>
        public DBArtikelEntities(string connectionString) : base(connectionString, "DBArtikelEntities")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialisiert ein neues DBArtikelEntities-Objekt.
        /// </summary>
        public DBArtikelEntities(EntityConnection connection) : base(connection, "DBArtikelEntities")
        {
            OnContextCreated();
        }
    
        #endregion
    
        #region Partielle Methoden
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet-Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        public ObjectSet<Artikel> Artikel
        {
            get
            {
                if ((_Artikel == null))
                {
                    _Artikel = base.CreateObjectSet<Artikel>("Artikel");
                }
                return _Artikel;
            }
        }
        private ObjectSet<Artikel> _Artikel;
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        public ObjectSet<Lieferanten> Lieferanten
        {
            get
            {
                if ((_Lieferanten == null))
                {
                    _Lieferanten = base.CreateObjectSet<Lieferanten>("Lieferanten");
                }
                return _Lieferanten;
            }
        }
        private ObjectSet<Lieferanten> _Lieferanten;
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        public ObjectSet<Produkte> Produkte
        {
            get
            {
                if ((_Produkte == null))
                {
                    _Produkte = base.CreateObjectSet<Produkte>("Produkte");
                }
                return _Produkte;
            }
        }
        private ObjectSet<Produkte> _Produkte;
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        public ObjectSet<ArtikelDetailsView> ArtikelDetailsView
        {
            get
            {
                if ((_ArtikelDetailsView == null))
                {
                    _ArtikelDetailsView = base.CreateObjectSet<ArtikelDetailsView>("ArtikelDetailsView");
                }
                return _ArtikelDetailsView;
            }
        }
        private ObjectSet<ArtikelDetailsView> _ArtikelDetailsView;

        #endregion
        #region AddTo-Methoden
    
        /// <summary>
        /// Veraltete Methode zum Hinzufügen eines neuen Objekts zum EntitySet 'Artikel'. Verwenden Sie stattdessen die Methode '.Add' der zugeordneten Eigenschaft 'ObjectSet&lt;T&gt;'.
        /// </summary>
        public void AddToArtikel(Artikel artikel)
        {
            base.AddObject("Artikel", artikel);
        }
    
        /// <summary>
        /// Veraltete Methode zum Hinzufügen eines neuen Objekts zum EntitySet 'Lieferanten'. Verwenden Sie stattdessen die Methode '.Add' der zugeordneten Eigenschaft 'ObjectSet&lt;T&gt;'.
        /// </summary>
        public void AddToLieferanten(Lieferanten lieferanten)
        {
            base.AddObject("Lieferanten", lieferanten);
        }
    
        /// <summary>
        /// Veraltete Methode zum Hinzufügen eines neuen Objekts zum EntitySet 'Produkte'. Verwenden Sie stattdessen die Methode '.Add' der zugeordneten Eigenschaft 'ObjectSet&lt;T&gt;'.
        /// </summary>
        public void AddToProdukte(Produkte produkte)
        {
            base.AddObject("Produkte", produkte);
        }
    
        /// <summary>
        /// Veraltete Methode zum Hinzufügen eines neuen Objekts zum EntitySet 'ArtikelDetailsView'. Verwenden Sie stattdessen die Methode '.Add' der zugeordneten Eigenschaft 'ObjectSet&lt;T&gt;'.
        /// </summary>
        public void AddToArtikelDetailsView(ArtikelDetailsView artikelDetailsView)
        {
            base.AddObject("ArtikelDetailsView", artikelDetailsView);
        }

        #endregion
    }
    

    #endregion
    
    #region Entitäten
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DBArtikelModel", Name="Artikel")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Artikel : EntityObject
    {
        #region Factory-Methode
    
        /// <summary>
        /// Erstellt ein neues Artikel-Objekt.
        /// </summary>
        /// <param name="artnr">Anfangswert der Eigenschaft artnr.</param>
        /// <param name="lfnr">Anfangswert der Eigenschaft lfnr.</param>
        /// <param name="pnr">Anfangswert der Eigenschaft pnr.</param>
        public static Artikel CreateArtikel(global::System.Int32 artnr, global::System.Int32 lfnr, global::System.Int32 pnr)
        {
            Artikel artikel = new Artikel();
            artikel.artnr = artnr;
            artikel.lfnr = lfnr;
            artikel.pnr = pnr;
            return artikel;
        }

        #endregion
        #region Primitive Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 artnr
        {
            get
            {
                return _artnr;
            }
            set
            {
                OnartnrChanging(value);
                ReportPropertyChanging("artnr");
                _artnr = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("artnr");
                OnartnrChanged();
            }
        }
        private global::System.Int32 _artnr;
        partial void OnartnrChanging(global::System.Int32 value);
        partial void OnartnrChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 lfnr
        {
            get
            {
                return _lfnr;
            }
            set
            {
                if (_lfnr != value)
                {
                    OnlfnrChanging(value);
                    ReportPropertyChanging("lfnr");
                    _lfnr = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("lfnr");
                    OnlfnrChanged();
                }
            }
        }
        private global::System.Int32 _lfnr;
        partial void OnlfnrChanging(global::System.Int32 value);
        partial void OnlfnrChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 pnr
        {
            get
            {
                return _pnr;
            }
            set
            {
                if (_pnr != value)
                {
                    OnpnrChanging(value);
                    ReportPropertyChanging("pnr");
                    _pnr = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("pnr");
                    OnpnrChanged();
                }
            }
        }
        private global::System.Int32 _pnr;
        partial void OnpnrChanging(global::System.Int32 value);
        partial void OnpnrChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> vorrat
        {
            get
            {
                return _vorrat;
            }
            set
            {
                OnvorratChanging(value);
                ReportPropertyChanging("vorrat");
                _vorrat = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("vorrat");
                OnvorratChanged();
            }
        }
        private Nullable<global::System.Int32> _vorrat;
        partial void OnvorratChanging(Nullable<global::System.Int32> value);
        partial void OnvorratChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> preis
        {
            get
            {
                return _preis;
            }
            set
            {
                OnpreisChanging(value);
                ReportPropertyChanging("preis");
                _preis = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("preis");
                OnpreisChanged();
            }
        }
        private Nullable<global::System.Decimal> _preis;
        partial void OnpreisChanging(Nullable<global::System.Decimal> value);
        partial void OnpreisChanged();

        #endregion
    
        #region Navigationseigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("DBArtikelModel", "FKeyLieferenaten", "Lieferanten")]
        public Lieferanten Lieferanten
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Lieferanten>("DBArtikelModel.FKeyLieferenaten", "Lieferanten").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Lieferanten>("DBArtikelModel.FKeyLieferenaten", "Lieferanten").Value = value;
            }
        }
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Lieferanten> LieferantenReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Lieferanten>("DBArtikelModel.FKeyLieferenaten", "Lieferanten");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Lieferanten>("DBArtikelModel.FKeyLieferenaten", "Lieferanten", value);
                }
            }
        }
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("DBArtikelModel", "FKeyProdukte", "Produkte")]
        public Produkte Produkte
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Produkte>("DBArtikelModel.FKeyProdukte", "Produkte").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Produkte>("DBArtikelModel.FKeyProdukte", "Produkte").Value = value;
            }
        }
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Produkte> ProdukteReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Produkte>("DBArtikelModel.FKeyProdukte", "Produkte");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Produkte>("DBArtikelModel.FKeyProdukte", "Produkte", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DBArtikelModel", Name="ArtikelDetailsView")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class ArtikelDetailsView : EntityObject
    {
        #region Factory-Methode
    
        /// <summary>
        /// Erstellt ein neues ArtikelDetailsView-Objekt.
        /// </summary>
        /// <param name="artnr">Anfangswert der Eigenschaft artnr.</param>
        /// <param name="lfnr">Anfangswert der Eigenschaft lfnr.</param>
        /// <param name="pnr">Anfangswert der Eigenschaft pnr.</param>
        public static ArtikelDetailsView CreateArtikelDetailsView(global::System.Int32 artnr, global::System.Int32 lfnr, global::System.Int32 pnr)
        {
            ArtikelDetailsView artikelDetailsView = new ArtikelDetailsView();
            artikelDetailsView.artnr = artnr;
            artikelDetailsView.lfnr = lfnr;
            artikelDetailsView.pnr = pnr;
            return artikelDetailsView;
        }

        #endregion
        #region Primitive Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 artnr
        {
            get
            {
                return _artnr;
            }
            set
            {
                if (_artnr != value)
                {
                    OnartnrChanging(value);
                    ReportPropertyChanging("artnr");
                    _artnr = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("artnr");
                    OnartnrChanged();
                }
            }
        }
        private global::System.Int32 _artnr;
        partial void OnartnrChanging(global::System.Int32 value);
        partial void OnartnrChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 lfnr
        {
            get
            {
                return _lfnr;
            }
            set
            {
                if (_lfnr != value)
                {
                    OnlfnrChanging(value);
                    ReportPropertyChanging("lfnr");
                    _lfnr = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("lfnr");
                    OnlfnrChanged();
                }
            }
        }
        private global::System.Int32 _lfnr;
        partial void OnlfnrChanging(global::System.Int32 value);
        partial void OnlfnrChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 pnr
        {
            get
            {
                return _pnr;
            }
            set
            {
                if (_pnr != value)
                {
                    OnpnrChanging(value);
                    ReportPropertyChanging("pnr");
                    _pnr = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("pnr");
                    OnpnrChanged();
                }
            }
        }
        private global::System.Int32 _pnr;
        partial void OnpnrChanging(global::System.Int32 value);
        partial void OnpnrChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> vorrat
        {
            get
            {
                return _vorrat;
            }
            set
            {
                OnvorratChanging(value);
                ReportPropertyChanging("vorrat");
                _vorrat = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("vorrat");
                OnvorratChanged();
            }
        }
        private Nullable<global::System.Int32> _vorrat;
        partial void OnvorratChanging(Nullable<global::System.Int32> value);
        partial void OnvorratChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> preis
        {
            get
            {
                return _preis;
            }
            set
            {
                OnpreisChanging(value);
                ReportPropertyChanging("preis");
                _preis = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("preis");
                OnpreisChanged();
            }
        }
        private Nullable<global::System.Decimal> _preis;
        partial void OnpreisChanging(Nullable<global::System.Decimal> value);
        partial void OnpreisChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String LieferantName
        {
            get
            {
                return _LieferantName;
            }
            set
            {
                OnLieferantNameChanging(value);
                ReportPropertyChanging("LieferantName");
                _LieferantName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("LieferantName");
                OnLieferantNameChanged();
            }
        }
        private global::System.String _LieferantName;
        partial void OnLieferantNameChanging(global::System.String value);
        partial void OnLieferantNameChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String LieferantEmail
        {
            get
            {
                return _LieferantEmail;
            }
            set
            {
                OnLieferantEmailChanging(value);
                ReportPropertyChanging("LieferantEmail");
                _LieferantEmail = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("LieferantEmail");
                OnLieferantEmailChanged();
            }
        }
        private global::System.String _LieferantEmail;
        partial void OnLieferantEmailChanging(global::System.String value);
        partial void OnLieferantEmailChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String LieferantPlz
        {
            get
            {
                return _LieferantPlz;
            }
            set
            {
                OnLieferantPlzChanging(value);
                ReportPropertyChanging("LieferantPlz");
                _LieferantPlz = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("LieferantPlz");
                OnLieferantPlzChanged();
            }
        }
        private global::System.String _LieferantPlz;
        partial void OnLieferantPlzChanging(global::System.String value);
        partial void OnLieferantPlzChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ProduktName
        {
            get
            {
                return _ProduktName;
            }
            set
            {
                OnProduktNameChanging(value);
                ReportPropertyChanging("ProduktName");
                _ProduktName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ProduktName");
                OnProduktNameChanged();
            }
        }
        private global::System.String _ProduktName;
        partial void OnProduktNameChanging(global::System.String value);
        partial void OnProduktNameChanged();

        #endregion
    
    }
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DBArtikelModel", Name="Lieferanten")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Lieferanten : EntityObject
    {
        #region Factory-Methode
    
        /// <summary>
        /// Erstellt ein neues Lieferanten-Objekt.
        /// </summary>
        /// <param name="lfnr">Anfangswert der Eigenschaft lfnr.</param>
        public static Lieferanten CreateLieferanten(global::System.Int32 lfnr)
        {
            Lieferanten lieferanten = new Lieferanten();
            lieferanten.lfnr = lfnr;
            return lieferanten;
        }

        #endregion
        #region Primitive Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 lfnr
        {
            get
            {
                return _lfnr;
            }
            set
            {
                if (_lfnr != value)
                {
                    OnlfnrChanging(value);
                    ReportPropertyChanging("lfnr");
                    _lfnr = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("lfnr");
                    OnlfnrChanged();
                }
            }
        }
        private global::System.Int32 _lfnr;
        partial void OnlfnrChanging(global::System.Int32 value);
        partial void OnlfnrChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String name
        {
            get
            {
                return _name;
            }
            set
            {
                OnnameChanging(value);
                ReportPropertyChanging("name");
                _name = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("name");
                OnnameChanged();
            }
        }
        private global::System.String _name;
        partial void OnnameChanging(global::System.String value);
        partial void OnnameChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String email
        {
            get
            {
                return _email;
            }
            set
            {
                OnemailChanging(value);
                ReportPropertyChanging("email");
                _email = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("email");
                OnemailChanged();
            }
        }
        private global::System.String _email;
        partial void OnemailChanging(global::System.String value);
        partial void OnemailChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String plz
        {
            get
            {
                return _plz;
            }
            set
            {
                OnplzChanging(value);
                ReportPropertyChanging("plz");
                _plz = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("plz");
                OnplzChanged();
            }
        }
        private global::System.String _plz;
        partial void OnplzChanging(global::System.String value);
        partial void OnplzChanged();

        #endregion
    
        #region Navigationseigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("DBArtikelModel", "FKeyLieferenaten", "Artikel")]
        public EntityCollection<Artikel> Artikel
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Artikel>("DBArtikelModel.FKeyLieferenaten", "Artikel");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Artikel>("DBArtikelModel.FKeyLieferenaten", "Artikel", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DBArtikelModel", Name="Produkte")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Produkte : EntityObject
    {
        #region Factory-Methode
    
        /// <summary>
        /// Erstellt ein neues Produkte-Objekt.
        /// </summary>
        /// <param name="pnr">Anfangswert der Eigenschaft pnr.</param>
        public static Produkte CreateProdukte(global::System.Int32 pnr)
        {
            Produkte produkte = new Produkte();
            produkte.pnr = pnr;
            return produkte;
        }

        #endregion
        #region Primitive Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 pnr
        {
            get
            {
                return _pnr;
            }
            set
            {
                if (_pnr != value)
                {
                    OnpnrChanging(value);
                    ReportPropertyChanging("pnr");
                    _pnr = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("pnr");
                    OnpnrChanged();
                }
            }
        }
        private global::System.Int32 _pnr;
        partial void OnpnrChanging(global::System.Int32 value);
        partial void OnpnrChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String prodName
        {
            get
            {
                return _prodName;
            }
            set
            {
                OnprodNameChanging(value);
                ReportPropertyChanging("prodName");
                _prodName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("prodName");
                OnprodNameChanged();
            }
        }
        private global::System.String _prodName;
        partial void OnprodNameChanging(global::System.String value);
        partial void OnprodNameChanged();

        #endregion
    
        #region Navigationseigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("DBArtikelModel", "FKeyProdukte", "Artikel")]
        public EntityCollection<Artikel> Artikel
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Artikel>("DBArtikelModel.FKeyProdukte", "Artikel");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Artikel>("DBArtikelModel.FKeyProdukte", "Artikel", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
