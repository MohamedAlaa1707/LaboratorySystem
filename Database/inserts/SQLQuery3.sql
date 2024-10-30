select * from [dbo].[Test_Normal_Value]
select s.*, m.GroupName from Sub_Test  s, [dbo].[Main_Test_Group] m
  where  s.GroupID = m.GroupID and m.GroupID=7
  --CBC
  insert into [dbo].[Test_Normal_Value]
  values
  --38
  ('38','40','50','AdultMale'),('38','39','53','ChildMale '),
  ('38','36','46','Adultfemale '),('38','42','66','ChildFemale'),
  --39
  ('39','83','101','AdultMale'),('39','86','124','ChildMale '),
  ('39','83','101','Adultfemale '),('39','88','126','ChildFemale'),

  --41
  ('41','31.5','34.5','AdultMale'),('41', '31','37','ChildMale '),
  ('41','31.5','34.5','Adultfemale '),('41','31','37','ChildFemale')
  ,
  --40
  ('40','27','32','AdultMale'),('40','31','37','ChildMale '),
  ('40','27','32','Adultfemale '),('40','31','37','ChildFemale')
  ,
  --36
  ('36','4.5','5.5','AdultMale'),('36','4.5','5.5','ChildMale '),
  ('36','3.8','4.8','Adultfemale '),('36','3.8','4.8','ChildFemale'),
  --37
  ('37','4.6','6.2','AdultMale'),('37','4.6','6.2','ChildMale '),
  ('37','3.8','7.8','Adultfemale '),('37','3.8','7.8','ChildFemale'),
  --42
  ('42','150','450','AdultMale'),('42','150','450','ChildMale '),
  ('42','150','450','Adultfemale '),('42','150','450','ChildFemale'),
  --43
  ('43','4','10','AdultMale'),('43','4','10','ChildMale '),
  ('43','4','10','Adultfemale '),('43','4','10','ChildFemale')
  --- Mohamed Alaa
  insert into [dbo].[Test_Normal_Value] ([SubTestID] , [MinValue] , [MaxValue] , [Age_gender_cat] )
values
( 1 , '15' , '45' , 'AdultMale' ) , ( 1 , '15' , '45' , 'AdultFemale' ),
( 1 , '15' , '45' , 'ChildMale' ) , ( 1 , '15' , '45' , 'ChildFemale' ),

( 2 , '0.7' , '1.6' , 'AdultMale' ) , ( 2 , '0.6' , '1.3' , 'AdultFemale' ),
( 2 , '0.7' , '1.6' , 'ChildMale' ) , ( 2 , '0.6' , '1.3' , 'ChildFemale' ),

( 3 , '3.4' , '7.0' , 'AdultMale' ) , ( 3 , '3.4' , '7.0' , 'AdultFemale' ),
( 3 , '3.4' , '7.0' , 'ChildMale' ) , ( 3 , '3.4' , '7.0', 'ChildFemale' ),

( 4 , '8.5' , '10.5' , 'AdultMale' ) , ( 4 , '8.5' , '10.5' , 'AdultFemale' ),
( 4 , '8.5' , '10.5' , 'ChildMale' ) , ( 4 , '8.5' , '10.5' , 'ChildFemale' ),

( 5 , '1.10' , '1.33' , 'AdultMale' ) , ( 5 , '1.10' , '1.33' , 'AdultFemale' ),
( 5 , '1.10' , '1.33' , 'ChildMale' ) , ( 5 , '1.10' , '1.33' , 'ChildFemale' ),

( 6 , '2.5' , '4.8' , 'AdultMale' ) , ( 6 , '2.5' , '4.8' , 'AdultFemale' ),
( 6 , '2.5' , '4.8' , 'ChildMale' ) , ( 6 , '2.5' , '4.8' , 'ChildFemale' ),

( 7 , '135' , '145' , 'AdultMale' ) , ( 7 , '135' , '145' , 'AdultFemale' ),
( 7 , '135' , '145' , 'ChildMale' ) , ( 7 , '135' , '145' , 'ChildFemale' ),

( 8 , '3.5' , '5.5' , 'AdultMale' ) , ( 8 , '3.5' , '5.5' , 'AdultFemale' ),
( 8 , '3.5' , '5.5' , 'ChildMale' ) , ( 8 , '3.5' , '5.5' , 'ChildFemale' ),
------------------------------------------------------------------------------
( 51 , '70' , '200' , 'AdultMale' ) , ( 51 , '70' , '200' , 'AdultFemale' ),
( 51 , '70' , '200' , 'ChildMale' ) , ( 51 , '70' , '200' , 'ChildFemale' ),

