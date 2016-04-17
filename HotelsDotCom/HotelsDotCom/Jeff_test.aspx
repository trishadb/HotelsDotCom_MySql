<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jeff_test.aspx.cs" Inherits="HotelsDotCom.Jeff_test" %>
<%@ Import Namespace="HotelsDotCom" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <%
        //HotelsDotCom.DBMgr db = HotelsDotCom.DBMgr.getInstance();
        HttpContext cont = HttpContext.Current;
        HttpResponse resp = cont.Response;
        /*
        Decorator rsv = new Reservation();
        rsv = new Massage(rsv);
        rsv = new Shuttle(rsv);
        rsv = new RoomService(rsv);
        rsv = new Flower(rsv);
        resp.Write(rsv.specialRequirement());
        resp.Write(rsv.cost());
        */
        /*
        Search search = (Search)HttpContext.Current.Session["search"]; //I can not use private to define search
        String starting = search.StartingDate;
        String ending = search.EndingDate;
        String destination = search.Destination;
        */
        
        HotelsDotCom.DBMgr_Jeff dbm = HotelsDotCom.DBMgr_Jeff.getInstance();
        List<HotelRoomQuantity> hotels = dbm.getSpecialRequirements();
        //int i = dbm.insertReservation();
        //int i = dbm.insertSpecialRequirements(12346, "shuttle", 19.99m);
        //int i = dbm.createSpecialRequirements();
        //List<HotelRoomQuantity> hotels = dbm.getHotelCapacityByDes("Hawaii");
        
        //List<HotelRoomQuantity> hotels = dbm.descReservationTable();
        //List<HotelRoomQuantity> occupied = dbm.getReserved(starting, ending, destination);
        //resp.Write("Hotel Capacity in " + destination);
        resp.Write("<br>");
        resp.Write("<br>");
        //resp.Write(i);
        
        foreach (HotelRoomQuantity hotel in hotels)
        {
            resp.Write(hotel.H_name);
            resp.Write("  /  ");
            resp.Write(hotel.R_type);
            resp.Write("  /  ");
            resp.Write(hotel.Quantity);
            resp.Write("<br>");
        }
        
        /*
        List<Reservation> reservations = dbm.getAllReservations();
        foreach (Reservation res in reservations)
        {
            resp.Write(res.r_id);
            resp.Write("  /  ");
            resp.Write(res.starting);
            resp.Write("  /  ");
            resp.Write(res.ending);
            resp.Write("<br>");
        }
        */
         %>
    </div>
    </form>
</body>
</html>
