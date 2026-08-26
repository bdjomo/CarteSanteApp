using System;

namespace CarteSanteApp
{
    public enum UserRole
    {
        ReadOnlyClients = 1,
        ReadAndUpdateClients = 2,
        ReadUpdateAndDeleteClients = 3,
        ReadUpdateDeleteAndCreateClient = 4,
        Admin = 5
    }
}
