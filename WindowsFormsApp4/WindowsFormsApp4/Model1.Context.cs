﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp4
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class laboratorySystemEntities1 : DbContext
    {
        public laboratorySystemEntities1()
            : base("name=laboratorySystemEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Lab_Info> Lab_Info { get; set; }
        public virtual DbSet<Main_Test_Group> Main_Test_Group { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Patient_Test> Patient_Test { get; set; }
        public virtual DbSet<patientResultValue> patientResultValues { get; set; }
        public virtual DbSet<Sub_Test> Sub_Test { get; set; }
        public virtual DbSet<Test_Normal_Value> Test_Normal_Value { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        [DbFunction("laboratorySystemEntities1", "fn_GetAllMainGroupNames")]
        public virtual IQueryable<fn_GetAllMainGroupNames_Result> fn_GetAllMainGroupNames()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_GetAllMainGroupNames_Result>("[laboratorySystemEntities1].[fn_GetAllMainGroupNames]()");
        }
    
        [DbFunction("laboratorySystemEntities1", "fn_GetAllSubTestNames")]
        public virtual IQueryable<fn_GetAllSubTestNames_Result> fn_GetAllSubTestNames(string groupName)
        {
            var groupNameParameter = groupName != null ?
                new ObjectParameter("GroupName", groupName) :
                new ObjectParameter("GroupName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_GetAllSubTestNames_Result>("[laboratorySystemEntities1].[fn_GetAllSubTestNames](@GroupName)", groupNameParameter);
        }
    
        [DbFunction("laboratorySystemEntities1", "fn_GetNormalValue")]
        public virtual IQueryable<fn_GetNormalValue_Result> fn_GetNormalValue(string testName, string age_gender_cat)
        {
            var testNameParameter = testName != null ?
                new ObjectParameter("TestName", testName) :
                new ObjectParameter("TestName", typeof(string));
    
            var age_gender_catParameter = age_gender_cat != null ?
                new ObjectParameter("Age_gender_cat", age_gender_cat) :
                new ObjectParameter("Age_gender_cat", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_GetNormalValue_Result>("[laboratorySystemEntities1].[fn_GetNormalValue](@TestName, @Age_gender_cat)", testNameParameter, age_gender_catParameter);
        }
    
        [DbFunction("laboratorySystemEntities1", "fn_GetNormalValueForTest")]
        public virtual IQueryable<fn_GetNormalValueForTest_Result> fn_GetNormalValueForTest(string testName, Nullable<int> age, string gender)
        {
            var testNameParameter = testName != null ?
                new ObjectParameter("TestName", testName) :
                new ObjectParameter("TestName", typeof(string));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("Age", age) :
                new ObjectParameter("Age", typeof(int));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_GetNormalValueForTest_Result>("[laboratorySystemEntities1].[fn_GetNormalValueForTest](@TestName, @Age, @Gender)", testNameParameter, ageParameter, genderParameter);
        }
    
        public virtual ObjectResult<string> get_AllNameMAinGroup()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("get_AllNameMAinGroup");
        }
    
        public virtual ObjectResult<string> get_AllNameSubTests(string groupName)
        {
            var groupNameParameter = groupName != null ?
                new ObjectParameter("GroupName", groupName) :
                new ObjectParameter("GroupName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("get_AllNameSubTests", groupNameParameter);
        }
    
        public virtual ObjectResult<get_normalvalue_Result> get_normalvalue(string testName, string age_gender_cat)
        {
            var testNameParameter = testName != null ?
                new ObjectParameter("TestName", testName) :
                new ObjectParameter("TestName", typeof(string));
    
            var age_gender_catParameter = age_gender_cat != null ?
                new ObjectParameter("Age_gender_cat", age_gender_cat) :
                new ObjectParameter("Age_gender_cat", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_normalvalue_Result>("get_normalvalue", testNameParameter, age_gender_catParameter);
        }
    }
}