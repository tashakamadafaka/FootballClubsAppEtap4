using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using FootballClubsApp;

public class TransfersRepository
{
    private readonly PlayersRepository _playersRepository = new PlayersRepository();

    public List<Transfer> GetTransfers(int? playerId = null, int? clubId = null, DateTime? startDate = null, DateTime? endDate = null)
    {
        List<Transfer> list = new List<Transfer>();
        string sql = @"
            SELECT t.TransferId, t.PlayerId, CONCAT(p.FirstName, ' ', p.LastName) AS PlayerName,
                   t.FromClubId, cFrom.Name AS FromClubName,
                   t.ToClubId, cTo.Name AS ToClubName,
                   t.TransferDate, t.Fee, t.Note
            FROM transfers t
            JOIN players p ON t.PlayerId = p.PlayerId
            LEFT JOIN clubs cFrom ON t.FromClubId = cFrom.ClubId
            JOIN clubs cTo ON t.ToClubId = cTo.ClubId
            WHERE 1=1";

        List<MySqlParameter> parameters = new List<MySqlParameter>();

        if (playerId.HasValue && playerId.Value > 0)
        {
            sql += " AND t.PlayerId = @playerId";
            parameters.Add(new MySqlParameter("@playerId", playerId.Value));
        }

        if (clubId.HasValue && clubId.Value > 0)
        {
            sql += " AND (t.FromClubId = @clubId OR t.ToClubId = @clubId)";
            parameters.Add(new MySqlParameter("@clubId", clubId.Value));
        }

        if (startDate.HasValue)
        {
            sql += " AND t.TransferDate >= @startDate";
            parameters.Add(new MySqlParameter("@startDate", startDate.Value.Date));
        }

        if (endDate.HasValue)
        {
            sql += " AND t.TransferDate <= @endDate";
            parameters.Add(new MySqlParameter("@endDate", endDate.Value.Date.AddDays(1).AddTicks(-1)));
        }

        sql += " ORDER BY t.TransferDate DESC, t.TransferId DESC";

        DataTable dt = Db.GetDataTable(sql, parameters.ToArray());
        foreach (DataRow row in dt.Rows)
        {
            list.Add(new Transfer
            {
                TransferId = Convert.ToInt32(row["TransferId"]),
                PlayerId = Convert.ToInt32(row["PlayerId"]),
                PlayerName = row["PlayerName"].ToString(),
                FromClubId = row["FromClubId"] != DBNull.Value ? Convert.ToInt32(row["FromClubId"]) : (int?)null,
                FromClubName = row["FromClubId"] != DBNull.Value ? row["FromClubName"].ToString() : "Свободен агент",
                ToClubId = Convert.ToInt32(row["ToClubId"]),
                ToClubName = row["ToClubName"].ToString(),
                TransferDate = Convert.ToDateTime(row["TransferDate"]),
                Fee = Convert.ToDecimal(row["Fee"]),
                Note = row["Note"] != DBNull.Value ? row["Note"].ToString() : string.Empty
            });
        }
        return list;
    }

    public void AddTransfer(Transfer t)
    {
        using (var conn = Db.GetConnection())
        {
            conn.Open();
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // 1. Insert transfer record
                    string sqlTransfer = @"
                        INSERT INTO transfers (PlayerId, FromClubId, ToClubId, TransferDate, Fee, Note)
                        VALUES (@playerId, @fromClubId, @toClubId, @transferDate, @fee, @note)";
                    
                    using (var cmd = new MySqlCommand(sqlTransfer, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@playerId", t.PlayerId);
                        cmd.Parameters.AddWithValue("@fromClubId", (object)t.FromClubId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@toClubId", t.ToClubId);
                        cmd.Parameters.AddWithValue("@transferDate", t.TransferDate);
                        cmd.Parameters.AddWithValue("@fee", t.Fee);
                        cmd.Parameters.AddWithValue("@note", (object)t.Note ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Update players.club_id
                    _playersRepository.UpdatePlayerClub(t.PlayerId, t.ToClubId, conn, transaction);

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
