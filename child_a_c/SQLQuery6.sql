ALTER TABLE [dbo].[Images]
ADD CONSTRAINT FK_Images_Children
FOREIGN KEY (related_child_id)
REFERENCES [dbo].[Children](child_id)
ON DELETE CASCADE;
