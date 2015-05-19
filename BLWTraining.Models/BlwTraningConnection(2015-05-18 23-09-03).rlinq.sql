-- add column for field _isDownloadable
ALTER TABLE [TrainingSessionFiles] ADD [IsDownloadable] bit NULL

go

UPDATE [TrainingSessionFiles] SET [IsDownloadable] = 0

go

ALTER TABLE [TrainingSessionFiles] ALTER COLUMN [IsDownloadable] bit NOT NULL

go

-- BLWTraining.Models.TrainingSessionLiveEvents
CREATE TABLE [TrainingSessionLiveEvents] (
    [FMSUrl] varchar(255) NULL,             -- _fMSUrl
    [Id] int IDENTITY NOT NULL,             -- _id
    [StartDate] datetime NOT NULL,          -- _startDate
    [TrainingSessionId] int NOT NULL,       -- _traiiningSessions
    CONSTRAINT [pk_TrainingSessionLiveEvents] PRIMARY KEY ([Id])
)

go

ALTER TABLE [TrainingSessionLiveEvents] ADD CONSTRAINT [ref_TrnngSssnLvEvnts__0B0854F2] FOREIGN KEY ([TrainingSessionId]) REFERENCES [TraiiningSessions]([Id])

go

-- Index 'idx_TrnngSssnLvEvnts_TrnngSssn' was not detected in the database. It will be created
CREATE INDEX [idx_TrnngSssnLvEvnts_TrnngSssn] ON [TrainingSessionLiveEvents]([TrainingSessionId])

go

