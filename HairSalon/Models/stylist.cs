using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace Salon.Models
{
  public class Stylist
  {
    private string _name;
    private int _id;

    public Stylist(string name, int id = 0)
    {
      _name = name;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        return this.GetId().Equals(newStylist.GetId());
      }
    }

    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (name) VALUES (@name);";
      cmd.Parameters.Add(new MySqlParameter("@name", _name));

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        Stylist newStylist = new Stylist(stylistName, stylistId);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Stylist Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int stylistId = 0;
      string stylistName = "";

      while (rdr.Read())
      {
        stylistId = rdr.GetInt32(0);
        stylistName= rdr.GetString(1);
      }
      Stylist foundStylist = new Stylist(stylistName,stylistId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundStylist;
    }

    public static List<Client> GetClientsByStylist(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT clients.* FROM stylists
      JOIN stylists_clients ON (stylists.id = stylists_clients.stylist_id)
      JOIN clients ON (stylists_clients.client_id = clients.id)
      WHERE stylists.id = @StylistId;";

      MySqlParameter stylistIdParameter = new MySqlParameter();
      stylistIdParameter.ParameterName = "@StylistId";
      stylistIdParameter.Value = id;
      cmd.Parameters.Add(stylistIdParameter);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Client> clients = new List<Client>{};

      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);

        Client newClient = new Client(stylistName, stylistId);
        clients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return clients;
    }

    public static List<Specialty> GetSpecialtyByStylist(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT specialties.* FROM stylists
      JOIN stylists_specialties ON (stylists.id = stylists_specialties.stylist_id)
      JOIN specialties ON (stylists_specialties.specialty_id = specialties.id)
      WHERE stylists.id = @StylistId;";

      MySqlParameter specialtyIdParameter = new MySqlParameter();
      specialtyIdParameter.ParameterName = "@StylistId";
      specialtyIdParameter.Value = id;
      cmd.Parameters.Add(specialtyIdParameter);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Specialty> specialties = new List<Specialty>{};

      while(rdr.Read())
      {
        int specialtyId = rdr.GetInt32(0);
        string specialtyName = rdr.GetString(1);

        Specialty newSpecialty = new Specialty(specialtyName, specialtyId);
        specialties.Add(newSpecialty);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return specialties;
    }

    public static void AddNewClient(int stylistId, int clientId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists_clients (stylist_id, client_id) VALUES (@StylistId, @ClientId);";

      MySqlParameter stylists_id = new MySqlParameter();
      stylists_id.ParameterName = "@StylistId";
      stylists_id.Value = stylistId;
      cmd.Parameters.Add(stylists_id);

      MySqlParameter client_id = new MySqlParameter();
      client_id.ParameterName = "@ClientId";
      client_id.Value = clientId;
      cmd.Parameters.Add(client_id);


      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }








  }
}