( 52 , '40' , '160' , 'AdultMale' ) , ( 52 , '40' , '160' , 'AdultFemale' ),
( 52 , '40' , '160' , 'ChildMale' ) , ( 52 , '40', '160' , 'ChildFemale' ),

( 53 , '35' , '65' , 'AdultMale' ) , ( 53 , '35' , '65' , 'AdultFemale' ),
( 53 , '35' , '65' , 'ChildMale' ) , ( 53 , '35' , '65' , 'ChildFemale' ),

( 54 , '0' , '100' , 'AdultMale' ) , ( 54 , '0' , '100' , 'AdultFemale' ),
( 54 , '0' , '100' , 'ChildMale' ) , ( 54 , '0' , '100' , 'ChildFemale' ),

( 55 , '0' , '32' , 'AdultMale' ) , ( 55 , '0' , '32' , 'AdultFemale' ),
( 55 , '0' , '32' , 'ChildMale' ) , ( 55 , '0' , '32' , 'ChildFemale' ),

( 56 , '2.7' , '5.0' , 'AdultMale' ) , ( 56 , '2.7' , '5.0' , 'AdultFemale' ),
( 56 , '2.7' , '5.0' , 'ChildMale' ) , ( 56 , '2.7' , '5.0' , 'ChildFemale' ),

( 57 , '2.00' , '3.60' , 'AdultMale' ) , ( 57 , '2.00' , '3.60' , 'AdultFemale' ),
( 57 , '2.00' , '3.60' , 'ChildMale' ) , ( 57 , '2.00' , '3.60' , 'ChildFemale' ),
--------------------------------------------------------------------------------
( 44 , '0.2' , '1' , 'AdultMale' ) , ( 44 , '0.2' , '1' , 'AdultFemale' ),
( 44 , '0.2' , '1' , 'ChildMale' ) , ( 44 , '0.2' , '1' , 'ChildFemale' ),

( 45 , '0.0' , '0.3' , 'AdultMale' ) , ( 45 , '0.0' , '0.3' , 'AdultFemale' ),
( 45 , '0.0' , '0.3' , 'ChildMale' ) , ( 45 , '0.0' , '0.3' , 'ChildFemale' ),

( 46 , '0.2' , '0.7' , 'AdultMale' ) , ( 46 , '0.2' , '0.7' , 'AdultFemale' ),
( 46 , '0.2' , '0.7' , 'ChildMale' ) , ( 46 , '0.2' , '0.7' , 'ChildFemale' ),

( 47 , '0.0' , '40' , 'AdultMale' ) , ( 47 , '0.0' , '40' , 'AdultFemale' ),
( 47 , '0.0' , '40' , 'ChildMale' ) , ( 47 , '0.0' , '40' , 'ChildFemale' ),

( 48 , '0.0' , '40' , 'AdultMale' ) , ( 48 , '0.0' , '40' , 'AdultFemale' ),
( 48 , '0.0' , '40' , 'ChildMale' ) , ( 48 , '0.0' , '40' , 'ChildFemale' ),


( 49 , '42' , '270' , 'AdultMale' ) , ( 49 , '42' , '270' , 'AdultFemale' ),
( 49 , '42' , '270' , 'ChildMale' ) , ( 49 , '42' , '270' , 'ChildFemale' ),

( 50 , '3.5' , '5.3' , 'AdultMale' ) , ( 50 , '3.5' , '5.3' , 'AdultFemale' ),
( 50 , '3.5' , '5.3' , 'ChildMale' ) , ( 50 , '3.5' , '5.3' , 'ChildFemale' ),
--------------------------------------------------------------------------------
( 11 , '80' , '200' , 'AdultMale' ) , ( 11 , '80' , '200' , 'AdultFemale' ),
( 11 , '80' , '200' , 'ChildMale' ) , ( 11 , '80' , '200' , 'ChildFemale' ),

( 12 , '1.8' , '4.6' , 'AdultMale' ) , ( 12 , '1.8' , '4.6' , 'AdultFemale' ),
( 12 , '1.8' , '4.6' , 'ChildMale' ) , ( 12 , '1.8' , '4.6' , 'ChildFemale' ),

( 13 , '5.1' , '14.1' , 'AdultMale' ) , ( 13 , '5.1' , '14.1' , 'AdultFemale' ),
( 13 , '5.1' , '14.1' , 'ChildMale' ) , ( 13 , '5.1' , '14.1' , 'ChildFemale' ),

