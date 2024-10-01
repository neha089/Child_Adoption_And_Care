ALTER TABLE [dbo].[AdoptionRecords]
ADD CONSTRAINT FK__AdoptionR__child__4E88ABD4
FOREIGN KEY (child_id) 
REFERENCES [dbo].[Children](child_id) 
ON DELETE CASCADE;