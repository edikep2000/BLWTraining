-- Column was read from database as: [Chapter] varchar(255) null
-- modify column for field _chapter
UPDATE [IdentityUser]
   SET [Chapter] = ' ' -- Add your own default value here, for when [Chapter] is null.
 WHERE [Chapter] IS NULL

go

ALTER TABLE [IdentityUser] ALTER COLUMN [Chapter] varchar(255) NOT NULL

go

-- Column was read from database as: [EmailAddress] varchar(255) null
-- modify column for field _emailAddress
UPDATE [IdentityUser]
   SET [EmailAddress] = ' ' -- Add your own default value here, for when [EmailAddress] is null.
 WHERE [EmailAddress] IS NULL

go

ALTER TABLE [IdentityUser] ALTER COLUMN [EmailAddress] varchar(255) NOT NULL

go

-- Column was read from database as: [FirstName] varchar(255) null
-- modify column for field _firstName
UPDATE [IdentityUser]
   SET [FirstName] = ' ' -- Add your own default value here, for when [FirstName] is null.
 WHERE [FirstName] IS NULL

go

ALTER TABLE [IdentityUser] ALTER COLUMN [FirstName] varchar(255) NOT NULL

go

-- add column for field _gender
ALTER TABLE [IdentityUser] ADD [Gender] varchar(255) NULL

go

UPDATE [IdentityUser] SET [Gender] = ' '

go

ALTER TABLE [IdentityUser] ALTER COLUMN [Gender] varchar(255) NOT NULL

go

-- Column was read from database as: [LastLogInDate] datetime not null
-- modify column for field _lastLogInDate
ALTER TABLE [IdentityUser] ALTER COLUMN [LastLogInDate] datetime NULL

go

-- Column was read from database as: [LastName] varchar(255) null
-- modify column for field _lastName
UPDATE [IdentityUser]
   SET [LastName] = ' ' -- Add your own default value here, for when [LastName] is null.
 WHERE [LastName] IS NULL

go

ALTER TABLE [IdentityUser] ALTER COLUMN [LastName] varchar(255) NOT NULL

go

-- Column was read from database as: [LockOutEndDateUtc] datetime not null
-- modify column for field _lockOutEndDateUtc
ALTER TABLE [IdentityUser] ALTER COLUMN [LockOutEndDateUtc] datetime NULL

go

-- Column was read from database as: [PasswordHash] varchar(255) null
-- modify column for field _passwordHash
UPDATE [IdentityUser]
   SET [PasswordHash] = ' ' -- Add your own default value here, for when [PasswordHash] is null.
 WHERE [PasswordHash] IS NULL

go

ALTER TABLE [IdentityUser] ALTER COLUMN [PasswordHash] varchar(255) NOT NULL

go

-- Column was read from database as: [PhoneNumber] varchar(255) null
-- modify column for field _phoneNumber
UPDATE [IdentityUser]
   SET [PhoneNumber] = ' ' -- Add your own default value here, for when [PhoneNumber] is null.
 WHERE [PhoneNumber] IS NULL

go

ALTER TABLE [IdentityUser] ALTER COLUMN [PhoneNumber] varchar(255) NOT NULL

go

