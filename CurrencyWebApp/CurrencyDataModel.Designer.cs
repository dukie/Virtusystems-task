﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("CurrencyDataModel", "CurrencyRefCurrencyRate", "CurrencyRef", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(CurrencyWebApp.CurrencyRef), "CurrencyRate", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(CurrencyWebApp.CurrencyRate))]

#endregion

namespace CurrencyWebApp
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class CurrencyDataModelContainer1 : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new CurrencyDataModelContainer1 object using the connection string found in the 'CurrencyDataModelContainer1' section of the application configuration file.
        /// </summary>
        public CurrencyDataModelContainer1() : base("name=CurrencyDataModelContainer1", "CurrencyDataModelContainer1")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new CurrencyDataModelContainer1 object.
        /// </summary>
        public CurrencyDataModelContainer1(string connectionString) : base(connectionString, "CurrencyDataModelContainer1")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new CurrencyDataModelContainer1 object.
        /// </summary>
        public CurrencyDataModelContainer1(EntityConnection connection) : base(connection, "CurrencyDataModelContainer1")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<CurrencyRef> CurrencyRefSet
        {
            get
            {
                if ((_CurrencyRefSet == null))
                {
                    _CurrencyRefSet = base.CreateObjectSet<CurrencyRef>("CurrencyRefSet");
                }
                return _CurrencyRefSet;
            }
        }
        private ObjectSet<CurrencyRef> _CurrencyRefSet;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<CurrencyRate> CurrencyRateSet
        {
            get
            {
                if ((_CurrencyRateSet == null))
                {
                    _CurrencyRateSet = base.CreateObjectSet<CurrencyRate>("CurrencyRateSet");
                }
                return _CurrencyRateSet;
            }
        }
        private ObjectSet<CurrencyRate> _CurrencyRateSet;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the CurrencyRefSet EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCurrencyRefSet(CurrencyRef currencyRef)
        {
            base.AddObject("CurrencyRefSet", currencyRef);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the CurrencyRateSet EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCurrencyRateSet(CurrencyRate currencyRate)
        {
            base.AddObject("CurrencyRateSet", currencyRate);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="CurrencyDataModel", Name="CurrencyRate")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class CurrencyRate : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new CurrencyRate object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="rate">Initial value of the rate property.</param>
        /// <param name="date">Initial value of the date property.</param>
        public static CurrencyRate CreateCurrencyRate(global::System.Int32 id, global::System.Decimal rate, global::System.DateTime date)
        {
            CurrencyRate currencyRate = new CurrencyRate();
            currencyRate.Id = id;
            currencyRate.rate = rate;
            currencyRate.date = date;
            return currencyRate;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal rate
        {
            get
            {
                return _rate;
            }
            set
            {
                OnrateChanging(value);
                ReportPropertyChanging("rate");
                _rate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("rate");
                OnrateChanged();
            }
        }
        private global::System.Decimal _rate;
        partial void OnrateChanging(global::System.Decimal value);
        partial void OnrateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime date
        {
            get
            {
                return _date;
            }
            set
            {
                OndateChanging(value);
                ReportPropertyChanging("date");
                _date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("date");
                OndateChanged();
            }
        }
        private global::System.DateTime _date;
        partial void OndateChanging(global::System.DateTime value);
        partial void OndateChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("CurrencyDataModel", "CurrencyRefCurrencyRate", "CurrencyRef")]
        public CurrencyRef CurrencyRef
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CurrencyRef>("CurrencyDataModel.CurrencyRefCurrencyRate", "CurrencyRef").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CurrencyRef>("CurrencyDataModel.CurrencyRefCurrencyRate", "CurrencyRef").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<CurrencyRef> CurrencyRefReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CurrencyRef>("CurrencyDataModel.CurrencyRefCurrencyRate", "CurrencyRef");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<CurrencyRef>("CurrencyDataModel.CurrencyRefCurrencyRate", "CurrencyRef", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="CurrencyDataModel", Name="CurrencyRef")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class CurrencyRef : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new CurrencyRef object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="code">Initial value of the code property.</param>
        /// <param name="name">Initial value of the name property.</param>
        /// <param name="nominal">Initial value of the nominal property.</param>
        /// <param name="numcode">Initial value of the numcode property.</param>
        /// <param name="charcode">Initial value of the charcode property.</param>
        public static CurrencyRef CreateCurrencyRef(global::System.Int32 id, global::System.String code, global::System.String name, global::System.Decimal nominal, global::System.Int32 numcode, global::System.String charcode)
        {
            CurrencyRef currencyRef = new CurrencyRef();
            currencyRef.Id = id;
            currencyRef.code = code;
            currencyRef.name = name;
            currencyRef.nominal = nominal;
            currencyRef.numcode = numcode;
            currencyRef.charcode = charcode;
            return currencyRef;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String code
        {
            get
            {
                return _code;
            }
            set
            {
                OncodeChanging(value);
                ReportPropertyChanging("code");
                _code = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("code");
                OncodeChanged();
            }
        }
        private global::System.String _code;
        partial void OncodeChanging(global::System.String value);
        partial void OncodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
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
                _name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("name");
                OnnameChanged();
            }
        }
        private global::System.String _name;
        partial void OnnameChanging(global::System.String value);
        partial void OnnameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal nominal
        {
            get
            {
                return _nominal;
            }
            set
            {
                OnnominalChanging(value);
                ReportPropertyChanging("nominal");
                _nominal = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("nominal");
                OnnominalChanged();
            }
        }
        private global::System.Decimal _nominal;
        partial void OnnominalChanging(global::System.Decimal value);
        partial void OnnominalChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 numcode
        {
            get
            {
                return _numcode;
            }
            set
            {
                OnnumcodeChanging(value);
                ReportPropertyChanging("numcode");
                _numcode = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("numcode");
                OnnumcodeChanged();
            }
        }
        private global::System.Int32 _numcode;
        partial void OnnumcodeChanging(global::System.Int32 value);
        partial void OnnumcodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String charcode
        {
            get
            {
                return _charcode;
            }
            set
            {
                OncharcodeChanging(value);
                ReportPropertyChanging("charcode");
                _charcode = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("charcode");
                OncharcodeChanged();
            }
        }
        private global::System.String _charcode;
        partial void OncharcodeChanging(global::System.String value);
        partial void OncharcodeChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("CurrencyDataModel", "CurrencyRefCurrencyRate", "CurrencyRate")]
        public EntityCollection<CurrencyRate> CurrencyRate
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<CurrencyRate>("CurrencyDataModel.CurrencyRefCurrencyRate", "CurrencyRate");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<CurrencyRate>("CurrencyDataModel.CurrencyRefCurrencyRate", "CurrencyRate", value);
                }
            }
        }

        #endregion

    }

    #endregion

    
}
