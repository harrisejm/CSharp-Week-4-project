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
    //private string _gender;

    public Client(string name, int stylistId, int id = 0)
    {
      _name = name;
      _id = id;
      _stylistId = stylistId;
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
    // public int SetStylistId(int stylistId)
    // {
    //  _stylistId = stylistId;
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
            bool stylistEquality = (this.GetStylistId() == newClient.GetStylistId());
            return (idEquality && nameEquality && stylistEquality);
          }
        }


    // public override bool Equals(System.Object otherClient)
    // {
    //     if (!(otherClient is Client))
    //     {
    //         return false;
    //     }
    //     else
    //     {
    //         Client newClient = (Client) otherClient;
    //         return this.GetId().Equals(newClient.GetId());
    //     }
    // }
    //
    //
    // public override int GetHashCode()
    // {
    //     return this.GetId().GetHashCode();
    // }

    public void Save()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO clients (name, stylist_id) VALUES (@name, @SalonStylist_id);";
       cmd.Parameters.Add(new MySqlParameter("@name", _name));
       cmd.Parameters.Add(new MySqlParameter("@SalonStylist_id", _stylistId));

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


      Client newClient = new Client(clientName, stylistId, clientId);

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
      //var cmd = conn.CreateCommand() as MySqlCommand;

        cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = " + id + ";"; //@thisStylistId;";
      //  MySqlParameter thisStylistId = new MySqlParameter();
        // thisStylistId.ParameterName = "@thisStylistId";
        // thisStylistId.Value = id;
      //  cmd.Parameters.Add(thisStylistId);

        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        // int stylist_Id = 0;
        // int clientId = 0;
        // string clientName = "";

        while (rdr.Read())
        {
          int clientId = rdr.GetInt32(0);
          string clientName = rdr.GetString(1);
          int stylist_Id = rdr.GetInt32(2);
          Client foundClient = new Client(clientName, stylist_Id, clientId);
          findClients.Add(foundClient);
        }


      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return findClients;
    }






}
}
