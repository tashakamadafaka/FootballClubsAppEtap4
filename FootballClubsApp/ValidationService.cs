using FootballClubsApp;
using System;

public static class ValidationService
{
    public static bool ValidatePlayer(Player p, out string error)
    {
        error = "";

        if (string.IsNullOrWhiteSpace(p.FirstName) || string.IsNullOrWhiteSpace(p.LastName))
        {
            error = "Име и фамилия са задължителни!";
            return false;
        }

        if ((DateTime.Now.Year - p.BirthDate.Year) < 10 || (DateTime.Now.Year - p.BirthDate.Year) > 60)
        {
            error = "Играчът трябва да е на възраст между 10 и 60 години!";
            return false;
        }

        if (p.Position != "GK" && p.Position != "DF" && p.Position != "MF" && p.Position != "FW")
        {
            error = "Позицията трябва да е GK, DF, MF или FW!";
            return false;
        }

        return true;
    }
}