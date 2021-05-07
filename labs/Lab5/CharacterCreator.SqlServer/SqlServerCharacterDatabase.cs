/*
 * Character Creator - Lab 5
 * ITSE 1430
 * Spring 2021
 * Stuart Beeby
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CharacterCreator.SqlServer
{
    public class SqlServerCharacterDatabase : CharacterRoster
    {
        public SqlServerCharacterDatabase (string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override Character AddCore ( Character theCharacter )
        { 
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("AddCharacter", conn) {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@name", theCharacter.Name));
                cmd.Parameters.AddWithValue("@profession", theCharacter.Profession);
                cmd.Parameters.AddWithValue("@race", theCharacter.Race);
                cmd.Parameters.AddWithValue("@attribute1", theCharacter.Strength);
                cmd.Parameters.AddWithValue("@attribute2", theCharacter.Intelligence);
                cmd.Parameters.AddWithValue("@attribute3", theCharacter.Agility);
                cmd.Parameters.AddWithValue("@attribute4", theCharacter.Constitution);
                cmd.Parameters.AddWithValue("@attribute5", theCharacter.Charisma);
                cmd.Parameters.AddWithValue("@description", theCharacter.Biography);

                object result = cmd.ExecuteScalar();

                theCharacter.Id = Convert.ToInt32(result);
            }
            return theCharacter;
        }

        private SqlConnection OpenConnection()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }

        protected override void DeleteCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("DeleteCharacter", conn) {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        protected override IEnumerable<Character> GetAllCore ()
        {
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "GetAllCharacters";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var ds = new DataSet();
                var da = new SqlDataAdapter() {
                    SelectCommand = cmd
                };

                da.Fill(ds);

                var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
                if (table != null)
                {
                    foreach (var row in table.Rows.OfType<DataRow>())
                    {
                        yield return new Character() {
                            Id = (int)row[0],
                            Name = (string)row["Name"],
                            Profession = (string)row["Profession"],
                            Race = (string)row["Race"],
                            Strength = (int)row["Attribute1"],
                            Intelligence = (int)row["Attribute2"],
                            Agility = (int)row["Attribute3"],
                            Constitution = (int)row["Attribute4"],
                            Charisma = (int)row["Attribute5"],
                            Biography = row.Field<string>("Description")
                        };
                    };
                };
            }
        }

        protected override Character GetCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetCharacter", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Character() {
                            Id = (int)reader[0],
                            Name = (string)reader["Name"],
                            Profession = (string)reader["Profession"],
                            Race = (string)reader["Race"],
                            Strength = (int)reader["Attribute1"],
                            Intelligence = (int)reader["Attribute2"],
                            Agility = (int)reader["Attribute3"],
                            Constitution = (int)reader["Attribute4"],
                            Charisma = (int)reader["Attribute5"],
                            Biography = reader.GetString("Description")
                        };
                    };
                };
            }

            return null;
        }

        protected override void UpdateCore ( int id, Character theCharacter )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("UpdateCharacter", conn) {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@name", theCharacter.Name));
                cmd.Parameters.AddWithValue("@profession", theCharacter.Profession);
                cmd.Parameters.AddWithValue("@race", theCharacter.Race);
                cmd.Parameters.AddWithValue("@attribute1", theCharacter.Strength);
                cmd.Parameters.AddWithValue("@attribute2", theCharacter.Intelligence);
                cmd.Parameters.AddWithValue("@attribute3", theCharacter.Agility);
                cmd.Parameters.AddWithValue("@attribute4", theCharacter.Constitution);
                cmd.Parameters.AddWithValue("@attribute5", theCharacter.Charisma);
                cmd.Parameters.AddWithValue("@description", theCharacter.Biography);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        protected override Character FindByName ( string name )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("FindCharacterByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Character() {
                            Id = (int)reader[0],
                            Name = (string)reader["Name"],
                            Profession = (string)reader["Profession"],
                            Race = (string)reader["Race"],
                            Strength = (int)reader["Attribute1"],
                            Intelligence = (int)reader["Attribute2"],
                            Agility = (int)reader["Attribute3"],
                            Constitution = (int)reader["Attribute4"],
                            Charisma = (int)reader["Attribute5"],
                            Biography = reader.GetString("Description")
                        };
                    };
                };
            }

            return null;
        }

        private readonly string _connectionString;
    }
}
