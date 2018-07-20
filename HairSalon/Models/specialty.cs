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


  }

}
