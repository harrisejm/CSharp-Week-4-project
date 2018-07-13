using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace Salon.Models
  {
    public class Stylist
    {
      private string _name;
      private string _gender;

      public Stylist(string name, int id = 0)
      {
        _name = name;

      }
      public string GetName()
      {
        return _name;
      }
      // public string GetGender()
      // {
      //   return _gender;
      // }

      public void Save()
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO stylist (name) VALUES (@name);";

          MySqlParameter description = new MySqlParameter("@name", _name);
          //description.ParameterName = "@name";
        //  description.Value = this._name;
          cmd.Parameters.Add(name);

          cmd.ExecuteNonQuery();
          _id = (int) cmd.LastInsertedId;
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }

      }


      public static List<stylist> GetAll()
    {
      List<stylist> allDog = new List<stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {

        int stylistId = rdr.GetInt32(0);
        string stylistDescription = rdr.GetString(1);


        Stylist newStylist = new Stylist(stylistId, stylistDescription);

        allDog.Add(newDog);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allDog;
    }



    }
  }
