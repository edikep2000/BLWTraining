-- add column for field _eventName
ALTER TABLE [TrainingSessionLiveEvents] ADD [EventName] varchar(255) NULL

go

UPDATE [TrainingSessionLiveEvents] SET [EventName] = ' '

go

ALTER TABLE [TrainingSessionLiveEvents] ALTER COLUMN [EventName] varchar(255) NOT NULL

go

