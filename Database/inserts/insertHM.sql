USE [laboratorySystem]
go
Insert into	[dbo].[Lab_Info]
values('El youm Elwaheid','Minya','Smalout','El Safsafia ')
--insert values to Main_Test_Group
Insert into	Main_Test_Group
values
	('Kidney Function','El youm Elwaheid'),
	('Hormones','El youm Elwaheid'),
	('Haematology Unit','El youm Elwaheid'),
	('Thyroid Function Tests','El youm Elwaheid'),
	('Torch Profile' ,'El youm Elwaheid'),
	('Endocrinology Unit','El youm Elwaheid'),
	('Complete Blood Count','El youm Elwaheid')


--Insert values to Sub_Test
Insert into	Sub_Test
values
	
	('Bl.urea',1),
	('Serum Creatinine',1),
	('Serum Uric Acid',1),
	('Serum Calcium (Total)',1),
	('Serum Calcium (Ionized)',1),
	('Serum Phosphorus',1),
	('Serum Sodium',1),
	('Serum Potassium',1),
	('Serum Pregnanacy Test',2),
	('Urine',2),
	('Total T3',4),
	('Free T3',4),
	('Total T4',4),
	('Free T4',4),
	('TSH',4),

	('Toxoplasma IgM',5),
	('Toxoplasma IgG',5),
	('CMV IgM',5),
	('CMV IgG',5),
	('Rubella IgM',5),
	('Rubella IgG',5),
	('Herpes I IgM',5),
	('Herpes I IgG',5),
	('Herpes II IgM',5),
	('Herpes II IgG',5),

	('FSH',6),
	('LH',6),
	('Progesterone',6),
	('Estradiol (E2)',6),
	('Prolactin',6),
	('Total Testosterone',6),
	('Free Testosterone',6),
	('DHEA-S',6),
	('DHEA',6),
	('TSH',6),

	('Red Cell Count',7),
	('Haemoglobin',7),
	('Haematocrit',7),
	('MCV',7),
	('MCH',7),
	('MCHC',7),
	('Platelets Count',7),
	('White Cell Count',7)


---------------------------------------

USE [laboratorySystem]
go

--insert values to Main_Test_Group
Insert into	Main_Test_Group
values
	 ('liver Function','El youm Elwaheid'),
	 ('lipid profile','El youm Elwaheid'),
	
	 ('Blood Glucose','El youm Elwaheid')
	
	

--Insert values to Sub_Test
Insert into	Sub_Test
values

	('Total bilirubin',8), 
	('Direct bilirubin',8),
	('lndirect bilirubin ',8),
	('SGOT (AST)',8),
	('SGPT (AST)',8),
	('Alk.Phosphatase',8),
	('Albumin',8),

	('Total cholesterol',9), 
	('Triglycerides',9),
	('HDL cholesterol ',9),
	('LDL cholesterol',9),
	('VLDL cholesterol',9),
	('Risk ratio(cholesterol/HDL)',9),
	('RISK ratio ll(LDL/HDL)',9),
	

	

	('Fasting Blood Glucose',11),
	('2h PP Glucose',11),
	('Random Blood Glucose',11),
	('Serum Fructosamine',11),
	('Glycosylated Hb.',11)


	select s.*, m.GroupName from Sub_Test  s, [dbo].[Main_Test_Group] m
	where  s.GroupID = m.GroupID

	select * from [dbo].[Test_Normal_Value]

	insert into [dbo].[Test_Normal_Value]
	value(1,'','','AdultMale')
	value(1,'','','Adultfamle')
	value(1,'','','Male')
	value(1,'','','AdultMale')