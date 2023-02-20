public static List<EmailModel> DataIngetion()
        {
            string sqlConnection = "Data Source=icapdissqlserver.database.windows.net;database=icapdisql_dev;uid=icapdis;password=Provana@123;";

            using (SqlConnection con = new SqlConnection(sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("select top 1 * From ClientInputConfigs", con))
                {
                    //cmd.CommandType = System.Data.CommandType.Text;

                    con.Open();
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        List<EmailModel> emailModels = new List<EmailModel>();
                        while (dataReader.Read())
                        {
                            EmailModel emailModel = new EmailModel();
                            emailModel.title = "Test Email by  Pratik";
                            //emailModel.message = "This is automated email from .Net Code";
                            emailModel.pipilineName = "Deployment: Dev-Test";
                            emailModel.date = DateTime.Now;
                            emailModel.color = "green";
                            emailModel.addressTo = "pratikdevidas.ingole@provana.com";
                            //emailModel.addressCC = "purnachandra.majhi@provana.com";
                            emailModel.ClientName = dataReader["ClientName"].ToString();
                            emailModel.ClientSource = dataReader["ClientSource"].ToString();
                            emailModel.StartDate = dataReader["StartDate"].ToString();
                            emailModel.EndDate = dataReader["EndDate"].ToString();

                            //emailModel.message = "ClientName : " + emailModel.ClientName + "||"+
                            //    "ClientSource : " + emailModel.ClientSource + "||" +
                            //    "StartDate : " + emailModel.StartDate + "||" +
                            //    "EndDate : " + emailModel.EndDate;

                            emailModel.message = ("<!DOCTYPE html><html>" +
                                                 "<table width=\"1000\" border=\"1\" cellspacing=\"0\" cellpadding=\"0\" style=\"border:1px solid #ccc;\"> <tr align=\"center\"> </table>" +
                                                 "<th> ClientName </th><th> ClientSource  </th> <th> StartDate</th> <th> EndDate </th> " +
                                                 "<tr  align=\"center\"></tr>" +
                                                 $"<td> {emailModel.ClientName} '</td> <td> {emailModel.ClientSource} </td> <td>{ emailModel.StartDate}</td> <td>{emailModel.EndDate}</td>");
                                                 ;

                            emailModels.Add(emailModel);
                        }

                        return emailModels;
                    }
                }

            }








emailModel.message = ("<!DOCTYPE html><html>" +
    "<table width=\"1000\" border=\"1\" cellspacing=\"0\" cellpadding=\"0\" style=\"border:1px solid #ccc;\">" +
    "<tr align=\"center\">" +
    "<th>Client Name</th>" +
    "<th>Client Source</th>" +
    "<th>Start Date</th>" +
    "<th>End Date</th>" +
    "</tr>" +
    "<tr align=\"center\">" +
    $"<td>{emailModel.ClientName}</td>" +
    $"<td>{emailModel.ClientSource}</td>" +
    $"<td>{emailModel.StartDate}</td>" +
    $"<td>{emailModel.EndDate}</td>" +
    "</tr>" +
    "</table></html>");


