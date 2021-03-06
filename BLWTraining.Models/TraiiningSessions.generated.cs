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
	public partial class TraiiningSessions : INotifyPropertyChanging, INotifyPropertyChanged, System.Runtime.Serialization.ISerializable
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
		
		private string _name;
		[System.ComponentModel.DataAnnotations.StringLength(255)]
		public virtual string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				if(this._name != value)
				{
					this.OnPropertyChanging("Name");
					this._name = value;
					this.OnPropertyChanged("Name");
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
		
		private DateTime _endDate;
		[System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual DateTime EndDate
		{
			get
			{
				return this._endDate;
			}
			set
			{
				if(this._endDate != value)
				{
					this.OnPropertyChanging("EndDate");
					this._endDate = value;
					this.OnPropertyChanged("EndDate");
				}
			}
		}
		
		private DateTime _dateCreated;
		[System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual DateTime DateCreated
		{
			get
			{
				return this._dateCreated;
			}
			set
			{
				if(this._dateCreated != value)
				{
					this.OnPropertyChanging("DateCreated");
					this._dateCreated = value;
					this.OnPropertyChanged("DateCreated");
				}
			}
		}
		
		private int _daysAfterEndBeforeArchiving;
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual int DaysAfterEndBeforeArchiving
		{
			get
			{
				return this._daysAfterEndBeforeArchiving;
			}
			set
			{
				if(this._daysAfterEndBeforeArchiving != value)
				{
					this.OnPropertyChanging("DaysAfterEndBeforeArchiving");
					this._daysAfterEndBeforeArchiving = value;
					this.OnPropertyChanged("DaysAfterEndBeforeArchiving");
				}
			}
		}
		
		private string _description;
		[System.ComponentModel.DataAnnotations.StringLength(255)]
		public virtual string Description
		{
			get
			{
				return this._description;
			}
			set
			{
				if(this._description != value)
				{
					this.OnPropertyChanging("Description");
					this._description = value;
					this.OnPropertyChanged("Description");
				}
			}
		}
		
		private int _maximumNumberOfParticipants;
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual int MaximumNumberOfParticipants
		{
			get
			{
				return this._maximumNumberOfParticipants;
			}
			set
			{
				if(this._maximumNumberOfParticipants != value)
				{
					this.OnPropertyChanging("MaximumNumberOfParticipants");
					this._maximumNumberOfParticipants = value;
					this.OnPropertyChanged("MaximumNumberOfParticipants");
				}
			}
		}
		
		private IList<TrainingSessionFiles> _trainingSessionFiles = new List<TrainingSessionFiles>();
		public virtual IList<TrainingSessionFiles> TrainingSessionFiles
		{
			get
			{
				return this._trainingSessionFiles;
			}
		}
		
		private IList<TraningSessionSubscriptions> _traningSessionSubscriptions = new List<TraningSessionSubscriptions>();
		public virtual IList<TraningSessionSubscriptions> TraningSessionSubscriptions
		{
			get
			{
				return this._traningSessionSubscriptions;
			}
		}
		
		private IList<TrainingSessionLiveEvents> _trainingSessionLiveEvents = new List<TrainingSessionLiveEvents>();
		public virtual IList<TrainingSessionLiveEvents> TrainingSessionLiveEvents
		{
			get
			{
				return this._trainingSessionLiveEvents;
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
		
		public TraiiningSessions()
		{
		}
		
		protected TraiiningSessions(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			this.Id = info.GetInt32("Id");
			this.Name = info.GetString("Name");
			this.StartDate = (DateTime)info.GetValue("StartDate", typeof(DateTime));
			this.EndDate = (DateTime)info.GetValue("EndDate", typeof(DateTime));
			this.DateCreated = (DateTime)info.GetValue("DateCreated", typeof(DateTime));
			this.DaysAfterEndBeforeArchiving = info.GetInt32("DaysAfterEndBeforeArchiving");
			this.Description = info.GetString("Description");
			this.MaximumNumberOfParticipants = info.GetInt32("MaximumNumberOfParticipants");
			CustomizeDeserializationProcess(info, context);
		}
		
		public virtual void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			info.AddValue("Id", this.Id, typeof(int));
			info.AddValue("Name", this.Name, typeof(string));
			info.AddValue("StartDate", this.StartDate, typeof(DateTime));
			info.AddValue("EndDate", this.EndDate, typeof(DateTime));
			info.AddValue("DateCreated", this.DateCreated, typeof(DateTime));
			info.AddValue("DaysAfterEndBeforeArchiving", this.DaysAfterEndBeforeArchiving, typeof(int));
			info.AddValue("Description", this.Description, typeof(string));
			info.AddValue("MaximumNumberOfParticipants", this.MaximumNumberOfParticipants, typeof(int));
			CustomizeSerializationProcess(info, context);
		}
		
		partial void CustomizeSerializationProcess(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
		partial void CustomizeDeserializationProcess(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
		#endregion
	}
}
#pragma warning restore 1591
