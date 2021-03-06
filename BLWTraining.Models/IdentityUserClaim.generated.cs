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
	public partial class IdentityUserClaim : INotifyPropertyChanging, INotifyPropertyChanged, System.Runtime.Serialization.ISerializable
	{
		private int _id;
		[System.ComponentModel.DataAnnotations.Required()]
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
		
		private string _claimType;
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string ClaimType
		{
			get
			{
				return this._claimType;
			}
			set
			{
				if(this._claimType != value)
				{
					this.OnPropertyChanging("ClaimType");
					this._claimType = value;
					this.OnPropertyChanged("ClaimType");
				}
			}
		}
		
		private string _claimValue;
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string ClaimValue
		{
			get
			{
				return this._claimValue;
			}
			set
			{
				if(this._claimValue != value)
				{
					this.OnPropertyChanging("ClaimValue");
					this._claimValue = value;
					this.OnPropertyChanged("ClaimValue");
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
		
		public IdentityUserClaim()
		{
		}
		
		protected IdentityUserClaim(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			this.Id = info.GetInt32("Id");
			this.UserId = info.GetInt32("UserId");
			this.ClaimType = info.GetString("ClaimType");
			this.ClaimValue = info.GetString("ClaimValue");
			CustomizeDeserializationProcess(info, context);
		}
		
		public virtual void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			info.AddValue("Id", this.Id, typeof(int));
			info.AddValue("UserId", this.UserId, typeof(int));
			info.AddValue("ClaimType", this.ClaimType, typeof(string));
			info.AddValue("ClaimValue", this.ClaimValue, typeof(string));
			CustomizeSerializationProcess(info, context);
		}
		
		partial void CustomizeSerializationProcess(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
		partial void CustomizeDeserializationProcess(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
		#endregion
	}
}
#pragma warning restore 1591
