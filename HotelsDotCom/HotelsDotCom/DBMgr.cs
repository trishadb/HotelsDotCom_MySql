using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;

namespace HotelsDotCom
{
    public class DBMgr
    {
        private MySqlConnection conn;
        private MySqlCommand cmd = null;
        private MySqlDataReader rdr = null;

        private static DBMgr dbInstance;
        private String connString = System.Configuration.ConfigurationManager.ConnectionStrings["hotel_connString"].ToString();

        private String sqlStr = "";

        public DBMgr()
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
        public static DBMgr getInstance()
        {
            if (dbInstance == null)
            {
                dbInstance = new DBMgr();
            }

            return dbInstance;
        }

        public ArrayList getCities()
        {

            ArrayList lst = new ArrayList();
            try
            {
                sqlStr = "SELECT DISTINCT city FROM hotel ORDER BY city";
                cmd = new MySqlCommand(sqlStr, conn);
                rdr = cmd.ExecuteReader();

                if (rdr != null)
                {
                    while (rdr.HasRows && rdr.Read())
                    {
                        Hotel h = new Hotel();
                        h.cities = rdr.GetString(rdr.GetOrdinal("city"));
                        lst.Add(h);
                    }
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst;
        }

        public List<HotelRoomQuantity> getHotelCapacity()
        {
            List<HotelRoomQuantity> hotels = new List<HotelRoomQuantity>();
            try
            {
                sqlStr = "select cap.h_name, cap.r_type, count(r_id) as r_cap from room cap group by cap.H_NAME, cap.r_type";
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



        public List<HotelRoomQuantity> getReserved(String starting, String ending, String desti) //String desti, , DateTime ending
        {
            List<HotelRoomQuantity> hotels = new List<HotelRoomQuantity>();
            try
            {
                sqlStr = "select h_name, r_type, sum(quantity) as r_booked from reservation "
                    + "where h_name in (select h_name from hotel where city = '" + desti + "') and "
                    + "((start_date>= str_to_date('" + starting + "','MM/DD/YY')  and end_date < str_to_date('" + ending + "','MM/DD/YY')) "
                    + "or (end_date > str_to_date('" + starting + "','MM/DD/YY') and end_date <= str_to_date('" + ending + "','MM/DD/YY')) "
                    + "or (start_date<= str_to_date('" + starting + "','MM/DD/YY') and end_date >= str_to_date('" + ending + "','MM/DD/YY')) "
                    + "or (start_date>= str_to_date('" + starting + "','MM/DD/YY') and end_date <= str_to_date('" + ending + "','MM/DD/YY'))) "
                    + "group by h_name, r_type";

                cmd = new MySqlCommand(sqlStr, conn);
                rdr = cmd.ExecuteReader();
                HotelRoomQuantity hrq;
                while (rdr.Read())
                {
                    hrq = new HotelRoomQuantity();
                    hrq.H_name = rdr["h_name"].ToString();
                    hrq.R_type = rdr["r_type"].ToString();
                    hrq.Quantity = Convert.ToInt32(rdr["r_booked"]);
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

        public List<HotelRoomQuantity> getReservedOnSingleNight(String starting, String desti) //String desti, , DateTime end_date
        {
            List<HotelRoomQuantity> hotels = new List<HotelRoomQuantity>();
            try
            {
                //2016/4/23
                /*
                sqlStr = "select h_name, r_type, sum(quantity) as r_booked from reservation "
                       + "where h_name in (select h_name from hotel where city = '" + desti + "') and "
                       + "(start_date<= str_to_date('" + starting + "','MM/DD/YY') and end_date > str_to_date('" + starting + "','MM/DD/YY')) "
                       + "group by h_name, r_type";
                */
                //2016/4/23 is turned into "4/23/2016" 
                //'%m/%d/%Y', y has to be captilized
                sqlStr = "select h_name, r_type, sum(quantity) as r_booked from reservation "
                       + "where h_name in (select h_name from hotel where city = '" + desti + "') and "
                       + "(start_date<= str_to_date('" + starting + "','%m/%d/%Y') and end_date > str_to_date('" + starting + "','%m/%d/%Y')) "
                       + "group by h_name, r_type";
                cmd = new MySqlCommand(sqlStr, conn);
                rdr = cmd.ExecuteReader();

                HotelRoomQuantity hrq;
                while (rdr.Read())
                {
                    hrq = new HotelRoomQuantity();
                    hrq.H_name = rdr["h_name"].ToString();
                    hrq.R_type = rdr["r_type"].ToString();
                    hrq.Quantity = Convert.ToInt32(rdr["r_booked"]);
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

        public int insertReservation(int c_id, String h_name,
            String r_type, String starting, String ending, int quantity)
        {
            int result = -1;
            try
            {
                //res_id,
                //55556, 
                /*
                sqlStr = "insert into reservation ( c_id, h_name, r_type, start_date, end_date, quantity) values "
                        + "(" + c_id + ", '" + h_name + "', '" + r_type + "', "
                        + "'" + starting + "', "
                        + "'" + ending + "', " + quantity + ")";
                */
                sqlStr = "insert into reservation (c_id, h_name, r_type, start_date, end_date, quantity) values "
                        + "(" + c_id + ", '" + h_name + "', '" + r_type + "', "
                        + "str_to_date('" + starting + "','%Y-%m-%d'), "
                        + "str_to_date('" + ending + "','%Y-%m-%d'), " + quantity + ")";

                cmd = new MySqlCommand(sqlStr, conn);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
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

        public List<Reservation> getReservations(int c_id)
        {
            List<Reservation> reservations = new List<Reservation>();
            try
            {
                sqlStr = "select * from reservation where c_id = " + c_id + " order by res_id";
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

        public int deleteReservation(int r_id)
        {
            int result = -1;
            try
            {
                sqlStr = "delete from reservation  where res_id = " + r_id;
                cmd = new MySqlCommand(sqlStr, conn);
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int isUser(String name, String psw)
        {
            int result = -1;
            try
            {
                sqlStr = "select c_id from customer  where f_name = '" + name + "' and psw='" + psw + "'";
                cmd = new MySqlCommand(sqlStr, conn);
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;


        }

        public HotelRoomQuantity getSelectdHotelRoom(string selectedItem)
        {
            HotelRoomQuantity hrq = new HotelRoomQuantity();
            try
            {
                sqlStr = "select cap.h_name, cap.r_type, count(r_id) as r_cap "
                    + "from room cap "
                    + "join hotel on hotel.h_name = cap.H_NAME "
                    + "where concat_ws('-',cap.h_name,cap.r_type) = '" + selectedItem + "' "
                    + "group by cap.H_NAME, cap.r_type "
                    + "order by cap.h_name";

                cmd = new MySqlCommand(sqlStr, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    hrq.H_name = rdr["h_name"].ToString();
                    hrq.R_type = rdr["r_type"].ToString();
                    hrq.Quantity = Convert.ToInt32(rdr["r_cap"]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return hrq;
        }
    }
}
