using System;

namespace CarteSanteApp
{
    public static class AuditService
    {
        public static void LogAction(string actionType, string entityName, int? entityId, string details, int? userId = null, int? clientId = null)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var log = new Archivage
                    {
                        ActionType = actionType,
                        EntityName = entityName,
                        EntityId = entityId,
                        Details = details,
                        UserId = userId,
                        ClientId = clientId,
                        CreatedAt = DateTime.UtcNow
                    };

                    db.Archives.Add(log);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Évite d'interrompre le programme principal si l'archivage échoue
                Console.WriteLine($"Erreur lors de l'enregistrement de l'archive : {ex.Message}");
            }
        }
    }
}