( 14 , '0.9' , '1.8' , 'AdultMale' ) , ( 14 , '0.9' , '1.8' , 'AdultFemale' ),
( 14 , '0.9' , '1.8' , 'ChildMale' ) , ( 14 , '0.9' , '1.8' , 'ChildFemale' ),

( 15 , '0.50' , '5.00' , 'AdultMale' ) , ( 15 , '0.50' , '5.00' , 'AdultFemale' ),
( 15 , '0.50' , '5.00' , 'ChildMale' ) , ( 15 , '0.50' , '5.00' , 'ChildFemale' ),
--------------------------------------------------------------------------------
( 58 , '60' , '110' , 'AdultMale' ) , ( 58 , '60' , '110' , 'AdultFemale' ),
( 58 , '60' , '110' , 'ChildMale' ) , ( 58 , '60' , '110' , 'ChildFemale' ),

( 59 , '60' , '140' , 'AdultMale' ) , ( 59 , '60' , '140' , 'AdultFemale' ),
( 59 , '60' , '140' , 'ChildMale' ) , ( 59 , '60' , '140' , 'ChildFemale' ),

( 60 , '70' , '160' , 'AdultMale' ) , ( 60 , '70' , '160' , 'AdultFemale' ),
( 60 , '70' , '160' , 'ChildMale' ) , ( 60 , '70' , '160' , 'ChildFemale' ),

( 61 , '10' , '40' , 'AdultMale' ) , ( 61 , '10' , '40' , 'AdultFemale' ),
( 61 , '10' , '40' , 'ChildMale' ) , ( 61 , '10' , '40' , 'ChildFemale' ),

( 62 , 'Non Diabetic , Prediabetic or well controied diabetic <5.7 Prediabetic or well controlled diabetic 5.7 - 6.5 Well controlled diabetic 5.6 - 7.0 Fair controlled diabetic 7.0 - 7.5 Poor controlled diabetic > 7.5' , 'Non Diabetic , Prediabetic or well controied diabetic <5.7 Prediabetic or well controlled diabetic 5.7 - 6.5 Well controlled diabetic 5.6 - 7.0 Fair controlled diabetic 7.0 - 7.5 Poor controlled diabetic > 7.5' , 'AdultMale' ),
( 62 , 'Non Diabetic , Prediabetic or well controied diabetic <5.7 Prediabetic or well controlled diabetic 5.7 - 6.5 Well controlled diabetic 5.6 - 7.0 Fair controlled diabetic 7.0 - 7.5 Poor controlled diabetic > 7.5' , 'Non Diabetic , Prediabetic or well controied diabetic <5.7 Prediabetic or well controlled diabetic 5.7 - 6.5 Well controlled diabetic 5.6 - 7.0 Fair controlled diabetic 7.0 - 7.5 Poor controlled diabetic > 7.5' , 'AdultFemale' ),
( 62 , 'Non Diabetic , Prediabetic or well controied diabetic <5.7 Prediabetic or well controlled diabetic 5.7 - 6.5 Well controlled diabetic 5.6 - 7.0 Fair controlled diabetic 7.0 - 7.5 Poor controlled diabetic > 7.5' , 'Non Diabetic , Prediabetic or well controied diabetic <5.7 Prediabetic or well controlled diabetic 5.7 - 6.5 Well controlled diabetic 5.6 - 7.0 Fair controlled diabetic 7.0 - 7.5 Poor controlled diabetic > 7.5' , 'Male' ) ,
( 62 , 'Non Diabetic , Prediabetic or well controied diabetic <5.7 Prediabetic or well controlled diabetic 5.7 - 6.5 Well controlled diabetic 5.6 - 7.0 Fair controlled diabetic 7.0 - 7.5 Poor controlled diabetic > 7.5' , 'Non Diabetic , Prediabetic or well controied diabetic <5.7 Prediabetic or well controlled diabetic 5.7 - 6.5 Well controlled diabetic 5.6 - 7.0 Fair controlled diabetic 7.0 - 7.5 Poor controlled diabetic > 7.5','Female' ),
--------------------------------------------------------------------------------
( 9 , '' , '' , 'AdultMale' ) , ( 9 , '' , '' , 'AdultFemale' ),
( 9 , '' , '' , 'ChildMale' ) , ( 9 , '' , '' , 'ChildFemale' ),

( 10 , '' , '' , 'AdultMale' ) , ( 10 , '' , '' , 'AdultFemale' ),
( 10 , '' , '' , 'ChildMale' ) , ( 10 , '' , '' , 'ChildFemale' );

