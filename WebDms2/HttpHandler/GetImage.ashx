<%@ WebHandler Language="C#" Class="GetImage" %>

using System;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;

public class GetImage : IHttpHandler {

    const string FileNameHttpFailedErrorPage = @"ErrorPages/ErrorPageHttpHandler.aspx";

    
    public void ProcessRequest (HttpContext context) {        
        try
        {
            string file_id = context.Request.QueryString["file_id"];
            int id = int.Parse(file_id);


            SqlConnectionStringBuilder connBld = new SqlConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings["WebDms2.Properties.Settings.SqlFileFeaturesConnString"].ConnectionString);

            // Verbindungszeichenfolge modifizieren


            // Verbindung einrichten
            using (SqlConnection conn = new SqlConnection(connBld.ConnectionString))
            {
                conn.Open();

                string sql = "select img from compact.images where id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            SqlBytes bytes = reader.GetSqlBytes(0);

                            using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(bytes.Stream))
                            {
                                // Bild ausgeben an Client
                                context.Response.ContentType = "image/jpg";
                                System.IO.MemoryStream mem = new System.IO.MemoryStream();
                                bmp.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
                                mem.WriteTo(context.Response.OutputStream);
                            }
                        }
                        else
                        {
                            throw new Exception("Bildspalte ist leer");
                        }
                    }
                    else
                    {
                        throw new Exception("Kein Datensatz gefunden");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            string urlErrorPage = string.Format("{0}/{1}?Msg={2}", context.Request.ApplicationPath, FileNameHttpFailedErrorPage, ex.Message);
            context.Response.Redirect(urlErrorPage);
        }

        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}