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
namespace STWC_Timesheet
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class stwcEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new stwcEntities object using the connection string found in the 'stwcEntities' section of the application configuration file.
        /// </summary>
        public stwcEntities() : base("name=stwcEntities", "stwcEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new stwcEntities object.
        /// </summary>
        public stwcEntities(string connectionString) : base(connectionString, "stwcEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new stwcEntities object.
        /// </summary>
        public stwcEntities(EntityConnection connection) : base(connection, "stwcEntities")
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
        public ObjectSet<ship> ships
        {
            get
            {
                if ((_ships == null))
                {
                    _ships = base.CreateObjectSet<ship>("ships");
                }
                return _ships;
            }
        }
        private ObjectSet<ship> _ships;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<user_entry> user_entry
        {
            get
            {
                if ((_user_entry == null))
                {
                    _user_entry = base.CreateObjectSet<user_entry>("user_entry");
                }
                return _user_entry;
            }
        }
        private ObjectSet<user_entry> _user_entry;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<user> users
        {
            get
            {
                if ((_users == null))
                {
                    _users = base.CreateObjectSet<user>("users");
                }
                return _users;
            }
        }
        private ObjectSet<user> _users;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the ships EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToships(ship ship)
        {
            base.AddObject("ships", ship);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the user_entry EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTouser_entry(user_entry user_entry)
        {
            base.AddObject("user_entry", user_entry);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the users EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTousers(user user)
        {
            base.AddObject("users", user);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="stwcModel", Name="ship")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class ship : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new ship object.
        /// </summary>
        /// <param name="ship_id">Initial value of the ship_id property.</param>
        public static ship Createship(global::System.Int32 ship_id)
        {
            ship ship = new ship();
            ship.ship_id = ship_id;
            return ship;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ship_id
        {
            get
            {
                return _ship_id;
            }
            set
            {
                if (_ship_id != value)
                {
                    Onship_idChanging(value);
                    ReportPropertyChanging("ship_id");
                    _ship_id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ship_id");
                    Onship_idChanged();
                }
            }
        }
        private global::System.Int32 _ship_id;
        partial void Onship_idChanging(global::System.Int32 value);
        partial void Onship_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ship_name
        {
            get
            {
                return _ship_name;
            }
            set
            {
                Onship_nameChanging(value);
                ReportPropertyChanging("ship_name");
                _ship_name = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ship_name");
                Onship_nameChanged();
            }
        }
        private global::System.String _ship_name;
        partial void Onship_nameChanging(global::System.String value);
        partial void Onship_nameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> ship_IMO
        {
            get
            {
                return _ship_IMO;
            }
            set
            {
                Onship_IMOChanging(value);
                ReportPropertyChanging("ship_IMO");
                _ship_IMO = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ship_IMO");
                Onship_IMOChanged();
            }
        }
        private Nullable<global::System.Int32> _ship_IMO;
        partial void Onship_IMOChanging(Nullable<global::System.Int32> value);
        partial void Onship_IMOChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> serial_number
        {
            get
            {
                return _serial_number;
            }
            set
            {
                Onserial_numberChanging(value);
                ReportPropertyChanging("serial_number");
                _serial_number = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("serial_number");
                Onserial_numberChanged();
            }
        }
        private Nullable<global::System.Int32> _serial_number;
        partial void Onserial_numberChanging(Nullable<global::System.Int32> value);
        partial void Onserial_numberChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String licence_key
        {
            get
            {
                return _licence_key;
            }
            set
            {
                Onlicence_keyChanging(value);
                ReportPropertyChanging("licence_key");
                _licence_key = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("licence_key");
                Onlicence_keyChanged();
            }
        }
        private global::System.String _licence_key;
        partial void Onlicence_keyChanging(global::System.String value);
        partial void Onlicence_keyChanged();

        #endregion

    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="stwcModel", Name="user")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class user : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new user object.
        /// </summary>
        /// <param name="user_id">Initial value of the user_id property.</param>
        public static user Createuser(global::System.Int32 user_id)
        {
            user user = new user();
            user.user_id = user_id;
            return user;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 user_id
        {
            get
            {
                return _user_id;
            }
            set
            {
                if (_user_id != value)
                {
                    Onuser_idChanging(value);
                    ReportPropertyChanging("user_id");
                    _user_id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("user_id");
                    Onuser_idChanged();
                }
            }
        }
        private global::System.Int32 _user_id;
        partial void Onuser_idChanging(global::System.Int32 value);
        partial void Onuser_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String user_name
        {
            get
            {
                return _user_name;
            }
            set
            {
                Onuser_nameChanging(value);
                ReportPropertyChanging("user_name");
                _user_name = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("user_name");
                Onuser_nameChanged();
            }
        }
        private global::System.String _user_name;
        partial void Onuser_nameChanging(global::System.String value);
        partial void Onuser_nameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                OnfirstnameChanging(value);
                ReportPropertyChanging("firstname");
                _firstname = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("firstname");
                OnfirstnameChanged();
            }
        }
        private global::System.String _firstname;
        partial void OnfirstnameChanging(global::System.String value);
        partial void OnfirstnameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                OnlastnameChanging(value);
                ReportPropertyChanging("lastname");
                _lastname = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("lastname");
                OnlastnameChanged();
            }
        }
        private global::System.String _lastname;
        partial void OnlastnameChanging(global::System.String value);
        partial void OnlastnameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
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
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> rankid
        {
            get
            {
                return _rankid;
            }
            set
            {
                OnrankidChanging(value);
                ReportPropertyChanging("rankid");
                _rankid = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("rankid");
                OnrankidChanged();
            }
        }
        private Nullable<global::System.Int32> _rankid;
        partial void OnrankidChanging(Nullable<global::System.Int32> value);
        partial void OnrankidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> signon_date
        {
            get
            {
                return _signon_date;
            }
            set
            {
                Onsignon_dateChanging(value);
                ReportPropertyChanging("signon_date");
                _signon_date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("signon_date");
                Onsignon_dateChanged();
            }
        }
        private Nullable<global::System.DateTime> _signon_date;
        partial void Onsignon_dateChanging(Nullable<global::System.DateTime> value);
        partial void Onsignon_dateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> signoff_date
        {
            get
            {
                return _signoff_date;
            }
            set
            {
                Onsignoff_dateChanging(value);
                ReportPropertyChanging("signoff_date");
                _signoff_date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("signoff_date");
                Onsignoff_dateChanged();
            }
        }
        private Nullable<global::System.DateTime> _signoff_date;
        partial void Onsignoff_dateChanging(Nullable<global::System.DateTime> value);
        partial void Onsignoff_dateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String password
        {
            get
            {
                return _password;
            }
            set
            {
                OnpasswordChanging(value);
                ReportPropertyChanging("password");
                _password = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("password");
                OnpasswordChanged();
            }
        }
        private global::System.String _password;
        partial void OnpasswordChanging(global::System.String value);
        partial void OnpasswordChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String passport_number
        {
            get
            {
                return _passport_number;
            }
            set
            {
                Onpassport_numberChanging(value);
                ReportPropertyChanging("passport_number");
                _passport_number = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("passport_number");
                Onpassport_numberChanged();
            }
        }
        private global::System.String _passport_number;
        partial void Onpassport_numberChanging(global::System.String value);
        partial void Onpassport_numberChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String cdc_number
        {
            get
            {
                return _cdc_number;
            }
            set
            {
                Oncdc_numberChanging(value);
                ReportPropertyChanging("cdc_number");
                _cdc_number = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("cdc_number");
                Oncdc_numberChanged();
            }
        }
        private global::System.String _cdc_number;
        partial void Oncdc_numberChanging(global::System.String value);
        partial void Oncdc_numberChanged();

        #endregion

    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="stwcModel", Name="user_entry")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class user_entry : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new user_entry object.
        /// </summary>
        /// <param name="entry_id">Initial value of the entry_id property.</param>
        public static user_entry Createuser_entry(global::System.Int32 entry_id)
        {
            user_entry user_entry = new user_entry();
            user_entry.entry_id = entry_id;
            return user_entry;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 entry_id
        {
            get
            {
                return _entry_id;
            }
            set
            {
                if (_entry_id != value)
                {
                    Onentry_idChanging(value);
                    ReportPropertyChanging("entry_id");
                    _entry_id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("entry_id");
                    Onentry_idChanged();
                }
            }
        }
        private global::System.Int32 _entry_id;
        partial void Onentry_idChanging(global::System.Int32 value);
        partial void Onentry_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> user_id
        {
            get
            {
                return _user_id;
            }
            set
            {
                Onuser_idChanging(value);
                ReportPropertyChanging("user_id");
                _user_id = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("user_id");
                Onuser_idChanged();
            }
        }
        private Nullable<global::System.Int32> _user_id;
        partial void Onuser_idChanging(Nullable<global::System.Int32> value);
        partial void Onuser_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> ship_id
        {
            get
            {
                return _ship_id;
            }
            set
            {
                Onship_idChanging(value);
                ReportPropertyChanging("ship_id");
                _ship_id = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ship_id");
                Onship_idChanged();
            }
        }
        private Nullable<global::System.Int32> _ship_id;
        partial void Onship_idChanging(Nullable<global::System.Int32> value);
        partial void Onship_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> work_date
        {
            get
            {
                return _work_date;
            }
            set
            {
                Onwork_dateChanging(value);
                ReportPropertyChanging("work_date");
                _work_date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("work_date");
                Onwork_dateChanged();
            }
        }
        private Nullable<global::System.DateTime> _work_date;
        partial void Onwork_dateChanging(Nullable<global::System.DateTime> value);
        partial void Onwork_dateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String comments
        {
            get
            {
                return _comments;
            }
            set
            {
                OncommentsChanging(value);
                ReportPropertyChanging("comments");
                _comments = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("comments");
                OncommentsChanged();
            }
        }
        private global::System.String _comments;
        partial void OncommentsChanging(global::System.String value);
        partial void OncommentsChanged();

        #endregion

    
    }

    #endregion

    
}
