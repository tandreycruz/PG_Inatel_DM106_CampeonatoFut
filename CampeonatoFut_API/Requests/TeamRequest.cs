﻿namespace CampeonatoFut_API.Requests
{
    public record TeamRequest(string name, string coach, ICollection<StadiumRequest> Stadiums = null);
}
