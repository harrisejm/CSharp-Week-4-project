using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Salon.Models

{
  public class specialty
  {
  private int _id;
  private string _name;

  public specialty(string name, int id = 0)
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
    if (!(specialty is Client))
    {
      return false;
    }
    else
    {
      Client newspecialty = (Client) specialty;
      bool idEquality = (this.GetSpecialtyId() == specialty.GetSpecialtyId());
      bool nameEquality = (this.GetSpecialtyName() == specialty.GetSpecialtyName());
    //  bool stylistEquality = (this.GetStylistId() == newClient.GetStylistId());
  //    bool stylistNameEquality = (this.GetStylistName() == newClient.GetStylistName());
      return (idEquality && nameEquality);
    }
  }





  }

}
