using FootballClubsApp;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

public class PlayersRepository
{
    public List<Player> GetPlayers(int? clubId, string? position = null, string? nameLike = null)
    {
        List<Player> list = new List<Player>();
        string sql = @"SELECT p.PlayerId, p.FirstName, p.LastName,
                              p.BirthDate, p.Position, p.ShirtNumber,
                              p.ClubId, 'Active' AS Status
                       FROM players p
                       WHERE 1=1";
        List<MySqlParameter> parameters = new List<MySqlParameter>();

        if (clubId.HasValue)
        {
            sql += " AND p.ClubId = @clubId";
            parameters.Add(new MySqlParameter("@clubId", clubId.Value));
        }
        if (!string.IsNullOrEmpty(position))
        {
            sql += " AND p.Position = @pos";
            parameters.Add(new MySqlParameter("@pos", position));
        }
        if (!string.IsNullOrEmpty(nameLike))
        {
            sql += " AND (p.FirstName LIKE @name OR p.LastName LIKE @name)";
            parameters.Add(new MySqlParameter("@name", "%" + nameLike + "%"));
        }

        DataTable dt = Db.GetDataTable(sql, parameters.ToArray());
        foreach (DataRow row in dt.Rows)
        {
            list.Add(new Player
            {
                PlayerId = Convert.ToInt32(row["PlayerId"]),
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                BirthDate = Convert.ToDateTime(row["BirthDate"]),
                Position = row["Position"].ToString(),
                ClubId = Convert.ToInt32(row["ClubId"]),
                ShirtNumber = row["ShirtNumber"] != DBNull.Value ? Convert.ToInt32(row["ShirtNumber"]) : (int?)null,
                Status = row["Status"].ToString()
            });
        }
        return list;
    }

    public void Add(Player p)
    {
        string sql = @"INSERT INTO players (FirstName, LastName, BirthDate, Position, ClubId, ShirtNumber)
                       VALUES (@fn,@ln,@bd,@pos,@club,@shirt)";
        Db.ExecuteNonQuery(sql,
            new MySqlParameter("@fn", p.FirstName),
            new MySqlParameter("@ln", p.LastName),
            new MySqlParameter("@bd", p.BirthDate),
            new MySqlParameter("@pos", p.Position),
            new MySqlParameter("@club", p.ClubId),
            new MySqlParameter("@shirt", p.ShirtNumber ?? 1));
    }

    public void Update(Player p)
    {
        string sql = @"UPDATE players SET FirstName=@fn, LastName=@ln, BirthDate=@bd,
                       Position=@pos, ClubId=@club, ShirtNumber=@shirt WHERE PlayerId=@id";
        Db.ExecuteNonQuery(sql,
            new MySqlParameter("@fn", p.FirstName),
            new MySqlParameter("@ln", p.LastName),
            new MySqlParameter("@bd", p.BirthDate),
            new MySqlParameter("@pos", p.Position),
            new MySqlParameter("@club", p.ClubId),
            new MySqlParameter("@shirt", p.ShirtNumber ?? 1),
            new MySqlParameter("@id", p.PlayerId));
    }

    public void Delete(int id)
    {
        string sql = "DELETE FROM players WHERE PlayerId=@id";
        Db.ExecuteNonQuery(sql, new MySqlParameter("@id", id));
    }

    public void UpdatePlayerClub(int playerId, int newClubId, MySqlConnection conn, MySqlTransaction transaction)
    {
        string sql = "UPDATE players SET ClubId=@club WHERE PlayerId=@id";
        using (var cmd = new MySqlCommand(sql, conn, transaction))
        {
            cmd.Parameters.AddWithValue("@club", newClubId);
            cmd.Parameters.AddWithValue("@id", playerId);
            cmd.ExecuteNonQuery();
        }
    }
}