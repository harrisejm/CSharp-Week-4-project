using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Salon.Models

{
  public class Client
  {
    private string _name;
    private int _id;
  //  private int _stylistId;
  //  private string _stylistName;

    public Client(string name, int id = 0)
    {
      _name = name;
      _id = id;
      // _stylistId = stylistId;
      // _stylistName = stylistName;
    }
    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    // public int GetStylistId()
    // {
    //   return _stylistId;
    // }
    // public string GetStylistName()
    // {
    //   return _stylistName;
    // }

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

        return (idEquality && nameEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (name) VALUES (@name);";
      cmd.Parameters.Add(new MySqlParameter("@name", _name));
    //  cmd.Parameters.Add(new MySqlParameter("@SalonStylist_id", _stylistId));
    //  cmd.Parameters.Add(new MySqlParameter("@stylistName", _stylistName));

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

        Client newClient = new Client(clientName, clientId);

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

    // public static List<Client> Find(int id)
    // {
    //   List<Client> findClients = new List<Client> {};
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = " + id + ";";
    //
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //
    //   while (rdr.Read())
    //   {
    //     int clientId = rdr.GetInt32(0);
    //     string clientName = rdr.GetString(1);
    //
    //     Client foundClient = new Client(clientName, clientId);
    //     findClients.Add(foundClient);
    //   }
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return findClients;
    // }

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

      while (rdr.Read())
      {
        clientId = rdr.GetInt32(0);
        clientName = rdr.GetString(1);
    //    stylist_Id = rdr.GetInt32(2);
    //    stylistName = rdr.GetString(3);
      }
      Client foundClient = new Client(clientName, clientId);

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


public void DeleteFromJoin()
{
MySqlConnection conn = DB.Connection();
conn.Open();

var cmd = conn.CreateCommand() as MySqlCommand;
cmd.CommandText = @"DELETE FROM stylists_clients WHERE client_id = @thisId;";

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

public static List<Stylist> GetStylistByClient(int id)
{
  MySqlConnection conn = DB.Connection();
  conn.Open();
  MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
  cmd.CommandText = @"SELECT stylists.* FROM clients
  JOIN stylists_clients ON (clients.id = stylists_clients.client_id)
  JOIN stylists ON (stylists_clients.stylist_id = stylists.id)
  WHERE clients.id = @ClientId;";

  MySqlParameter clientIdParameter = new MySqlParameter();
  clientIdParameter.ParameterName = "@ClientId";
  clientIdParameter.Value = id;
  cmd.Parameters.Add(clientIdParameter);

  MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
  List<Stylist> stylists = new List<Stylist>{};

  while(rdr.Read())
  {
    int clientId = rdr.GetInt32(0);
    string clientName = rdr.GetString(1);

    Stylist newStylist = new Stylist(clientName, clientId);
    stylists.Add(newStylist);
  }
  conn.Close();
  if (conn != null)
  {
    conn.Dispose();
  }
  return stylists;
}


//editsytlist name
public void Edit(int id, string newName)
{
  MySqlConnection conn = DB.Connection();
  conn.Open();
  var cmd = conn.CreateCommand() as MySqlCommand;
  cmd.CommandText = @"UPDATE clients SET name = @name WHERE id = @clientId;";

  MySqlParameter clientId = new MySqlParameter();
  clientId.ParameterName = "@clientId";
  clientId.Value = id;
  cmd.Parameters.Add(clientId);

  MySqlParameter changeName = new MySqlParameter();
  changeName.ParameterName = "@name";
  changeName.Value = newName;
  cmd.Parameters.Add(changeName);


  cmd.ExecuteNonQuery();

_name = newName;
_id = id;

  conn.Close();
  if (conn != null)
  {
    conn.Dispose();
  }
}



public static void DeleteAllStylistClient()
{
  MySqlConnection conn = DB.Connection();
  conn.Open();
  var cmd = conn.CreateCommand() as MySqlCommand;
  cmd.CommandText = @"DELETE FROM stylists_clients;";
  cmd.ExecuteNonQuery();
  conn.Close();
  if (conn != null)
  {
    conn.Dispose();
  }
}

  }
}
