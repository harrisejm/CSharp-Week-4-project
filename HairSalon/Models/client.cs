using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Salon.Models

{
  public class Client
  {
    private string _name;
    private int _id;
    private int _stylistId;
    private string _stylistName;

    public Client(string name, int stylistId, string stylistName, int id = 0)
    {
      _name = name;
      _id = id;
      _stylistId = stylistId;
      _stylistName = stylistName;
    }
    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public int GetStylistId()
    {
      return _stylistId;
    }
    public string GetStylistName()
    {
      return _stylistName;
    }

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.GetId() == newClient.GetId());
        bool nameEquality = (this.GetName() == newClient.GetName());
        bool stylistEquality = (this.GetStylistId() == newClient.GetStylistId());
        bool stylistNameEquality = (this.GetStylistName() == newClient.GetStylistName());
        return (idEquality && nameEquality && stylistEquality && stylistNameEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (name, stylist_id, stylist_Name) VALUES (@name, @SalonStylist_id, @stylistName);";
      cmd.Parameters.Add(new MySqlParameter("@name", _name));
      cmd.Parameters.Add(new MySqlParameter("@SalonStylist_id", _stylistId));
      cmd.Parameters.Add(new MySqlParameter("@stylistName", _stylistName));

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        int stylistId = rdr.GetInt32(2);
        string stylistName = rdr.GetString(3);

        Client newClient = new Client(clientName, stylistId, stylistName, clientId);

        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Client> Find(int id)
    {
      List<Client> findClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = " + id + ";";

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        int stylist_Id = rdr.GetInt32(2);
        string stylistName = rdr.GetString(3);

        Client foundClient = new Client(clientName, stylist_Id, stylistName, clientId);
        findClients.Add(foundClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return findClients;
    }

    public static Client FindClient(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;


      int clientId = 0;
      string clientName = "";
      int stylist_Id = 0;
      string stylistName = "";

      while (rdr.Read())
      {
        clientId = rdr.GetInt32(0);
        clientName = rdr.GetString(1);
        stylist_Id = rdr.GetInt32(2);
        stylistName = rdr.GetString(3);
      }
      Client foundClient = new Client(clientName, stylist_Id, stylistName, clientId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundClient;
    }

    public void Delete()
{
  MySqlConnection conn = DB.Connection();
  conn.Open();

  var cmd = conn.CreateCommand() as MySqlCommand;
  cmd.CommandText = @"DELETE FROM clients WHERE id = @thisId;";

  MySqlParameter searchId = new MySqlParameter();
  searchId.ParameterName = "@thisId";
  searchId.Value = _id;
  cmd.Parameters.Add(searchId);



  cmd.ExecuteNonQuery();

  conn.Close();
  if (conn != null)
  {
    conn.Dispose();
  }
}

  }
}
