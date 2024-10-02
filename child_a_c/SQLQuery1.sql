-- Inserting data into the Children table

INSERT INTO [dbo].[Children] 
    ([first_name], [last_name], [date_of_birth], [gender], [orphanage_id], [adopter_id], [date_of_adoption], [medical_history], [education_level], [special_needs], [profile_image])
VALUES 
    ('Aarav', 'Patel', '2012-04-15', 'Male', 3, NULL, NULL, 'No major medical issues', 'Primary School', NULL, 'aarav_patel.jpg'),
    ('Meera', 'Shah', '2010-09-23', 'Female', 4, 101, '2022-03-12', 'Asthma', 'Middle School', 'Needs assistance with asthma management', 'meera_shah.jpg'),
    ('Rohan', 'Singh', '2014-01-08', 'Male', 5, NULL, NULL, 'Allergic to peanuts', 'Kindergarten', 'Requires attention to dietary needs', 'rohan_singh.jpg'),
    ('Priya', 'Desai', '2009-07-30', 'Female', 3, 105, '2021-11-05', 'Diabetes Type 1', 'High School', 'Insulin dependent', 'priya_desai.jpg'),
    ('Vihan', 'Joshi', '2013-03-22', 'Male', 3, NULL, NULL, 'No known medical conditions', 'Primary School', NULL, 'vihan_joshi.jpg');
