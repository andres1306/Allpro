using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Allpro.Models;
using Dapper;
namespace Allpro.Datos
{
    public class Logica
    {
        Conexion cn = new Conexion();
        Client CL = new Client();
        bool rpta = false, isAdmin = false, uservalideter = false;

        string NameUser;
        string[] ClientID = new string[1];

        public bool NewProperty(Propertys propertys)
        {
            try
            {
                using (var conexion = new SqlConnection(cn.GetCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("NewProperty", conexion);
                    cmd.Parameters.AddWithValue("ClientID", ClientID);
                    cmd.Parameters.AddWithValue("Address", propertys.Address);
                    cmd.Parameters.AddWithValue("Location", propertys.Location);
                    cmd.Parameters.AddWithValue("Area", propertys.Area);
                    cmd.Parameters.AddWithValue("Num_rooms", propertys.Num_rooms);
                    cmd.Parameters.AddWithValue("Num_bathrooms", propertys.Num_bathrooms);
                    cmd.Parameters.AddWithValue("Parking", propertys.Parking);
                    cmd.Parameters.AddWithValue("Price", propertys.Price);
                    cmd.Parameters.AddWithValue("Stratum", propertys.Stratum);
                    cmd.Parameters.AddWithValue("Image", propertys.Image);
                    cmd.Parameters.AddWithValue("TypeHouseID", propertys.TypeHouseID);
                    cmd.Parameters.AddWithValue("TypePropertyID", propertys.TypePropertyID);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    rpta = true;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return rpta;
        }
        public MasterAllpro LoginUsers(string username, string password)
        { var  RolId="" ;
            try
            {
                using (var conexion = new SqlConnection(cn.GetCadenaSql()))
                {
                    conexion.Open();
                    string query = "Select * from Client where UserName=@Username and UserPassword=@Clave ";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Clave", password);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            RolId = reader["RoleID"].ToString();
                            NameUser = reader["NameClient"].ToString();
                            ClientID[1] = reader["ClientID"].ToString();
                        }
                        if (RolId == "1")
                        {
                            uservalideter = true;
                            isAdmin = true;
                        }

                    }

                }
            }
            catch (Exception e)
            {
                _ = e.Message;
                rpta = false;
            }
            return new MasterAllpro
            {
                UserValideter = uservalideter,
                IsAdmin = isAdmin
            };
        }
        public bool NewUser(Client client)
        {
            try
            {
                using (var conexion = new SqlConnection(cn.GetCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("NewClient", conexion);
                    cmd.Parameters.AddWithValue("NameClient", client.NameClient);
                    cmd.Parameters.AddWithValue("UserName", client.UserName);
                    cmd.Parameters.AddWithValue("UserPassword", client.UserPassword);
                    cmd.Parameters.AddWithValue("PhoneClient", client.PhoneClient);
                    cmd.Parameters.AddWithValue("DocumentClient", client.DocumentClient);
                    cmd.Parameters.AddWithValue("Email", client.Email);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool CloseSeccion()
        {
            uservalideter = false;
            return uservalideter;
        }
        public bool RentHouse(HouseRents houseRents)
        {
            try
            {
                using (var conexion = new SqlConnection(cn.GetCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("RentHouse", conexion);
                    cmd.Parameters.AddWithValue("clientID", houseRents.clientID);
                    cmd.Parameters.AddWithValue("PropertyID", houseRents.PropertyID);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                return rpta;
            }
            return rpta;
        }
        public List<Propertys> AllPropertys()
        {
            var List = new List<Propertys>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.GetCadenaSql()))
            {
                conexion.Open();
                string query = "Select * from Client";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        List.Add(new Propertys()
                        {
                            PropertyID = Convert.ToInt32(dr["PropertyID"]),
                            Address = Convert.ToString(dr["Address"]),
                            Location = dr["Location"].ToString(),
                            Area = Convert.ToString(dr["Area"]),
                            Num_rooms = Convert.ToInt32(dr["Num_rooms"]),
                            Num_bathrooms = Convert.ToInt32(dr["Num_bathrooms"]),
                            Parking = (byte)Convert.ToInt32(dr["Parking"]),
                            Price = Convert.ToInt32(dr["Price"]),
                            Stratum = Convert.ToInt32(dr["Stratum"]),
                            Image = Convert.ToString(dr["Image"]),
                            ClientID = Convert.ToInt32(dr["ClientID"]),
                            TypeHouseID = Convert.ToInt32(dr["TypeHouseID"]),
                            TypePropertyID = Convert.ToInt32(dr["TypePropertyID"]),
                            Condition = Convert.ToByte(dr["Condition"])
                        });
                    }
                }
                return List;
            }
        }
    }
}
