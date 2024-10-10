using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Data.SqlClient;

namespace Manajemen_Resiko.Models
{
    public class Matriks
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public Matriks(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }



        public List<MatriksModel> getAllData()
        {
            List<MatriksModel> matriksList = new List<MatriksModel>();
            try
            {
                string query = "select * from ahl_trrujukan";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MatriksModel matriks = new MatriksModel
                    {
                        mat_nilai = Convert.ToInt32(reader["mat_nilai"]),
                        mat_jenis = reader["mat_jenis"].ToString(),
                        mat_tingkat = reader["mat_tingkat"].ToString(),
                        mat_kategori = reader["mat_kategori"].ToString(),
                        mat_status = reader["mat_status"].ToString(),
                        createdby = reader["createdby"].ToString(),
                        createdon = Convert.ToDateTime(reader["createdon"]),
                        updatedby = reader["updatedby"].ToString(),
                        updatedon = Convert.ToDateTime(reader["createdon"]),
                    };
                    matriksList.Add(matriks);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return matriksList;
        }

        public MatriksModel getData(int id)
        {
            MatriksModel matriksModel = new MatriksModel();
            try
            {
                string query = "SELECT * FROM ahl_trrujukan WHERE rjk_id = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    matriksModel.mat_nilai = Convert.ToInt32(reader["mat_nilai"]);
                    matriksModel.mat_jenis = reader["mat_jenis"].ToString();
                    matriksModel.mat_tingkat = reader["mat_tingkat"].ToString();
                    matriksModel.mat_kategori = reader["mat_kategori"].ToString();
                    matriksModel.mat_status = reader["mat_status"].ToString();
                    matriksModel.createdby = reader["createdby"].ToString();
                    matriksModel.createdon = Convert.ToDateTime(reader["createdon"]);
                    matriksModel.updatedby = reader["updatedby"].ToString();
                    matriksModel.updatedon = Convert.ToDateTime(reader["createdon"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return matriksModel;
        }

        public MatriksModel getAnamnesaData(string id)
        {
            MatriksModel matriksList = new MatriksModel();
            try
            {
                string query = "SELECT * from ahl_tranamnesa where anm_id = @p1";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MatriksModel pasien = new MatriksModel
                    {
                        mat_nilai = Convert.ToInt32(reader["mat_nilai"]),
                        mat_jenis = reader["mat_jenis"].ToString(),
                        mat_tingkat = reader["mat_tingkat"].ToString(),
                        mat_kategori = reader["mat_kategori"].ToString(),
                        mat_status = reader["mat_status"].ToString(),
                        createdby = reader["createdby"].ToString(),
                        createdon = Convert.ToDateTime(reader["createdon"]),
                        updatedby = reader["updatedby"].ToString(),
                        updatedon = Convert.ToDateTime(reader["createdon"]),
                    };

                    matriksList = pasien;
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return matriksList;
        }

        public void insertData(MatriksModel matriksModel)
        {
            try
            {
                string query = "INSERT INTO [DB_ASTRAhealth].[dbo].[ahl_trrujukan] ([rjk_id_anamnesa], [rjk_rumah_sakit], [rjk_keterangan], [rjk_tanggal]) VALUES (@p1, @p2, @p3, @p4)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", matriksModel.mat_nilai);
                command.Parameters.AddWithValue("@p2", matriksModel.mat_tingkat);
                command.Parameters.AddWithValue("@p3", (object)matriksModel.mat_kategori ?? DBNull.Value);
                command.Parameters.AddWithValue("@p4", matriksModel.mat_status);
                _connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void updateData(MatriksModel matriksModel)
        {
            try
            {
                string query = "UPDATE [DB_ASTRAhealth].[dbo].[ahl_trrujukan] " +
                               "SET [rjk_keterangan] = @p2 " +
                               "WHERE [rjk_id] = @p1";

                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", matriksModel.mat_nilai);
                command.Parameters.AddWithValue("@p2", matriksModel.mat_jenis);
                _connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
