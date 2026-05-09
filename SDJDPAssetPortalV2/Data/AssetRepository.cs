using Microsoft.Data.SqlClient;
using SDJDPAssetPortalV2.Models;

namespace SDJDPAssetPortalV2.Data
{
    public class AssetRepository
    {
        private readonly string connectionString =
            "Server=Dain\\SQLEXPRESS;Database=SDJDPAssetDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public List<Asset> GetAssets()
        {
            List<Asset> assets = new List<Asset>();

            using SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT AssetID, AssetType, SerialNumber, Department, Status FROM Assets";

            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                assets.Add(new Asset
                {
                    AssetID = reader["AssetID"].ToString() ?? "",
                    AssetType = reader["AssetType"].ToString() ?? "",
                    SerialNumber = reader["SerialNumber"].ToString() ?? "",
                    Department = reader["Department"].ToString() ?? "",
                    Status = reader["Status"].ToString() ?? ""
                });
            }

            return assets;
        }

        public List<Asset> SearchAssets(string searchText)
        {
            List<Asset> assets = new List<Asset>();

            using SqlConnection conn = new SqlConnection(connectionString);
            string query = @"SELECT AssetID, AssetType, SerialNumber, Department, Status
                             FROM Assets
                             WHERE AssetID LIKE @SearchText
                             OR AssetType LIKE @SearchText
                             OR SerialNumber LIKE @SearchText
                             OR Department LIKE @SearchText
                             OR Status LIKE @SearchText";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                assets.Add(new Asset
                {
                    AssetID = reader["AssetID"].ToString() ?? "",
                    AssetType = reader["AssetType"].ToString() ?? "",
                    SerialNumber = reader["SerialNumber"].ToString() ?? "",
                    Department = reader["Department"].ToString() ?? "",
                    Status = reader["Status"].ToString() ?? ""
                });
            }

            return assets;
        }

        public void AddAsset(Asset asset)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            string query = @"INSERT INTO Assets
                             (AssetID, AssetType, SerialNumber, Department, Status)
                             VALUES
                             (@AssetID, @AssetType, @SerialNumber, @Department, @Status)";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@AssetID", asset.AssetID);
            cmd.Parameters.AddWithValue("@AssetType", asset.AssetType);
            cmd.Parameters.AddWithValue("@SerialNumber", asset.SerialNumber);
            cmd.Parameters.AddWithValue("@Department", asset.Department);
            cmd.Parameters.AddWithValue("@Status", asset.Status);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void UpdateAsset(Asset asset)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            string query = @"UPDATE Assets
                             SET AssetType = @AssetType,
                                 SerialNumber = @SerialNumber,
                                 Department = @Department,
                                 Status = @Status
                             WHERE AssetID = @AssetID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@AssetID", asset.AssetID);
            cmd.Parameters.AddWithValue("@AssetType", asset.AssetType);
            cmd.Parameters.AddWithValue("@SerialNumber", asset.SerialNumber);
            cmd.Parameters.AddWithValue("@Department", asset.Department);
            cmd.Parameters.AddWithValue("@Status", asset.Status);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void DeleteAsset(string assetID)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            string query = "DELETE FROM Assets WHERE AssetID = @AssetID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@AssetID", assetID);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}