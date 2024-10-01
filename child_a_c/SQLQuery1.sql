CREATE TABLE [dbo].[Users] (
    [user_id]       INT            IDENTITY (1, 1) NOT NULL,
    [username]      NVARCHAR (100) NOT NULL,
    [password]      NVARCHAR (255) NOT NULL,  -- Ensure to hash the password
    [user_type]     NVARCHAR (20)  NOT NULL,  -- Could be 'Admin', 'Adopter', or 'Orphanage'
    [user_ref_id]   INT            NOT NULL,  -- FK for Adopter/Orphanage/Admin
    PRIMARY KEY CLUSTERED ([user_id] ASC)
);
