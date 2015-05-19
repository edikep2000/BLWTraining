#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using System.ComponentModel;
using BLWTraining.Models;

namespace BLWTraining.Models	
{
	[System.Serializable()]
	public partial class TraningSessionSubscriptions : INotifyPropertyChanging, INotifyPropertyChanged, System.Runtime.Serialization.ISerializable
	{
		private int _id;
		[System.ComponentModel.DataAnnotations.Required()]
		[System.ComponentModel.DataAnnotations.Key()]
		public virtual int Id
		{
			get
			{
				return this._id;
			}
			set
			{
				if(this._id != value)
				{
					this.OnPropertyChanging("Id");
					this._id = value;
					this.OnPropertyChanged("Id");
				}
			}
		}
		
		private int _userId;
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual int UserId
		{
			get
			{
				return this._userId;
			}
			set
			{
				if(this._userId != value)
				{
					this.OnPropertyChanging("UserId");
					this._userId = value;
					this.OnPropertyChanged("UserId");
				}
			}
		}
		
		private int _traininSessionId;
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual int TraininSessionId
		{
			get
			{
				return this._traininSessionId;
			}
			set
			{
				if(this._traininSessionId != value)
				{
					this.OnPropertyChanging("TraininSessionId");
					this._traininSessionId = value;
					this.OnPropertyChanged("TraininSessionId");
				}
			}
		}
		
		private DateTime _startDate;
		[System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual DateTime StartDate
		{
			get
			{
				return this._startDate;
			}
			set
			{
				if(this._startDate != value)
				{
					this.OnPropertyChanging("StartDate");
					this._startDate = value;
					this.OnPropertyChanged("StartDate");
				}
			}
		}
		
		private DateTime _expiryDate;
		[System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual DateTime ExpiryDate
		{
			get
			{
				return this._expiryDate;
			}
			set
			{
				if(this._expiryDate != value)
				{
					this.OnPropertyChanging("ExpiryDate");
					this._expiryDate = value;
					this.OnPropertyChanged("ExpiryDate");
				}
			}
		}
		
		private TraiiningSessions _traiiningSessions;
		public virtual TraiiningSessions TraiiningSessions
		{
			get
			{
				return this._traiiningSessions;
			}
			set
			{
				if(this._traiiningSessions != value)
				{
					this.OnPropertyChanging("TraiiningSessions");
					this._traiiningSessions = value;
					this.OnPropertyChanged("TraiiningSessions");
				}
			}
		}
		
		private IdentityUser _identityUser;
		public virtual IdentityUser IdentityUser
		{
			get
			{
				return this._identityUser;
			}
			set
			{
				if(this._identityUser != value)
				{
					this.OnPropertyChanging("IdentityUser");
					this._identityUser = value;
					this.OnPropertyChanged("IdentityUser");
				}
			}
		}
		
		#region INotifyPropertyChanging members
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		protected virtual void OnPropertyChanging(string propertyName)
		{
			if(this.PropertyChanging != null)
			{
				this.PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
			}
		}
		
		#endregion
		
		#region INotifyPropertyChanged members
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if(this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		#endregion
		
		#region ISerializable Implementation
		
		public TraningSessionSubscriptions()
		{
		}
		
		protected TraningSessionSubscriptions(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			this.Id = info.GetInt32("Id");
			this.UserId = info.GetInt32("UserId");
			this.TraininSessionId = info.GetInt32("TraininSessionId");
			this.StartDate = (DateTime)info.GetValue("StartDate", typeof(DateTime));
			this.ExpiryDate = (DateTime)info.GetValue("ExpiryDate", typeof(DateTime));
			CustomizeDeserializationProcess(info, context);
		}
		
		public virtual void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			info.AddValue("Id", this.Id, typeof(int));
			info.AddValue("UserId", this.UserId, typeof(int));
			info.AddValue("TraininSessionId", this.TraininSessionId, typeof(int));
			info.AddValue("StartDate", this.StartDate, typeof(DateTime));
			info.AddValue("ExpiryDate", this.ExpiryDate, typeof(DateTime));
			CustomizeSerializationProcess(info, context);
		}
		
		partial void CustomizeSerializationProcess(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
		partial void CustomizeDeserializationProcess(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
		#endregion
	}
}
#pragma warning restore 1591
