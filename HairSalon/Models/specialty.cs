using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Salon.Models

{
  public class Specialty
  {
  private int _id;
  private string _name;

  public Specialty(string name, int id = 0)
  {
    _name = name;
    _id = id;

  }

  public string GetSpecialtyName()
  {
    return _name;
  }

  public int GetSpecialtyId()
  {
    return _id;
  }

  public override bool Equals(System.Object specialty)
  {
    if (!(specialty is Specialty))
    {
      return false;
    }
    else
    {
      Specialty newspecialty = (Specialty) specialty;
      bool idEquality = (this.GetSpecialtyId() == newspecialty.GetSpecialtyId());
      bool nameEquality = (this.GetSpecialtyName() == newspecialty.GetSpecialtyName());
    //  bool stylistEquality = (this.GetStylistId() == newClient.GetStylistId());
  //    bool stylistNameEquality = (this.GetStylistName() == newClient.GetStylistName());
      return (idEquality && nameEquality);
    }
  }

  public static List<Specialty> GetAll()
  {
    List<Specialty> allSpecialties = new List<Specialty> {};
    MySqlConnection conn = DB.Connection();
    conn.Open();
    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM specialties;";
    MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    while(rdr.Read())
    {
      int specialtyId = rdr.GetInt32(0);
      string specialtyName = rdr.GetString(1);

      Specialty newSpecialty = new Specialty(specialtyName, specialtyId);

      allSpecialties.Add(newSpecialty);
    }
    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
    return allSpecialties;
}

public void Save()
{
  MySqlConnection conn = DB.Connection();
  conn.Open();

  var cmd = conn.CreateCommand() as MySqlCommand;
  cmd.CommandText = @"INSERT INTO specialties (specialty) VALUES (@specialty);";
  cmd.Parameters.Add(new MySqlParameter("@specialty", _name));

  cmd.ExecuteNonQuery();
  _id = (int) cmd.LastInsertedId;
  conn.Close();
  if (conn != null)
  {
    conn.Dispose();
  }
}

public static Specialty FindSpeciality(int id)
{
  MySqlConnection conn = DB.Connection();
  conn.Open();
  var cmd = conn.CreateCommand() as MySqlCommand;
  cmd.CommandText = @"SELECT * FROM specialties WHERE id = @thisId;";
  MySqlParameter thisId = new MySqlParameter();
  thisId.ParameterName = "@thisId";
  thisId.Value = id;
  cmd.Parameters.Add(thisId);
  var rdr = cmd.ExecuteReader() as MySqlDataReader;

  int specialtyId = 0;
  string specialtyName = "";


  while (rdr.Read())
  {
    specialtyId = rdr.GetInt32(0);
    specialtyId = rdr.GetInt32(0);

  }
  Specialty foundSpecialty = new Specialty(specialtyName, specialtyId);

  conn.Close();
  if (conn != null)
  {
    conn.Dispose();
  }
  return foundSpecialty;
}


public static List<Stylist> GetStylistBySpecialty(int id)
{
  MySqlConnection conn = DB.Connection();
  conn.Open();
  MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
  cmd.CommandText = @"SELECT stylists.* FROM specialties
  JOIN stylists_specialties ON (specialties.id = stylists_specialties.specialty_id)
  JOIN stylists ON (stylists_specialties.stylist_id = stylists.id)
  WHERE specialties.id = @SpecialtiesId;";

  MySqlParameter stylistIdParameter = new MySqlParameter();
  stylistIdParameter.ParameterName = "@SpecialtiesId";
  stylistIdParameter.Value = id;
  cmd.Parameters.Add(stylistIdParameter);

  MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
  List<Stylist> stylists = new List<Stylist>{};

  while(rdr.Read())
  {
    int stylistId = rdr.GetInt32(0);
    string stylistName = rdr.GetString(1);

    Stylist newStylist = new Stylist(stylistName, stylistId);
    stylists.Add(newStylist);
  }
  conn.Close();
  if (conn != null)
  {
    conn.Dispose();
  }
  return stylists;
}




  }

}
