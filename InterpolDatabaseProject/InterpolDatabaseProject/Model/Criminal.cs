﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace InterpolDatabaseProject.Model
{
    [Serializable]
    public class Сriminal : ISerializable
    {
        #region Properies
        private static int _lastId = -1;
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Forename { get; set; }
        public string CodeName { get; set; }
        public int Height { get; set; }
        public EyeColor ColorOfEye { get; set; }
        public HairColor ColorOfHair { get; set; }
        public SexOptions Sex { get; set; }
        public string SpecialSigns { get; set; }
        public Country Citizenship { get; set; }
        public Country BirthCountry { get; set; }
        public string Birthplace { get; set; }
        public DateTime? Birthdate { get; set; }
        public Country LastLivingCountry { get; set; }
        public string LastLivingPlace { get; set; }
        public List<Language> Languages { get; set; }
        public CriminalStateOptions State { get; set; }
        public CriminalGroup CriminalGroupMembership { get; set; }
        public string PhotoFileName { get; set; }
        public List<Crime> Charges { get; set; }
        public int Age => (Birthdate==null)?0:DateTime.Now.Year - Birthdate.Value.Year;
        #endregion

        public void SetCriminalGroup(CriminalGroup criminalGroup) {
            if (CriminalGroupMembership != null) throw new Exception("CriminalGroup is already set");
            if (!criminalGroup.Members.ContainsKey(Id))
                criminalGroup.AddMember(this);
            else CriminalGroupMembership = criminalGroup;
        }
        public void UnsetCriminalGroup()
        {
            if(CriminalGroupMembership==null) throw new NullReferenceException("CriminalGroup is already unset");
            if (CriminalGroupMembership.Members.ContainsKey(Id))
                CriminalGroupMembership.RemoveMember(Id);
            else CriminalGroupMembership = null;
        }
        
        public Сriminal(SerializationInfo info, StreamingContext context)
        {
            _lastId = info.GetInt32("static._lastId");
            Id = info.GetInt32("Id");
            Lastname = info.GetString("Lastname");
            CodeName = info.GetString("CodeName");
            Forename = info.GetString("Forename");
            Height = info.GetInt32("Height");
            ColorOfEye = (EyeColor)info.GetValue("ColorOfEye", typeof(EyeColor));
            ColorOfHair = (HairColor) info.GetValue("ColorOfHair", typeof(HairColor));
            Sex = (SexOptions)info.GetValue("Sex", typeof(SexOptions));
            SpecialSigns = (string) info.GetValue("SpecialSigns", typeof(string));
            Citizenship = (Country) info.GetValue("Citizenship", typeof(Country));
            BirthCountry = (Country)info.GetValue("BirthCountry", typeof(Country));
            Birthplace = info.GetString("Birthplace");
            Birthdate = (DateTime?)info.GetValue("Birthdate", typeof(DateTime?));
            LastLivingCountry = (Country)info.GetValue("LastLivingCountry", typeof(Country));
            LastLivingPlace = info.GetString("LastLivingPlace");
            Languages = (List<Language>) info.GetValue("Languages", typeof(List<Language>));
            State = (CriminalStateOptions) info.GetValue("State", typeof(CriminalStateOptions));
            CriminalGroupMembership = (CriminalGroup)info.GetValue("CriminalGroupMembership", typeof(CriminalGroup));
            PhotoFileName = info.GetString("PhotoFileName");
            Charges = (List<Crime>)info.GetValue("Charges", typeof(List<Crime>));
        }
        public Сriminal(string lastname, string forename, string codeName, int height, 
            EyeColor colorOfEye, HairColor colorOfHair, SexOptions sex, string specialSigns,
            Country citizenship, Country birthCountry, string birthplace, DateTime? birthdate, 
            Country lastLivingCountry, string lastLivingPlace, List<Language> languages, CriminalStateOptions state, string photoFileName, 
            CriminalGroup criminalGroup, List<Crime> charges)
        {
            Id = ++_lastId;
            Lastname = lastname;
            Forename = forename;
            CodeName = codeName;
            Height = height;
            ColorOfEye = colorOfEye;
            ColorOfHair = colorOfHair;
            Sex = sex;
            SpecialSigns = specialSigns;
            Citizenship = citizenship;
            BirthCountry = birthCountry;
            Birthplace = birthplace;
            Birthdate = birthdate;
            LastLivingCountry = lastLivingCountry;
            LastLivingPlace = lastLivingPlace;
            Languages = languages;
            State = state;
            CriminalGroupMembership = criminalGroup;
            PhotoFileName = photoFileName;
            Charges = charges;
        }

        #region Enums
        public enum SexOptions
        {
            Male,
            Female,
            Unknown
        }
        public enum CriminalStateOptions
        {
            Wanted,
            Busted,
            Wasted
        }
        #endregion

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("static._lastId", _lastId, typeof(int));
            info.AddValue("Id", Id, typeof(int));

            info.AddValue("Lastname", Lastname, typeof(string));
            info.AddValue("CodeName", CodeName, typeof(string));
            info.AddValue("Forename", Forename, typeof(string));
            info.AddValue("Height", Height, typeof(int));
            info.AddValue("ColorOfEye", ColorOfEye, typeof(EyeColor));
            info.AddValue("ColorOfHair", ColorOfHair, typeof(HairColor));
            info.AddValue("Sex", Sex, typeof(SexOptions));
            info.AddValue("SpecialSigns", SpecialSigns, typeof(List<string>));
            info.AddValue("Citizenship", Citizenship, typeof(Country));
            info.AddValue("BirthCountry", BirthCountry, typeof(Country));
            info.AddValue("Birthplace", Birthplace, typeof(string));
            info.AddValue("Birthdate", Birthdate, typeof(DateTime?));
            info.AddValue("LastLivingCountry", LastLivingCountry, typeof(Country));
            info.AddValue("LastLivingPlace", LastLivingPlace, typeof(string));
            info.AddValue("Languages", Languages, typeof(List<Language>));
            info.AddValue("State", State, typeof(CriminalStateOptions));
            info.AddValue("CriminalGroupMembership", CriminalGroupMembership, typeof(CriminalGroup));
            info.AddValue("PhotoFileName", PhotoFileName, typeof(string));
            info.AddValue("Charges", Charges, typeof(List<Crime>));
        }
    }
}
