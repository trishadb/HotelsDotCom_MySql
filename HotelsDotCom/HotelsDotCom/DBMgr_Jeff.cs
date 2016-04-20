using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsDotCom
{
    public class DBMgr_Jeff
    {
        private MySqlConnection conn;
        private MySqlCommand cmd = null;
        private MySqlDataReader rdr = null;

        private static DBMgr_Jeff dbInstance;
        private String connString = System.Configuration.ConfigurationManager.ConnectionStrings["hotel_connString"].ToString();

        private String sqlStr = "";

        private DBMgr_Jeff()
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            Open();
        }

        private void Open()
        {
            conn.Open();
        }
        private void Close()
        {
            conn.Close();
        }

        //singleton pattern 
        //a bad practice to connect to database
        public static DBMgr_Jeff getInstance()
        {
            if (dbInstance == null)
            {
                dbInstance = new DBMgr_Jeff();
            }

            return dbInstance;
        }

        public int createSpecialRequirements()
        {
            int result = -1;
            try
            {
                sqlStr = "create table special_requirements (res_id int(5), description varchar(50), price decimal(5,2))";
                cmd = new MySqlCommand(sqlStr, conn);
                result = cmd.ExecuteNonQuery(); //return the number of rows affected
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int insertSpecialRequirements(int res_id, String des, decimal price)
        {
            int result = -1;
            try
            {
                sqlStr = " insert into special_requirements values( " + res_id + ", '" + des + "', " + price + ")";
                cmd = new MySqlCommand(sqlStr, conn);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        public List<HotelRoomQuantity> getSpecialRequirements()
        {
            List<HotelRoomQuantity> hotels = new List<HotelRoomQuantity>();
            try
            {
                sqlStr = "select * from special_requirements";
                cmd = new MySqlCommand(sqlStr, conn);
                rdr = cmd.ExecuteReader();

                HotelRoomQuantity hrq;
                while (rdr.Read())
                {
                    hrq = new HotelRoomQuantity();
                    hrq.H_name = rdr["res_id"].ToString();
                    hrq.R_type = rdr["description"].ToString();
                    hrq.Quantity = Convert.ToInt32(rdr["price"]);
                    hotels.Add(hrq);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return hotels;
        }

        public List<HotelRoomQuantity> descReservationTable()
        {
            List<HotelRoomQuantity> hotels = new List<HotelRoomQuantity>();
            try
            {
                sqlStr = "desc reservation";
                cmd = new MySqlCommand(sqlStr, conn);
                rdr = cmd.ExecuteReader();

                HotelRoomQuantity hrq;
                while (rdr.Read())
                {
                    hrq = new HotelRoomQuantity();
                    hrq.H_name = rdr["field"].ToString();
                    hrq.R_type = rdr["type"].ToString();
                    hrq.Quantity = 0;
                    hotels.Add(hrq);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return hotels;
        }

        /*
res_id / int(5) / 0
c_id / int(4) / 0
h_name / varchar(30) / 0
r_type / varchar(20) / 0
start_date / date / 0
end_date / date / 0
quantity / int(1) / 0
        */
        public List<HotelRoomQuantity> getHotelCapacityByDes(String desti)
        {
            List<HotelRoomQuantity> hotels = new List<HotelRoomQuantity>();
            try
            {
                sqlStr = "select cap.h_name, cap.r_type, count(r_id) as r_cap "
                    + "from room cap "
                    + "join hotel on hotel.h_name = cap.H_NAME "
                    + "where city = '" + desti + "' "
                    + "group by cap.H_NAME, cap.r_type "
                    + "order by cap.h_name";
                cmd = new MySqlCommand(sqlStr, conn);
                rdr = cmd.ExecuteReader();
                HotelRoomQuantity hrq;
                while (rdr.Read())
                {
                    hrq = new HotelRoomQuantity();
                    hrq.H_name = rdr["h_name"].ToString();
                    hrq.R_type = rdr["r_type"].ToString();
                    hrq.Quantity = Convert.ToInt32(rdr["r_cap"]);
                    hotels.Add(hrq);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return hotels;
        }


        public int insertReservation(/*int c_id, String h_name,
            String r_type, String starting, String ending, int quantity*/)
        {
            int result = -1;
            try
            {
                /*
                sqlStr = "insert into reservation (c_id, h_name, r_type, start_date, end_date, quantity) values "
                        + "(" + c_id + ", '" + h_name + "', '" + r_type + "', "
                        + "str_to_date('" + starting + "','%Y-%m-%d'), "
                        + "str_to_date('" + ending + "','%Y-%m-%d'), " + quantity + ")";
                */
                sqlStr = " insert into reservation (c_id, h_name, r_type, start_date, end_date, quantity) values(8001, 'Hilton', 'King', '2016/4/23', '2016/5/12', 1 ) ";
                cmd = new MySqlCommand(sqlStr, conn);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<Reservation> getReservations(int c_id)
        {
            List<Reservation> reservations = new List<Reservation>();
            try
            {
                sqlStr = "select *, ifnull(price, 0) as nn_price from reservation r left join special_requirements s on r.res_id = s.res_id  where c_id = " + c_id + " order by r.res_id";
                cmd = new MySqlCommand(sqlStr, conn);
                rdr = cmd.ExecuteReader();
                Reservation hrq;
                while (rdr.Read())
                {
                    hrq = new Reservation();
                    hrq.r_id = Convert.ToInt32(rdr["res_id"]);
                    hrq.c_id = Convert.ToInt32(rdr["c_id"]);
                    hrq.h_name = rdr["h_name"].ToString();
                    hrq.r_type = rdr["r_type"].ToString();
                    hrq.starting = rdr["start_date"].ToString();
                    hrq.ending = rdr["end_date"].ToString();
                    hrq.quantity = Convert.ToInt32(rdr["quantity"]);
                    hrq.spDescription = rdr["description"].ToString();
                    hrq.spCost = Convert.ToDecimal(rdr["nn_price"]);
                    reservations.Add(hrq);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reservations;
        }

        public List<Reservation> getAllReservations()
        {
            List<Reservation> reservations = new List<Reservation>();

            try
            {
                sqlStr = "select * from reservation order by res_id";
                cmd = new MySqlCommand(sqlStr, conn);
                rdr = cmd.ExecuteReader();

                Reservation hrq;
                while (rdr.Read())
                {
                    hrq = new Reservation();
                    hrq.r_id = Convert.ToInt32(rdr["res_id"]);
                    hrq.c_id = Convert.ToInt32(rdr["c_id"]);
                    hrq.h_name = rdr["h_name"].ToString();
                    hrq.r_type = rdr["r_type"].ToString();
                    hrq.starting = rdr["start_date"].ToString();
                    hrq.ending = rdr["end_date"].ToString();
                    hrq.quantity = Convert.ToInt32(rdr["quantity"]);
                    reservations.Add(hrq);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reservations;
        }

        public string getUser(int c_id)
        {
            string usr = "";
            try
            {
                sqlStr = "select f_name from customer where c_id = " + c_id;
                cmd = new MySqlCommand(sqlStr, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    usr = rdr.GetString(rdr.GetOrdinal("f_name"));
                }

                rdr.Close();
            }
            catch (Exception ex) { throw ex; }
            return usr;
        }
    }
}