----------------------------------------------------------------------------
-- Hatem 

insert into [dbo].[Test_Normal_Value] ([SubTestID],[MinValue],[MaxValue],[Age_gender_cat])
  values (16,'0.0','0.5','AdultMale'),(16,'0.0','0.5','AdultFemale'),(16,'0.0','0.5','ChildMale'),(16,'0.0','0.5','ChildFemale'),
 (17,'0.0','0.30.0','AdultMale'),(17,'0.0','0.30.0','AdultFemale'),(17,'0.0','0.30.0','ChildMale'),(17,'0.0','0.30.0','ChildFemale'),
(18,'0.0','0.4','AdultMale'),(18,'0.0','0.4','AdultFemale'),(18,'0.0','0.4','ChildMale'),(18,'0.0','0.5','ChildFemale'),
(19,'0.0','15.0','AdultMale'),(19,'0.0','15.0','AdultFemale'),(19,'0.0','15.0','ChildMale'),(19,'0.0','15.0','Childale'),
(20,'0.0','0.6','AdultMale'),(20,'0.0','0.6','AdultFemale'),(20,'0.0','0.6','ChildMale'),(20,'0.0','0.6','ChildFemale'),
(21,'0.0','5.0','AdultMale'),(21,'0.0','5.0','AdultFemale'),(21,'0.0','5.0','ChildMale'),(21,'0.0','5.0','ChildFemale'),
(22,'0.0','9.0','AdultMale'),(22,'0.0','9.0','AdultFemale'),(22,'0.0','9.0','ChildMale'),(22,'0.0','9.0','ChildFemale'),
(23,'0.0','11.0','AdultMale'),(23,'0.0','11.0','AdultFemale'),(23,'0.0','11.0','ChildMale'),(23,'0.0','11.0','ChildFemale'),
(24,'0.0','10.0','AdultMale'),(24,'0.0','10.0','AdultFemale'),(24,'0.0','10.0','ChildMale'),(24,'0.0','10.0','ChildFemale'),
(25,'0.0','10.0','AdultMale'),(25,'0.0','10.0','AdultFemale'),(25,'0.0','10.0','ChildMale'),(25,'0.0','10.0','ChildMFemale');




--///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


  insert into [dbo].[Test_Normal_Value] ([SubTestID],[MinValue],[MaxValue],[Age_gender_cat])
  values (26,'1.7','12','AdultMale'),(26,'1.7','12','AdultFemale'),(26,'1.7','12','ChildMale'),(26,'1.7','12','ChildFemale'),
 (27,'1.1','7','AdultMale'),(27,'1.1','7','AdultFemale'),(27,'1.1','7','ChildMale'),(27,'1.1','7','ChildFemale'),
(28,'0.0','0.0','AdultMale'),(28,'0.0','0.0','AdultFemale'),(28,'0.0','0.0','ChildMale'),(28,'0.0','0.0','ChildFemale'),
(29,'up to 52','up to 52','AdultMale'),(29,'up to 52','up to 52','AdultFemale'),(29,'up to 52','up to 52','ChildMale'),(29,'up to 52','up to 52','Childale'),
(30,'up to 20','up to 20','AdultMale'),(30,'up to 20','up to 20','AdultFemale'),(30,'up to 20','up to 20','ChildMale'),(30,'up to 20','up to 20','ChildFemale'),
(31,'3','10.6','AdultMale'),(31,'3','10.6','AdultFemale'),(31,'3','10.6','ChildMale'),(31,'3','10.6','ChildFemale'),
(32,'8.6','54.6','AdultMale'),(32,'8.6','54.6','AdultFemale'),(32,'8.6','54.6','ChildMale'),(32,'8.6','54.6','ChildFemale'),
(33,'80','560','AdultMale'),(33,'80','560','AdultFemale'),(33,'80','560','ChildMale'),(33,'80','560','ChildFemale'),
(34,'0.0','0.0','AdultMale'),(34,'0.0','0.0','AdultFemale'),(34,'0.0','0.0','ChildMale'),(34,'0.0','0.0','ChildFemale'),
(35,'0.3','6','AdultMale'),(35,'0.3','6','AdultFemale'),(35,'0.3','6','ChildMale'),(35,'0.3','6','ChildMFemale');
----------
-- insert user

insert into [User] 
values('Mohamed','El youm Elwaheid','EYE@2024.lab','admin'),
insert into [User]
values
('User1','El youm Elwaheid','MMHHMAAMS@102$','user')